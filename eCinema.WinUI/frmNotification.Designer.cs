namespace eCinema.WinUI
{
    partial class frmNotification
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.cmbNotificationType = new System.Windows.Forms.ComboBox();
            this.dgvNotifications = new System.Windows.Forms.DataGridView();
            this.notificationDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShow = new System.Windows.Forms.Button();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivna = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Autor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tip";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(87, 42);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(125, 27);
            this.txtTitle.TabIndex = 3;
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Location = new System.Drawing.Point(285, 42);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(103, 28);
            this.cmbAuthor.TabIndex = 4;
            // 
            // cmbNotificationType
            // 
            this.cmbNotificationType.FormattingEnabled = true;
            this.cmbNotificationType.Location = new System.Drawing.Point(469, 42);
            this.cmbNotificationType.Name = "cmbNotificationType";
            this.cmbNotificationType.Size = new System.Drawing.Size(98, 28);
            this.cmbNotificationType.TabIndex = 5;
            // 
            // dgvNotifications
            // 
            this.dgvNotifications.AutoGenerateColumns = false;
            this.dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.authorIdDataGridViewTextBoxColumn,
            this.notificationTypeDataGridViewTextBoxColumn,
            this.Content,
            this.Aktivna});
            this.dgvNotifications.DataSource = this.notificationDtoBindingSource;
            this.dgvNotifications.Location = new System.Drawing.Point(31, 92);
            this.dgvNotifications.Name = "dgvNotifications";
            this.dgvNotifications.RowHeadersWidth = 51;
            this.dgvNotifications.RowTemplate.Height = 29;
            this.dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotifications.Size = new System.Drawing.Size(687, 305);
            this.dgvNotifications.TabIndex = 6;
            this.dgvNotifications.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotifications_CellContentDoubleClick);
            // 
            // notificationDtoBindingSource
            // 
            this.notificationDtoBindingSource.DataSource = typeof(eCinema.Model.Dtos.NotificationDto);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(601, 42);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(117, 27);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Prikaži";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Datum";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // authorIdDataGridViewTextBoxColumn
            // 
            this.authorIdDataGridViewTextBoxColumn.DataPropertyName = "AuthorName";
            this.authorIdDataGridViewTextBoxColumn.HeaderText = "Autor";
            this.authorIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.authorIdDataGridViewTextBoxColumn.Name = "authorIdDataGridViewTextBoxColumn";
            this.authorIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.authorIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // notificationTypeDataGridViewTextBoxColumn
            // 
            this.notificationTypeDataGridViewTextBoxColumn.DataPropertyName = "NotificationType";
            this.notificationTypeDataGridViewTextBoxColumn.HeaderText = "Tip";
            this.notificationTypeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.notificationTypeDataGridViewTextBoxColumn.Name = "notificationTypeDataGridViewTextBoxColumn";
            this.notificationTypeDataGridViewTextBoxColumn.Width = 125;
            // 
            // Content
            // 
            this.Content.DataPropertyName = "Content";
            this.Content.HeaderText = "Sadržaj";
            this.Content.MinimumWidth = 6;
            this.Content.Name = "Content";
            this.Content.Width = 125;
            // 
            // Aktivna
            // 
            this.Aktivna.DataPropertyName = "IsActive";
            this.Aktivna.HeaderText = "Aktivna";
            this.Aktivna.MinimumWidth = 6;
            this.Aktivna.Name = "Aktivna";
            this.Aktivna.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aktivna.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Aktivna.Width = 125;
            // 
            // frmNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 396);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dgvNotifications);
            this.Controls.Add(this.cmbNotificationType);
            this.Controls.Add(this.cmbAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmNotification";
            this.Text = "frmNotification";
            this.Load += new System.EventHandler(this.frmNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private ComboBox cmbAuthor;
        private ComboBox cmbNotificationType;
        private DataGridView dgvNotifications;
        private BindingSource notificationDtoBindingSource;
        private Button btnShow;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn authorIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notificationTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Content;
        private DataGridViewCheckBoxColumn Aktivna;
    }
}