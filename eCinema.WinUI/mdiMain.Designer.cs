namespace eCinema.WinUI
{
    partial class mdiMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obavijestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obavijestiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajObavijestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmoviToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajFilmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projekcijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projekcijeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dodajProjekcijuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.obavijestiToolStripMenuItem,
            this.filmoviToolStripMenuItem,
            this.projekcijeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(843, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getUsersToolStripMenuItem,
            this.adToolStripMenuItem});
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.usersToolStripMenuItem.Text = "Korisnici";
            // 
            // getUsersToolStripMenuItem
            // 
            this.getUsersToolStripMenuItem.Name = "getUsersToolStripMenuItem";
            this.getUsersToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.getUsersToolStripMenuItem.Text = "Korisnici";
            this.getUsersToolStripMenuItem.Click += new System.EventHandler(this.getUsersToolStripMenuItem_Click);
            // 
            // adToolStripMenuItem
            // 
            this.adToolStripMenuItem.Name = "adToolStripMenuItem";
            this.adToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.adToolStripMenuItem.Text = "Dodaj korisnika";
            this.adToolStripMenuItem.Click += new System.EventHandler(this.adToolStripMenuItem_Click);
            // 
            // obavijestiToolStripMenuItem
            // 
            this.obavijestiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obavijestiToolStripMenuItem1,
            this.dodajObavijestToolStripMenuItem});
            this.obavijestiToolStripMenuItem.Name = "obavijestiToolStripMenuItem";
            this.obavijestiToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.obavijestiToolStripMenuItem.Text = "Obavijesti";
            // 
            // obavijestiToolStripMenuItem1
            // 
            this.obavijestiToolStripMenuItem1.Name = "obavijestiToolStripMenuItem1";
            this.obavijestiToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.obavijestiToolStripMenuItem1.Text = "Obavijesti";
            this.obavijestiToolStripMenuItem1.Click += new System.EventHandler(this.obavijestiToolStripMenuItem1_Click);
            // 
            // dodajObavijestToolStripMenuItem
            // 
            this.dodajObavijestToolStripMenuItem.Name = "dodajObavijestToolStripMenuItem";
            this.dodajObavijestToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.dodajObavijestToolStripMenuItem.Text = "Dodaj obavijest";
            this.dodajObavijestToolStripMenuItem.Click += new System.EventHandler(this.dodajObavijestToolStripMenuItem_Click);
            // 
            // filmoviToolStripMenuItem
            // 
            this.filmoviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filmoviToolStripMenuItem1,
            this.dodajFilmToolStripMenuItem});
            this.filmoviToolStripMenuItem.Name = "filmoviToolStripMenuItem";
            this.filmoviToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.filmoviToolStripMenuItem.Text = "Filmovi";
            // 
            // filmoviToolStripMenuItem1
            // 
            this.filmoviToolStripMenuItem1.Name = "filmoviToolStripMenuItem1";
            this.filmoviToolStripMenuItem1.Size = new System.Drawing.Size(163, 26);
            this.filmoviToolStripMenuItem1.Text = "Filmovi";
            this.filmoviToolStripMenuItem1.Click += new System.EventHandler(this.filmoviToolStripMenuItem1_Click);
            // 
            // dodajFilmToolStripMenuItem
            // 
            this.dodajFilmToolStripMenuItem.Name = "dodajFilmToolStripMenuItem";
            this.dodajFilmToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.dodajFilmToolStripMenuItem.Text = "Dodaj film";
            this.dodajFilmToolStripMenuItem.Click += new System.EventHandler(this.dodajFilmToolStripMenuItem_Click);
            // 
            // projekcijeToolStripMenuItem
            // 
            this.projekcijeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projekcijeToolStripMenuItem1,
            this.dodajProjekcijuToolStripMenuItem});
            this.projekcijeToolStripMenuItem.Name = "projekcijeToolStripMenuItem";
            this.projekcijeToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.projekcijeToolStripMenuItem.Text = "Projekcije";
            // 
            // projekcijeToolStripMenuItem1
            // 
            this.projekcijeToolStripMenuItem1.Name = "projekcijeToolStripMenuItem1";
            this.projekcijeToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.projekcijeToolStripMenuItem1.Text = "Projekcije";
            this.projekcijeToolStripMenuItem1.Click += new System.EventHandler(this.projekcijeToolStripMenuItem1_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 671);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(843, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // dodajProjekcijuToolStripMenuItem
            // 
            this.dodajProjekcijuToolStripMenuItem.Name = "dodajProjekcijuToolStripMenuItem";
            this.dodajProjekcijuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.dodajProjekcijuToolStripMenuItem.Text = "Dodaj projekciju";
            this.dodajProjekcijuToolStripMenuItem.Click += new System.EventHandler(this.dodajProjekcijuToolStripMenuItem_Click);
            // 
            // mdiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 697);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "mdiMain";
            this.Text = "mdiMain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripMenuItem getUsersToolStripMenuItem;
        private ToolStripMenuItem adToolStripMenuItem;
        private ToolStripMenuItem obavijestiToolStripMenuItem;
        private ToolStripMenuItem obavijestiToolStripMenuItem1;
        private ToolStripMenuItem dodajObavijestToolStripMenuItem;
        private ToolStripMenuItem filmoviToolStripMenuItem;
        private ToolStripMenuItem filmoviToolStripMenuItem1;
        private ToolStripMenuItem dodajFilmToolStripMenuItem;
        private ToolStripMenuItem projekcijeToolStripMenuItem;
        private ToolStripMenuItem projekcijeToolStripMenuItem1;
        private ToolStripMenuItem dodajProjekcijuToolStripMenuItem;
    }
}



