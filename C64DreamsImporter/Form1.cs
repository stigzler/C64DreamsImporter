using C64DreamsImporter.Services;
using stigzler.Utilities.Base.BaseEventArgs;
using stigzler.Winforms.Base.Forms;
using stigzler.Winforms.Base.Forms.BaseForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C64DreamsImporter
{
    public partial class Form1 : BaseForm
    {
        bool operationRunning = false;
        OperationProgressChangedEventArgs eventArgs = new OperationProgressChangedEventArgs();
        Progress<OperationProgressChangedEventArgs> progress = new Progress<OperationProgressChangedEventArgs>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            progress.ProgressChanged += Progress_ProgressChanged;
        }

        private void LoadSettings()
        {
            LaunchboxFBD.Path = Properties.Settings.Default.LaunchboxRootPath;
            C64DreamsFBD.Path = Properties.Settings.Default.C64DreamsRootPath;
        }



        private void LaunchboxFBD_PathChanged(stigzler.Winforms.Base.Events.FileSystemObjectChangedEventArgs e)
        {
            TestLbPath(e.OldPath);
        }

        private void C64DreamsFBD_PathChanged(stigzler.Winforms.Base.Events.FileSystemObjectChangedEventArgs e)
        {
            TestC64DreamsPath(e.OldPath);
        }



        private bool TestLbPath(string oldpath = null)
        {
            if (Services.FileObjectTests.IsLaunchboxRoot(LaunchboxFBD.Path) == false)
            {
                stigzler.Winforms.Base.Forms.MessageBox messageBox =
                    new stigzler.Winforms.Base.Forms.MessageBox("The selected path for launchbox does not contain Launchbox.exe or the" +
                    " Directory 'Core' meaning this is likely an incorrect path. Please review", "Launchbox Root Path incorrect.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, "Incorrect Directory Path");

                messageBox.ShowDialog();
                if (oldpath != null) LaunchboxFBD.Path = oldpath;
                return false;
            }
            else
            {
                Properties.Settings.Default.LaunchboxRootPath = LaunchboxFBD.Path;
                Properties.Settings.Default.Save();
            }
            return true;
        }

        private bool TestC64DreamsPath(string oldpath = null)
        {
            if (Services.FileObjectTests.IsC64DreamsRoot(C64DreamsFBD.Path) == false)
            {
                stigzler.Winforms.Base.Forms.MessageBox messageBox =
                    new stigzler.Winforms.Base.Forms.MessageBox("The selected folder for C64Dreams is not named 'C64 Dreams'" +
                    " or does not contain an additoinal sub-folder called 'C64 Dreams'. It's a bit confusing, because of the nested 'C64 Dreams' folders. Try setting to a folder that also contains the folders '7-zip', 'Core' and 'Plugins'. Please review.", "C64Dreams Root Path incorrect.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, "Incorrect Directory Path");

                messageBox.ShowDialog();
                if (oldpath != null) C64DreamsFBD.Path = oldpath;
                return false;
            }
            else
            {
                Properties.Settings.Default.C64DreamsRootPath = C64DreamsFBD.Path;
                Properties.Settings.Default.Save();
            }
            return true;
        }

        private void ImportBT_Click(object sender, EventArgs e)
        {

            ImportC64DreamsDreams();
        }

        private void OperationAlreadyRunning()
        {
            new stigzler.Winforms.Base.Forms.MessageBox("There is another operation running. Please wait for this to complete before running another.",
                "Operation already running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, "Cannot run operation").ShowDialog();
        }

        private bool OperationCanBeRun()
        {
            // check if operation already running
            if (operationRunning)
            {
                OperationAlreadyRunning();
                return false;
            }

            // check if Launchbox or BigBox running
            Process[] launchboxInstances = Process.GetProcessesByName("Launchbox");
            Process[] bigBoxInstances = Process.GetProcessesByName("BigBox");

            if (launchboxInstances.Length != 0 || bigBoxInstances.Length != 0)
            {
                new stigzler.Winforms.Base.Forms.MessageBox("Either Launchbox or BigBox is running. Please close all instances of these before Importing C64 Dreams",
                    "Launchbox/Bigbox Running", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, "Cannot run operation").ShowDialog();
                return false;
            }

            if (TestLbPath() == false) { return false; }
            if (TestC64DreamsPath() == false) { return false; }

            return true;
        }

        private async void ImportC64DreamsDreams()
        {

            if (!OperationCanBeRun()) { return; };


            StatusPB.Style = ProgressBarStyle.Marquee;
            StatusPrimaryOpLB.Text = "Initializing..";

            operationRunning = true;

            OperationProgressChangedEventArgs eventArgs = new OperationProgressChangedEventArgs();
            Progress<OperationProgressChangedEventArgs> progress = new Progress<OperationProgressChangedEventArgs>();
            progress.ProgressChanged += Progress_ProgressChanged;

            Exception ImportResult = await Task.Run(() => ImportC64Dreams.ImportMainLibrary(LaunchboxFBD.Path,
                C64DreamsFBD.Path, progress, eventArgs));

            OperationOutcomePrompt(ImportResult, "Import Successful", "C64 Dreams import successful!", "Import Unsuccessful",
                "C64 Dreams import unsuccessful. Error: ");

            ClearProgress();

            operationRunning = false;
            progress.ProgressChanged -= Progress_ProgressChanged;


        }

        private void OperationOutcomePrompt(Exception e, string successShort, string successLong, string failiurShort, string failiurLong)
        {
            if (e == null)
            {
                new stigzler.Winforms.Base.Forms.MessageBox(successLong, successShort,
                     MessageBoxButtons.OK, MessageBoxIcon.Information, successShort).ShowDialog();
            }
            else
            {
                new stigzler.Winforms.Base.Forms.MessageBox(failiurLong + e.Message, failiurShort,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, failiurShort).ShowDialog();
            }
        }

        private void Progress_ProgressChanged(object sender, OperationProgressChangedEventArgs e)
        {
            if (StatusPB.Style == ProgressBarStyle.Marquee) StatusPB.Style = ProgressBarStyle.Continuous;
            if (e.CurrentSecondaryOperation != null) StatusPrimaryOpLB.Text = e.CurrentSecondaryOperation;
            StatusSecondaryOpLB.Text = e.CurrentMainOperation;
            StatusPB.Value = e.MainPercentageComplete;
        }

        private void ClearProgress()
        {
            StatusPB.Style = ProgressBarStyle.Continuous;
            StatusPB.Value = 0;
            StatusPrimaryOpLB.Text = "";
            StatusSecondaryOpLB.Text = "";
        }

        private void StatusTooltipBT_CheckStateChanged(object sender, EventArgs e)
        {
            if (StatusTooltipBT.Checked) MainTT.ShowFor = 0;
            else MainTT.ShowFor = 2000;
        }

        private void v060Hotfix2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyHotfix("0.60.2");
        }

        private void ApplyHotfix(string version)
        {
            if (!OperationCanBeRun()) { return; };

            switch (version)
            {
                case "0.60.2":
                    stigzler.Winforms.Base.Dialogs.FolderBrowserDialog fbd = new stigzler.Winforms.Base.Dialogs.FolderBrowserDialog();
                    fbd.Description = "Please select the unzipped folder 'C64 Dreams v0.60 Hotfix 6-5-2023'";
                    var result = fbd.ShowDialog(this);
                    if (result != true) return;
                    if (!Services.FileObjectTests.IsHotfix0602(fbd.SelectedPath))
                    {
                        new stigzler.Winforms.Base.Forms.MessageBox("This appears to be the wrong folder for this hotfix. Please ensure that it is unzipped and the root folder.", "Hotfix Root Path incorrect.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, "Incorrect Hotfix Path").ShowDialog();
                        return;
                    }

                    operationRunning = true;
                    var hotfixResult = ImportC64Dreams.ImportHotfix(Properties.Settings.Default.LaunchboxRootPath, fbd.SelectedPath);

                    OperationOutcomePrompt(hotfixResult, "Import Successful", $"Hotfix {version} import successful!",
                        "Hotfix import Unsuccessful", "Hotfix import unsuccessful. Error: ");

                    break;

            }

            ClearProgress();
            operationRunning = false;
        }

        private void magazineModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportMagazineModule();
        }

        private async void ImportMagazineModule()
        {
            if (!OperationCanBeRun()) { return; };

            stigzler.Winforms.Base.Dialogs.FolderBrowserDialog fbd = new stigzler.Winforms.Base.Dialogs.FolderBrowserDialog();
            fbd.Description = "Please select the Magazine Module folder 'C64 Dreams - Magazine Module v0.60'";
            var result = fbd.ShowDialog(this);
            if (result != true) return;

            if (!Services.FileObjectTests.IsMagazineModule(fbd.SelectedPath))
            {
                new stigzler.Winforms.Base.Forms.MessageBox("This appears to be the wrong folder for this Magazine Module. Please ensure that it is unzipped and the root folder is selected.", "Magazine Module Path incorrect.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, "Incorrect Magazine Module Path").ShowDialog();
                operationRunning = false;
                return;
            }

            operationRunning = true;
            OperationProgressChangedEventArgs eventArgs = new OperationProgressChangedEventArgs();
            Progress<OperationProgressChangedEventArgs> progress = new Progress<OperationProgressChangedEventArgs>();
            progress.ProgressChanged += Progress_ProgressChanged;

            var magazineModuleResult = await Task.Run(() => ImportC64Dreams.ImportMagazineModule(Properties.Settings.Default.LaunchboxRootPath,
                fbd.SelectedPath, progress, eventArgs));

            //Exception ImportResult = await Task.Run(() => ImportC64Dreams.ImportMainLibrary(LaunchboxFBD.Path,
            //        C64DreamsFBD.Path, progress, eventArgs));


            OperationOutcomePrompt(magazineModuleResult, "Import Successful", $"Magazine module import successful!",
                "Magazine module import Unsuccessful", "Magazine module import unsuccessful. Error: ");

            ClearProgress();
            operationRunning = false;
            progress.ProgressChanged -= Progress_ProgressChanged;

        }


    }
}
