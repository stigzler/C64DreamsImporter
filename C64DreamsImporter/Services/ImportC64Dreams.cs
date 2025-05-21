using C64DreamsImporter.DTOs;
using stigzler.Utilities.Base.BaseEventArgs;
using stigzler.Utilities.Base.DotNet;
using stigzler.Utilities.Base.Exceptions;
using stigzler.Utilities.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Math = stigzler.Utilities.Base.DotNet.Math;

namespace C64DreamsImporter.Services
{
    internal static class ImportC64Dreams
    {
       


        internal static List<MainLibraryImportResults> ImportMainLibrary(string launchboxPath, string c64DreamsPath,
                            IProgress<OperationProgressChangedEventArgs> progress, OperationProgressChangedEventArgs eventArgs)
        {
            List<MainLibraryImportResults> importResults = new List<MainLibraryImportResults>();

            DirectoryInfo c64DreamsSubDir = new DirectoryInfo(Path.Combine(c64DreamsPath, "C64 Dreams"));

            string launchboxC64DreamsDirPath = Path.Combine(launchboxPath, "C64 Dreams");
            if (!Directory.Exists(launchboxC64DreamsDirPath)) Directory.CreateDirectory(launchboxC64DreamsDirPath);

            DirectoryInfo launchboxC64DreamsDir = new DirectoryInfo(Path.Combine(launchboxPath, "C64 Dreams"));

            eventArgs.CurrentSecondaryOperation = "C64 Dreams Files: ";
            eventArgs.CurrentMainOperation = "Initializing...";
            eventArgs.MainPercentageComplete = 0;
            progress.Report(eventArgs);

            // Copy C64 Dreams Sub Directory ===================================================================================

            importResults.Add(new MainLibraryImportResults() { OperationSummary = "COPYING FILES FROM THE 'C64 DREAMS' SUB-FOLDER" });

            var c64DreamsDirCopyExceptions = c64DreamsSubDir.Copy(launchboxC64DreamsDir, false, progress);

            if (c64DreamsDirCopyExceptions.Result.Count() == 0)
            {
                importResults.Add(new MainLibraryImportResults()
                {
                    OperationSummary = "C64 Dreams sub directory import: all files copied successfully."
                });
            }
            else
            {
                importResults.Add(new MainLibraryImportResults()
                {
                    OperationSummary = "C64 Dreams sub directory import: Exceptions occurred whilst importing files",
                    MoveCopyExceptions = c64DreamsDirCopyExceptions.Result
                });
            }

            // Copy any Launchbox files specified in 'Files to Import.txt' ========================================================
            importResults.Add(new MainLibraryImportResults() { OperationSummary = "IMPORTING FILES SPECIFIED IN 'FILES TO IMPORT.TXT'" });

            List<string> fileLines = File.ReadLines(Path.Combine(c64DreamsPath, @"C64 Dreams\Docs\Files to Import.txt")).ToList();
            foreach(string addline in Data.ProcessData.FilesToImportAdditions)
            {
               if (!fileLines.Contains(addline)) fileLines.Add(addline);
            }

            int totalFiles = fileLines.Count();
            double count = 0;
            eventArgs.CurrentSecondaryOperation = "Launchbox Files: ";

            foreach (string line in fileLines)
            {
                count += 1;
                if (line.Length == 0) // ignores blank lines
                {
                    importResults.Add(new MainLibraryImportResults()
                    {
                        OperationSummary = "Skipping blank line in Import.txt"
                    });
                    continue;
                }

                if (line[0] == '[')// ignores "[IMAGES]" etc  
                {
                    importResults.Add(new MainLibraryImportResults()
                    {
                        OperationSummary = "Skipping Section Header line in Import.txt: " + line
                    });
                    continue;
                }

                string sourcePath = Path.Combine(c64DreamsPath, line).Trim();
                if (line == "Data\\Playlists\\C64 Dreams Magazines All Magazines") continue; // bug in original C64 Dreams package - missed off xml extension.

                string destinationPath = Path.Combine(launchboxPath, line.Trim());

                // Determine if reference is file or directory
                FileAttributes attr = File.GetAttributes(sourcePath);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    // item is a directory
                    if (!Directory.Exists(sourcePath))  // handles any missing directories                      
                    {
                        importResults.Add(new MainLibraryImportResults()
                        {
                            OperationSummary = "Error: Source Directory not found",
                            MoveCopyExceptions = new List<MoveCopyException>()
                            {
                                new MoveCopyException()
                                {
                                      SourcePath = sourcePath,
                                      Exception = null,
                                      OperationType = MoveCopyException.MoveCopyOperationType.FileCopy
                                }
                            }
                        });
                    }

                    DirectoryInfo dir = new DirectoryInfo(sourcePath.Trim());
                    var importTxtCopyExcpetions = dir.Copy(new DirectoryInfo(destinationPath), true, progress);

                    if (importTxtCopyExcpetions.Result.Count == 0)
                    {
                        importResults.Add(new MainLibraryImportResults()
                        {
                            OperationSummary = $"Import.txt import: successfully copied directory: [{sourcePath}] to [{destinationPath}]"
                        });
                    }
                    else
                    {
                        importResults.Add(new MainLibraryImportResults()
                        {
                            OperationSummary = $"Import.txt import: Exceptions whilst copying directory: [{sourcePath}] to [{destinationPath}]",
                            MoveCopyExceptions = importTxtCopyExcpetions.Result
                        });
                    }
                }
                else
                {
                    // item is a file
                    if (!File.Exists(sourcePath)) continue;  // handles any missing files
                    try
                    {
                        File.Copy("\\\\?\\" + sourcePath, "\\\\?\\" + destinationPath, true);
                        importResults.Add(new MainLibraryImportResults()
                        {
                            OperationSummary = $"Import.txt import: successfully copied file: [{sourcePath}] to [{destinationPath}]",
                        });
                    }
                    catch (Exception e)
                    {
                        importResults.Add(new MainLibraryImportResults()
                        {
                            OperationSummary = $"Import.txt import: Exception whilst copying file: [{sourcePath}]:",
                            MoveCopyExceptions = new List<MoveCopyException>()
                            {
                                new MoveCopyException()
                                {
                                      SourcePath = sourcePath,
                                      DestinationPath = destinationPath,
                                      Exception = e,
                                      OperationType = MoveCopyException.MoveCopyOperationType.FileCopy
                                }
                            }
                        });
                    }
                }

                eventArgs.With(e =>
                {
                    e.CurrentMainOperation = "Copied: " + line;
                    e.MainPercentageComplete = (int)Math.GetPercentage(count, totalFiles);
                });

                progress.Report(eventArgs);
            }


