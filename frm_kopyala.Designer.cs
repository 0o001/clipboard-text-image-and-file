namespace clipboardtextimageandfile
{
    partial class frm_kopyala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_kopyala));
            this.flp_liste = new System.Windows.Forms.FlowLayoutPanel();
            this.tmr_gucelle = new System.Windows.Forms.Timer(this.components);
            this.nti_alt = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_alt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baslatDurdurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cikisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_alt.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_liste
            // 
            this.flp_liste.AutoScroll = true;
            this.flp_liste.AutoSize = true;
            this.flp_liste.BackColor = System.Drawing.Color.White;
            this.flp_liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_liste.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_liste.Location = new System.Drawing.Point(0, 0);
            this.flp_liste.Name = "flp_liste";
            this.flp_liste.Size = new System.Drawing.Size(310, 280);
            this.flp_liste.TabIndex = 0;
            this.flp_liste.WrapContents = false;
            this.flp_liste.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flp_liste_ControlAdded);
            this.flp_liste.Resize += new System.EventHandler(this.flp_liste_Resize);
            // 
            // tmr_gucelle
            // 
            this.tmr_gucelle.Tick += new System.EventHandler(this.tmr_gucelle_Tick);
            // 
            // nti_alt
            // 
            this.nti_alt.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nti_alt.BalloonTipText = "Program Çalışıyor...";
            this.nti_alt.BalloonTipTitle = "Bilgi";
            this.nti_alt.ContextMenuStrip = this.cms_alt;
            this.nti_alt.Icon = ((System.Drawing.Icon)(resources.GetObject("nti_alt.Icon")));
            this.nti_alt.Text = "Kopyala";
            this.nti_alt.Visible = true;
            this.nti_alt.DoubleClick += new System.EventHandler(this.nti_alt_DoubleClick);
            // 
            // cms_alt
            // 
            this.cms_alt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gosterToolStripMenuItem,
            this.baslatDurdurToolStripMenuItem,
            this.cikisToolStripMenuItem});
            this.cms_alt.Name = "cms_alt";
            this.cms_alt.Size = new System.Drawing.Size(177, 92);
            // 
            // gosterToolStripMenuItem
            // 
            this.gosterToolStripMenuItem.Name = "gosterToolStripMenuItem";
            this.gosterToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.gosterToolStripMenuItem.Text = "Gizle";
            this.gosterToolStripMenuItem.Click += new System.EventHandler(this.gosterToolStripMenuItem_Click);
            // 
            // baslatDurdurToolStripMenuItem
            // 
            this.baslatDurdurToolStripMenuItem.Name = "baslatDurdurToolStripMenuItem";
            this.baslatDurdurToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.baslatDurdurToolStripMenuItem.Text = "CopyBoardı Durdur";
            this.baslatDurdurToolStripMenuItem.Click += new System.EventHandler(this.baslatDurdurToolStripMenuItem_Click);
            // 
            // cikisToolStripMenuItem
            // 
            this.cikisToolStripMenuItem.Name = "cikisToolStripMenuItem";
            this.cikisToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cikisToolStripMenuItem.Text = "Çıkış";
            this.cikisToolStripMenuItem.Click += new System.EventHandler(this.cikisToolStripMenuItem_Click);
            // 
            // frm_kopyala
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(310, 280);
            this.Controls.Add(this.flp_liste);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_kopyala";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CopyBoard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_kopyala_FormClosing);
            this.cms_alt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_liste;
        private System.Windows.Forms.Timer tmr_gucelle;
        private System.Windows.Forms.NotifyIcon nti_alt;
        private System.Windows.Forms.ContextMenuStrip cms_alt;
        private System.Windows.Forms.ToolStripMenuItem baslatDurdurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cikisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gosterToolStripMenuItem;
    }
}

