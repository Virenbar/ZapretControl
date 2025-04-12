namespace ZapretControl
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            TrayControl = new System.Windows.Forms.NotifyIcon(components);
            TrayMenu = new System.Windows.Forms.ContextMenuStrip(components);
            MI_Start = new System.Windows.Forms.ToolStripMenuItem();
            MI_Stop = new System.Windows.Forms.ToolStripMenuItem();
            MI_Show = new System.Windows.Forms.ToolStripMenuItem();
            MI_Close = new System.Windows.Forms.ToolStripMenuItem();
            FormMenu = new System.Windows.Forms.MenuStrip();
            MI_Settings = new System.Windows.Forms.ToolStripMenuItem();
            MI_About = new System.Windows.Forms.ToolStripMenuItem();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            B_Restart = new System.Windows.Forms.Button();
            B_Close = new System.Windows.Forms.Button();
            B_Start = new System.Windows.Forms.Button();
            BS_ControlSettings = new System.Windows.Forms.BindingSource(components);
            GB_Scripts = new System.Windows.Forms.GroupBox();
            TLP_Scripts = new System.Windows.Forms.TableLayoutPanel();
            radioButton1 = new System.Windows.Forms.RadioButton();
            radioButton2 = new System.Windows.Forms.RadioButton();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            TrayMenu.SuspendLayout();
            FormMenu.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BS_ControlSettings).BeginInit();
            GB_Scripts.SuspendLayout();
            TLP_Scripts.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // TrayControl
            // 
            TrayControl.ContextMenuStrip = TrayMenu;
            TrayControl.Text = "ZapretControl";
            TrayControl.Visible = true;
            TrayControl.MouseClick += TrayControl_MouseClick;
            // 
            // TrayMenu
            // 
            TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MI_Start, MI_Stop, MI_Show, MI_Close });
            TrayMenu.Name = "TrayMenu";
            TrayMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // MI_Start
            // 
            MI_Start.Image = Properties.Resources.winws_green;
            MI_Start.Name = "MI_Start";
            MI_Start.Size = new System.Drawing.Size(180, 22);
            MI_Start.Text = "Start Zapret";
            MI_Start.Click += MI_Start_Click;
            // 
            // MI_Stop
            // 
            MI_Stop.Image = Properties.Resources.winws_red;
            MI_Stop.Name = "MI_Stop";
            MI_Stop.Size = new System.Drawing.Size(180, 22);
            MI_Stop.Text = "Stop Zapret";
            MI_Stop.Click += MI_Stop_Click;
            // 
            // MI_Show
            // 
            MI_Show.Image = icons8.Settings16;
            MI_Show.Name = "MI_Show";
            MI_Show.Size = new System.Drawing.Size(180, 22);
            MI_Show.Text = "Show ZapretControl";
            MI_Show.Click += MI_Show_Click;
            // 
            // MI_Close
            // 
            MI_Close.Image = icons8.Shutdown16;
            MI_Close.Name = "MI_Close";
            MI_Close.Size = new System.Drawing.Size(180, 22);
            MI_Close.Text = "Close ZapretControl";
            MI_Close.Click += MI_Close_Click;
            // 
            // FormMenu
            // 
            FormMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MI_Settings, MI_About });
            FormMenu.Location = new System.Drawing.Point(0, 0);
            FormMenu.Name = "FormMenu";
            FormMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            FormMenu.Size = new System.Drawing.Size(534, 24);
            FormMenu.TabIndex = 1;
            FormMenu.Text = "menuStrip1";
            // 
            // MI_Settings
            // 
            MI_Settings.Image = icons8.Settings16;
            MI_Settings.Name = "MI_Settings";
            MI_Settings.Size = new System.Drawing.Size(77, 20);
            MI_Settings.Text = "Settings";
            MI_Settings.Click += MI_Settings_Click;
            // 
            // MI_About
            // 
            MI_About.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            MI_About.Image = icons8.Info16;
            MI_About.Name = "MI_About";
            MI_About.Size = new System.Drawing.Size(68, 20);
            MI_About.Text = "About";
            MI_About.Click += MI_About_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(B_Restart, 0, 0);
            tableLayoutPanel1.Controls.Add(B_Close, 2, 0);
            tableLayoutPanel1.Controls.Add(B_Start, 1, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 178);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new System.Drawing.Size(534, 33);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // B_Restart
            // 
            B_Restart.AutoSize = true;
            B_Restart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            B_Restart.Enabled = false;
            B_Restart.Image = icons8.Replace16;
            B_Restart.Location = new System.Drawing.Point(3, 3);
            B_Restart.Name = "B_Restart";
            B_Restart.Padding = new System.Windows.Forms.Padding(1);
            B_Restart.Size = new System.Drawing.Size(108, 27);
            B_Restart.TabIndex = 7;
            B_Restart.Text = "Restart Zapret";
            B_Restart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            B_Restart.UseVisualStyleBackColor = true;
            B_Restart.Click += B_Restart_Click;
            // 
            // B_Close
            // 
            B_Close.Anchor = System.Windows.Forms.AnchorStyles.Right;
            B_Close.AutoSize = true;
            B_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            B_Close.Image = icons8.Shutdown16;
            B_Close.Location = new System.Drawing.Point(390, 3);
            B_Close.Name = "B_Close";
            B_Close.Padding = new System.Windows.Forms.Padding(1);
            B_Close.Size = new System.Drawing.Size(141, 27);
            B_Close.TabIndex = 3;
            B_Close.Text = "Close ZapretControl";
            B_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            B_Close.UseVisualStyleBackColor = true;
            B_Close.Click += B_Close_Click;
            // 
            // B_Start
            // 
            B_Start.Anchor = System.Windows.Forms.AnchorStyles.None;
            B_Start.AutoSize = true;
            B_Start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            B_Start.Image = Properties.Resources.winws_green;
            B_Start.Location = new System.Drawing.Point(219, 3);
            B_Start.Name = "B_Start";
            B_Start.Padding = new System.Windows.Forms.Padding(1);
            B_Start.Size = new System.Drawing.Size(96, 27);
            B_Start.TabIndex = 1;
            B_Start.Text = "Start Zapret";
            B_Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            B_Start.UseVisualStyleBackColor = true;
            B_Start.Click += B_Start_Click;
            // 
            // BS_ControlSettings
            // 
            BS_ControlSettings.DataSource = typeof(Model.ControlSettings);
            // 
            // GB_Scripts
            // 
            GB_Scripts.AutoSize = true;
            GB_Scripts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            GB_Scripts.Controls.Add(TLP_Scripts);
            GB_Scripts.Dock = System.Windows.Forms.DockStyle.Top;
            GB_Scripts.Location = new System.Drawing.Point(3, 3);
            GB_Scripts.Name = "GB_Scripts";
            GB_Scripts.Size = new System.Drawing.Size(528, 47);
            GB_Scripts.TabIndex = 6;
            GB_Scripts.TabStop = false;
            GB_Scripts.Text = "Scripts";
            // 
            // TLP_Scripts
            // 
            TLP_Scripts.AutoSize = true;
            TLP_Scripts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            TLP_Scripts.ColumnCount = 3;
            TLP_Scripts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            TLP_Scripts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            TLP_Scripts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            TLP_Scripts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            TLP_Scripts.Controls.Add(radioButton1, 0, 0);
            TLP_Scripts.Controls.Add(radioButton2, 1, 0);
            TLP_Scripts.Dock = System.Windows.Forms.DockStyle.Fill;
            TLP_Scripts.Location = new System.Drawing.Point(3, 19);
            TLP_Scripts.Name = "TLP_Scripts";
            TLP_Scripts.RowCount = 1;
            TLP_Scripts.RowStyles.Add(new System.Windows.Forms.RowStyle());
            TLP_Scripts.Size = new System.Drawing.Size(522, 25);
            TLP_Scripts.TabIndex = 8;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new System.Drawing.Point(3, 3);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(87, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "Placeholder";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new System.Drawing.Point(96, 3);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(87, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Placeholder";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel2.Controls.Add(GB_Scripts, 0, 0);
            tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel2.Size = new System.Drawing.Size(534, 53);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            ClientSize = new System.Drawing.Size(534, 211);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(FormMenu);
            DoubleBuffered = true;
            MainMenuStrip = FormMenu;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(800, 600);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(550, 250);
            Name = "FormMain";
            Text = "ZapretControl";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            TrayMenu.ResumeLayout(false);
            FormMenu.ResumeLayout(false);
            FormMenu.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BS_ControlSettings).EndInit();
            GB_Scripts.ResumeLayout(false);
            GB_Scripts.PerformLayout();
            TLP_Scripts.ResumeLayout(false);
            TLP_Scripts.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayControl;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.MenuStrip FormMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.Button B_Start;
        private System.Windows.Forms.ToolStripMenuItem MI_About;
        private System.Windows.Forms.BindingSource BS_ControlSettings;
        private System.Windows.Forms.ToolStripMenuItem MI_Start;
        private System.Windows.Forms.ToolStripMenuItem MI_Stop;
        private System.Windows.Forms.ToolStripMenuItem MI_Show;
        private System.Windows.Forms.ToolStripMenuItem MI_Close;
        private System.Windows.Forms.Button B_Restart;
        private System.Windows.Forms.GroupBox GB_Scripts;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem MI_Settings;
        private System.Windows.Forms.TableLayoutPanel TLP_Scripts;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}