            // Update relevant Launchbox xmls ===================================================================================
            importResults.Add(new MainLibraryImportResults() { OperationSummary = "UPDATING LAUNCHBOX XMLS" });

            // Parents.xml
            // First backup
            string launchboxParentsXmlFilepath = Path.Combine(launchboxPath, @"Data\Parents.xml");
            string launchboxParentsVanillaXmlFilepath = Path.Combine(launchboxPath, @"Data\ParentsVanilla.xml"); // used as base for adding c64dreams elements
            if (!File.Exists(launchboxParentsVanillaXmlFilepath)) File.Copy(launchboxParentsXmlFilepath, launchboxParentsVanillaXmlFilepath);
            else File.Copy(launchboxParentsXmlFilepath, Path.Combine(launchboxPath, $"Data\\ParentsC64DreamsBackup{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.xml")); // keeps for roll backs

            // now append elements
            string AppendedLaunchboxParentsXml = File.ReadAllText(launchboxParentsVanillaXmlFilepath);
            AppendedLaunchboxParentsXml = AppendedLaunchboxParentsXml.Replace("</LaunchBox>", string.Empty); // removes closing tag
            AppendedLaunchboxParentsXml += File.ReadAllText(Path.Combine(c64DreamsPath, "C64 Dreams\\docs\\Parents XML Insert.txt"));
            AppendedLaunchboxParentsXml += Environment.NewLine + "</LaunchBox>";

            // now save
            try
            {
                File.WriteAllText(launchboxParentsXmlFilepath, AppendedLaunchboxParentsXml);
                importResults.Add(new MainLibraryImportResults()
                { OperationSummary = "XML Import: C64 Parents.xml successfully imported to Launchbox Parents.xml" });
            }
            catch (Exception e)
            {
                importResults.Add(new MainLibraryImportResults()
                { OperationSummary = "XML Import: Error whilst importing C64 Parents.xml to Launchbox Parents.xml: " + e.Message });
            }

            // Platforms.xml
            // First backup
            string launchboxPlatformsXmlFilepath = Path.Combine(launchboxPath, @"Data\Platforms.xml");
            string launchboxPlatformsVanillaXmlFilepath = Path.Combine(launchboxPath, @"Data\PlatformsVanilla.xml");
            if (!File.Exists(launchboxPlatformsVanillaXmlFilepath)) File.Copy(launchboxPlatformsXmlFilepath, launchboxPlatformsVanillaXmlFilepath);
            else File.Copy(launchboxPlatformsXmlFilepath, Path.Combine(launchboxPath, $"Data\\PlatformsC64DreamsBackup{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.xml")); // keeps for roll backs

            // now append elements
            string AppendedLaunchboxPlatformsXml = File.ReadAllText(launchboxPlatformsVanillaXmlFilepath);
            AppendedLaunchboxPlatformsXml = AppendedLaunchboxPlatformsXml.Replace("</LaunchBox>", string.Empty); // removes closing tag
            AppendedLaunchboxPlatformsXml += File.ReadAllText(Path.Combine(c64DreamsPath, "C64 Dreams\\docs\\Platforms XML Insert.txt"));
            AppendedLaunchboxPlatformsXml += Environment.NewLine + "</LaunchBox>";

            // now save
            try
            {
                File.WriteAllText(launchboxPlatformsXmlFilepath, AppendedLaunchboxPlatformsXml);
                importResults.Add(new MainLibraryImportResults()
                { OperationSummary = "XML Import: C64 Platforms.xml successfully imported to Launchbox Platforms.xml" });
            }
            catch (Exception e)
            {
                importResults.Add(new MainLibraryImportResults()
                { OperationSummary = "XML Import: Error whilst importing C64 Platforms.xml to Launchbox Platforms.xml: " + e.Message });
            }

            return importResults;
        }

        internal static Exception ImportHotfix(string launchboxPath, string hotfixPath)
        {
            try
            {
                DirectoryInfo hotfixDirInfo = new DirectoryInfo(hotfixPath);
                hotfixDirInfo.Copy(new DirectoryInfo(Properties.Settings.Default.LaunchboxRootPath), true);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        internal static Exception ImportMagazineModule(string launchboxPath, string modulePath,
            IProgress<OperationProgressChangedEventArgs> progress, OperationProgressChangedEventArgs eventArgs)
        {
            try
            {
                eventArgs.CurrentSecondaryOperation = "Importing Magazines: ";

                DirectoryInfo moduleDirInfo = new DirectoryInfo(modulePath);
                DirectoryInfo launchboxDestination = new DirectoryInfo(Path.Combine(Properties.Settings.Default.LaunchboxRootPath, "C64 Dreams"));
                moduleDirInfo.Copy(launchboxDestination, true, progress);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }


    }
}
