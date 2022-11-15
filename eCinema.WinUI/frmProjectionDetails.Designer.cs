namespace eCinema.WinUI
{
    partial class frmProjectionDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMovieName = new System.Windows.Forms.ComboBox();
            this.cmbProjectionType = new System.Windows.Forms.ComboBox();
            this.cmbHall = new System.Windows.Forms.ComboBox();
            this.cmbPrice = new System.Windows.Forms.ComboBox();
            this.dtpProjectionDateTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Film";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tip projekcije";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vrijeme pocetka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cijena";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sala";
            // 
            // cmbMovieName
            // 
            this.cmbMovieName.FormattingEnabled = true;
            this.cmbMovieName.Location = new System.Drawing.Point(55, 70);
            this.cmbMovieName.Name = "cmbMovieName";
            this.cmbMovieName.Size = new System.Drawing.Size(151, 28);
            this.cmbMovieName.TabIndex = 6;
            // 
            // cmbProjectionType
            // 
            this.cmbProjectionType.FormattingEnabled = true;
            this.cmbProjectionType.Location = new System.Drawing.Point(55, 134);
            this.cmbProjectionType.Name = "cmbProjectionType";
            this.cmbProjectionType.Size = new System.Drawing.Size(151, 28);
            this.cmbProjectionType.TabIndex = 7;
            // 
            // cmbHall
            // 
            this.cmbHall.FormattingEnabled = true;
            this.cmbHall.Location = new System.Drawing.Point(283, 70);
            this.cmbHall.Name = "cmbHall";
            this.cmbHall.Size = new System.Drawing.Size(151, 28);
            this.cmbHall.TabIndex = 9;
            // 
            // cmbPrice
            // 
            this.cmbPrice.FormattingEnabled = true;
            this.cmbPrice.Location = new System.Drawing.Point(283, 134);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(151, 28);
            this.cmbPrice.TabIndex = 11;
            // 
            // dtpProjectionDateTime
            // 
            this.dtpProjectionDateTime.Location = new System.Drawing.Point(55, 198);
            this.dtpProjectionDateTime.Name = "dtpProjectionDateTime";
            this.dtpProjectionDateTime.Size = new System.Drawing.Size(248, 27);
            this.dtpProjectionDateTime.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(340, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Spasi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Location = new System.Drawing.Point(354, 198);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(80, 24);
            this.cbIsActive.TabIndex = 14;
            this.cbIsActive.Text = "Aktivan";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(55, 242);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(72, 29);
            this.btnActivate.TabIndex = 15;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(134, 242);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(72, 29);
            this.btnHide.TabIndex = 16;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            // 
            // frmProjectionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 297);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpProjectionDateTime);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.cmbHall);
            this.Controls.Add(this.cmbProjectionType);
            this.Controls.Add(this.cmbMovieName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProjectionDetails";
            this.Text = "frmProjectionDetails";
            this.Load += new System.EventHandler(this.frmProjectionDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cmbMovieName;
        private ComboBox cmbProjectionType;
        private ComboBox cmbHall;
        private ComboBox cmbPrice;
        private DateTimePicker dtpProjectionDateTime;
        private Button btnSave;
        private CheckBox cbIsActive;
        private Button btnActivate;
        private Button btnHide;
    }
}