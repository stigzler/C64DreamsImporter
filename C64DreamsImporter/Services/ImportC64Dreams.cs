using stigzler.Utilities.Base.BaseEventArgs;
using stigzler.Utilities.Base.DotNet;
using stigzler.Utilities.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        internal static Exception ImportMainLibrary(string launchboxPath, string c64DreamsPath,
            IProgress<OperationProgressChangedEventArgs> progress, OperationProgressChangedEventArgs eventArgs)
        {
            // Lazy try/catch but meh
            try
            {
                DirectoryInfo c64DreamsSubDir = new DirectoryInfo(Path.Combine(c64DreamsPath, "C64 Dreams"));                

                string launchboxC64DreamsDirPath = Path.Combine(launchboxPath, "C64 Dreams");
                if (!Directory.Exists(launchboxC64DreamsDirPath)) Directory.CreateDirectory(launchboxC64DreamsDirPath);

                DirectoryInfo launchboxC64DreamsDir = new DirectoryInfo(Path.Combine(launchboxPath, "C64 Dreams"));

                eventArgs.CurrentSecondaryOperation = "C64 Dreams Files: ";
                eventArgs.CurrentMainOperation = "Initializing...";
                eventArgs.MainPercentageComplete = 0;
                progress.Report(eventArgs);

                // Copy C64 Dreams Sub Directory ===================================================================================

                c64DreamsSubDir.Copy(launchboxC64DreamsDir, false, progress);

                // Copy any Launchbox files specified in Files to Import.txt ========================================================

                IEnumerable<string> fileLines = File.ReadLines(Path.Combine(c64DreamsPath, @"C64 Dreams\Docs\Files to Import.txt"));
                int totalFiles = fileLines.Count();
                double count = 0;
                eventArgs.CurrentSecondaryOperation = "Launchbox Files: ";

                foreach (string line in fileLines)
                {
                    count += 1;
                    if (line.Length == 0) continue; // ignores blank lines

                    if (line[0] == '[') continue; // ignores "[IMAGES]" etc


                    string sourcePath = Path.Combine(c64DreamsPath, line);
                    if (line == "Data\\Playlists\\C64 Dreams Magazines All Magazines") sourcePath += ".xml"; // bug in original C64 Dreams package

                    string destinationPath = Path.Combine(launchboxPath, line);

                    // Determine if reference is file or directory
                    FileAttributes attr = File.GetAttributes(sourcePath);
                    if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        // item is a directory
                        if (!Directory.Exists(sourcePath)) continue;  // handles any missing directories
                        DirectoryInfo dir = new DirectoryInfo(sourcePath);
                        dir.Copy(new DirectoryInfo(destinationPath), true, progress);
                    }
                    else
                    {
                        // item is a file
                        if (!File.Exists(sourcePath)) continue;  // handles any missing files
                        File.Copy(sourcePath, destinationPath, true);
                    }

                    eventArgs.With(e =>
                    {
                        e.CurrentMainOperation = "Copied: " + line;
                        e.MainPercentageComplete = (int)Math.GetPercentage(count, totalFiles);
                    });

                    progress.Report(eventArgs);


                }

                // Update relevant Launchbox xmls ===================================================================================

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
                File.WriteAllText(launchboxParentsXmlFilepath, AppendedLaunchboxParentsXml);

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
                File.WriteAllText(launchboxPlatformsXmlFilepath, AppendedLaunchboxPlatformsXml);

                return null;
            }
            catch (Exception e)
            {
                return e;
            }

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
