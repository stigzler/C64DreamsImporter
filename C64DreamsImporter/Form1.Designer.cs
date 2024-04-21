namespace C64DreamsImporter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new stigzler.Winforms.Base.UIElements.MenuStrip();
            this.additionalImportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotfixesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v060Hotfix2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magazineModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSS = new stigzler.Winforms.Base.UIElements.StatusStrip();
            this.StatusTooltipBT = new stigzler.Winforms.Base.ToolStripElements.Button();
            this.StatusPB = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusPrimaryOpLB = new stigzler.Winforms.Base.ToolStripElements.Label();
            this.StatusSecondaryOpLB = new stigzler.Winforms.Base.ToolStripElements.Label();
            this.ButtonFLP = new stigzler.Winforms.Base.UIElements.FlowLayoutPanel();
            this.ImportBT = new stigzler.Winforms.Base.UIElements.Button();
            this.label2 = new stigzler.Winforms.Base.UIElements.Label();
            this.C64DreamsFBD = new stigzler.Winforms.Base.UserControls.FileObjectTextBox();
            this.label1 = new stigzler.Winforms.Base.UIElements.Label();
            this.LaunchboxFBD = new stigzler.Winforms.Base.UserControls.FileObjectTextBox();
            this.MainTT = new stigzler.Winforms.Base.UIElements.ToolTip(this.components);
            this.panel1 = new stigzler.Winforms.Base.UIElements.Panel();
            this.menuStrip1.SuspendLayout();
            this.MainSS.SuspendLayout();
            this.ButtonFLP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.menuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.additionalImportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(624, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ToolTip = null;
            // 
            // additionalImportsToolStripMenuItem
            // 
            this.additionalImportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotfixesToolStripMenuItem,
            this.magazineModuleToolStripMenuItem});
            this.additionalImportsToolStripMenuItem.Name = "additionalImportsToolStripMenuItem";
            this.additionalImportsToolStripMenuItem.Size = new System.Drawing.Size(118, 19);
            this.additionalImportsToolStripMenuItem.Text = "Additional Imports";
            // 
            // hotfixesToolStripMenuItem
            // 
            this.hotfixesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.v060Hotfix2ToolStripMenuItem});
            this.hotfixesToolStripMenuItem.Name = "hotfixesToolStripMenuItem";
            this.hotfixesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.hotfixesToolStripMenuItem.Text = "Apply Hotfixes";
            // 
            // v060Hotfix2ToolStripMenuItem
            // 
            this.v060Hotfix2ToolStripMenuItem.Name = "v060Hotfix2ToolStripMenuItem";
            this.v060Hotfix2ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.v060Hotfix2ToolStripMenuItem.Text = "v0.60 Hotfix 2";
            this.v060Hotfix2ToolStripMenuItem.Click += new System.EventHandler(this.v060Hotfix2ToolStripMenuItem_Click);
            // 
            // magazineModuleToolStripMenuItem
            // 
            this.magazineModuleToolStripMenuItem.Name = "magazineModuleToolStripMenuItem";
            this.magazineModuleToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.magazineModuleToolStripMenuItem.Text = "Magazine Module";
            this.magazineModuleToolStripMenuItem.Click += new System.EventHandler(this.magazineModuleToolStripMenuItem_Click);
            // 
            // MainSS
            // 
            this.MainSS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.MainSS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.MainSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusTooltipBT,
            this.StatusPB,
            this.StatusPrimaryOpLB,
            this.StatusSecondaryOpLB});
            this.MainSS.Location = new System.Drawing.Point(0, 154);
            this.MainSS.Name = "MainSS";
            this.MainSS.ShowItemToolTips = true;
            this.MainSS.Size = new System.Drawing.Size(624, 22);
            this.MainSS.TabIndex = 5;
            this.MainSS.Text = "statusStrip1";
            this.MainSS.ToolTip = null;
            // 
            // StatusTooltipBT
            // 
            this.StatusTooltipBT.CheckOnClick = true;
            this.StatusTooltipBT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusTooltipBT.Image = global::C64DreamsImporter.Properties.Resources.information_balloon;
            this.StatusTooltipBT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StatusTooltipBT.Name = "StatusTooltipBT";
            this.StatusTooltipBT.Size = new System.Drawing.Size(23, 20);
            this.StatusTooltipBT.Text = "button1";
            this.StatusTooltipBT.ToolTipImage = null;
            this.StatusTooltipBT.ToolTipText = "Tooltips don\'t disappear after an amount of time";
            this.StatusTooltipBT.ToolTipTitle = "Persist Tooltips";
            this.StatusTooltipBT.CheckStateChanged += new System.EventHandler(this.StatusTooltipBT_CheckStateChanged);
            // 
            // StatusPB
            // 
            this.StatusPB.Name = "StatusPB";
            this.StatusPB.Size = new System.Drawing.Size(100, 16);
            this.StatusPB.Step = 1;
            // 
            // StatusPrimaryOpLB
            // 
            this.StatusPrimaryOpLB.Name = "StatusPrimaryOpLB";
            this.StatusPrimaryOpLB.Size = new System.Drawing.Size(114, 20);
            this.StatusPrimaryOpLB.Text = "Awaiting instruction";
            this.StatusPrimaryOpLB.ToolTipImage = null;
            this.StatusPrimaryOpLB.ToolTipText = null;
            this.StatusPrimaryOpLB.ToolTipTitle = null;
            // 
            // StatusSecondaryOpLB
            // 
            this.StatusSecondaryOpLB.Name = "StatusSecondaryOpLB";
            this.StatusSecondaryOpLB.Size = new System.Drawing.Size(19, 20);
            this.StatusSecondaryOpLB.Text = "....";
            this.StatusSecondaryOpLB.ToolTipImage = null;
            this.StatusSecondaryOpLB.ToolTipText = null;
            this.StatusSecondaryOpLB.ToolTipTitle = null;
            // 
            // ButtonFLP
            // 
            this.ButtonFLP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ButtonFLP.BackgroundShadeFactor = 1D;
            this.ButtonFLP.Controls.Add(this.ImportBT);
            this.ButtonFLP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonFLP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ButtonFLP.Location = new System.Drawing.Point(0, 111);
            this.ButtonFLP.Name = "ButtonFLP";
            this.ButtonFLP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButtonFLP.Size = new System.Drawing.Size(624, 43);
            this.ButtonFLP.TabIndex = 7;
            // 
            // ImportBT
            // 
            this.ImportBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ImportBT.DefocusOnClick = true;
            this.ImportBT.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ImportBT.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ImportBT.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.ImportBT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ImportBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(215)))));
            this.ImportBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportBT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ImportBT.Image = global::C64DreamsImporter.Properties.Resources.folder_import;
            this.ImportBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportBT.Location = new System.Drawing.Point(511, 3);
            this.ImportBT.Name = "ImportBT";
            this.ImportBT.Size = new System.Drawing.Size(110, 34);
            this.ImportBT.TabIndex = 6;
            this.ImportBT.Text = "Import";
            this.ImportBT.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.ImportBT.UseVisualStyleBackColor = false;
            this.ImportBT.Click += new System.EventHandler(this.ImportBT_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.FontStyle = System.Drawing.FontStyle.Regular;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.ScaleFont = 100;
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "C64Dreams Root:";
            this.label2.ToolTip = null;
            this.label2.ToolTipHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.label2.ToolTipImage = global::C64DreamsImporter.Properties.Resources.Commodore;
            this.label2.ToolTipText = "This should point to the root C64Dreams Directory. This is the directory that con" +
    "tains the full Launchbox installation and also the sub-folder ‘C64Dreams’ \r\n\r\n";
            this.label2.ToolTipTitle = "C64 Root Directory";
            // 
            // C64DreamsFBD
            // 
            this.C64DreamsFBD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C64DreamsFBD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.C64DreamsFBD.BackColor = System.Drawing.Color.Transparent;
            this.C64DreamsFBD.BrowserPrompt = null;
            this.C64DreamsFBD.DarkMode = false;
            this.C64DreamsFBD.EllipsisPosition = stigzler.Winforms.Base.UserControls.FileObjectTextBox.EllipsisPositions.End;
            this.C64DreamsFBD.FileSystemObjectMode = stigzler.Winforms.Base.UserControls.FileObjectTextBox.FileSystemObjectType.Folder;
            this.C64DreamsFBD.FontStyle = System.Drawing.FontStyle.Regular;
            this.C64DreamsFBD.Image = ((System.Drawing.Image)(resources.GetObject("C64DreamsFBD.Image")));
            this.C64DreamsFBD.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.C64DreamsFBD.Location = new System.Drawing.Point(130, 48);
            this.C64DreamsFBD.Margin = new System.Windows.Forms.Padding(0);
            this.C64DreamsFBD.MultiSelect = false;
            this.C64DreamsFBD.Name = "C64DreamsFBD";
            this.C64DreamsFBD.Path = "C:\\Start\\AnExamplePath\\To\\Your\\Stuff\\Middle\\Ellipse\\Test\\Here\\Yeah\\Path\\End.txt";
            this.C64DreamsFBD.ReadOnly = true;
            this.C64DreamsFBD.ScaleFont = 100;
            this.C64DreamsFBD.Size = new System.Drawing.Size(484, 25);
            this.C64DreamsFBD.TabIndex = 3;
            this.C64DreamsFBD.TextFont = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C64DreamsFBD.PathChanged += new stigzler.Winforms.Base.Events.FileSystemObjectPathChanged(this.C64DreamsFBD_PathChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.FontStyle = System.Drawing.FontStyle.Regular;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.ScaleFont = 100;
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Launchbox Root:";
            this.label1.ToolTip = null;
            this.label1.ToolTipHorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.label1.ToolTipImage = global::C64DreamsImporter.Properties.Resources.launchbox_32x32;
            this.label1.ToolTipText = "This should point to the root Launchbox Directory. This is the directory that con" +
    "tains Launchbox.exe and all the main folders such as Logs, Themes etc.";
            this.label1.ToolTipTitle = "Launchbox Root Directory";
            // 
            // LaunchboxFBD
            // 
            this.LaunchboxFBD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchboxFBD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LaunchboxFBD.BackColor = System.Drawing.Color.Transparent;
            this.LaunchboxFBD.BrowserPrompt = null;
            this.LaunchboxFBD.DarkMode = false;
            this.LaunchboxFBD.EllipsisPosition = stigzler.Winforms.Base.UserControls.FileObjectTextBox.EllipsisPositions.End;
            this.LaunchboxFBD.FileSystemObjectMode = stigzler.Winforms.Base.UserControls.FileObjectTextBox.FileSystemObjectType.Folder;
            this.LaunchboxFBD.FontStyle = System.Drawing.FontStyle.Regular;
            this.LaunchboxFBD.Image = ((System.Drawing.Image)(resources.GetObject("LaunchboxFBD.Image")));
            this.LaunchboxFBD.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LaunchboxFBD.Location = new System.Drawing.Point(130, 11);
            this.LaunchboxFBD.Margin = new System.Windows.Forms.Padding(0);
            this.LaunchboxFBD.MultiSelect = false;
            this.LaunchboxFBD.Name = "LaunchboxFBD";
            this.LaunchboxFBD.Path = "C:\\Start\\AnExamplePath\\To\\Your\\Stuff\\Middle\\Ellipse\\Test\\Here\\Yeah\\Path\\End.txt";
            this.LaunchboxFBD.ReadOnly = true;
            this.LaunchboxFBD.ScaleFont = 100;
            this.LaunchboxFBD.Size = new System.Drawing.Size(484, 25);
            this.LaunchboxFBD.TabIndex = 1;
            this.LaunchboxFBD.TextFont = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchboxFBD.PathChanged += new stigzler.Winforms.Base.Events.FileSystemObjectPathChanged(this.LaunchboxFBD_PathChanged);
            // 
            // MainTT
            // 
            this.MainTT.ActiveControl = null;
            this.MainTT.AutoPopDelay = 5000;
            this.MainTT.AutoTitleLength = 30;
            this.MainTT.BackColor = System.Drawing.SystemColors.Control;
            this.MainTT.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainTT.DefaultImageSize = new System.Drawing.Size(16, 16);
            this.MainTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainTT.GrowWidthForHeader = true;
            this.MainTT.Image = ((System.Drawing.Image)(resources.GetObject("MainTT.Image")));
            this.MainTT.InitialDelay = 1500;
            this.MainTT.MaxHeight = 300;
            this.MainTT.Offset = new System.Drawing.Point(0, 0);
            this.MainTT.OwnerDraw = true;
            this.MainTT.PanelPadding = 4;
            this.MainTT.ReshowDelay = 100;
            this.MainTT.ResizeImage = true;
            this.MainTT.ShowFor = 2500;
            this.MainTT.TitleBackground = System.Drawing.SystemColors.ControlLight;
            this.MainTT.TitleForeground = System.Drawing.SystemColors.InfoText;
            this.MainTT.ToolTipText = "Information here..";
            this.MainTT.ToolTipTitle = "Info";
            this.MainTT.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.BackgroundShadeFactor = 1D;
            this.panel1.Controls.Add(this.LaunchboxFBD);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.C64DreamsFBD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 86);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 176);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButtonFLP);
            this.Controls.Add(this.MainSS);
            this.Controls.Add(this.menuStrip1);
            this.DarkMode = true;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial Unicode MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C64 Dreams Importer";
            this.ToolTip = this.MainTT;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainSS.ResumeLayout(false);
            this.MainSS.PerformLayout();
            this.ButtonFLP.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private stigzler.Winforms.Base.UIElements.MenuStrip menuStrip1;
        private stigzler.Winforms.Base.UserControls.FileObjectTextBox LaunchboxFBD;
        private stigzler.Winforms.Base.UIElements.Label label1;
        private stigzler.Winforms.Base.UIElements.Label label2;
        private stigzler.Winforms.Base.UserControls.FileObjectTextBox C64DreamsFBD;
        private stigzler.Winforms.Base.UIElements.ToolTip MainTT;
        private stigzler.Winforms.Base.UIElements.StatusStrip MainSS;
        private stigzler.Winforms.Base.UIElements.Button ImportBT;
        private stigzler.Winforms.Base.UIElements.FlowLayoutPanel ButtonFLP;
        private System.Windows.Forms.ToolStripProgressBar StatusPB;
        private stigzler.Winforms.Base.ToolStripElements.Label StatusPrimaryOpLB;
        private stigzler.Winforms.Base.ToolStripElements.Button StatusTooltipBT;
        private stigzler.Winforms.Base.ToolStripElements.Label StatusSecondaryOpLB;
        private System.Windows.Forms.ToolStripMenuItem additionalImportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotfixesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magazineModuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v060Hotfix2ToolStripMenuItem;
        private stigzler.Winforms.Base.UIElements.Panel panel1;
    }
}

