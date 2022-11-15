namespace eCinema.WinUI
{
    partial class frmProjection
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
            this.dgvProjection = new System.Windows.Forms.DataGridView();
            this.projectionDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbHall = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.movieIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movieIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hallIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectionStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateMachine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectionDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProjection
            // 
            this.dgvProjection.AllowUserToAddRows = false;
            this.dgvProjection.AllowUserToDeleteRows = false;
            this.dgvProjection.AutoGenerateColumns = false;
            this.dgvProjection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.movieIdDataGridViewTextBoxColumn1,
            this.dateTimeDataGridViewTextBoxColumn,
            this.hallIdDataGridViewTextBoxColumn,
            this.priceIdDataGridViewTextBoxColumn,
            this.projectionStatusDataGridViewTextBoxColumn,
            this.StateMachine});
            this.dgvProjection.DataSource = this.projectionDtoBindingSource;
            this.dgvProjection.Location = new System.Drawing.Point(57, 103);
            this.dgvProjection.Name = "dgvProjection";
            this.dgvProjection.ReadOnly = true;
            this.dgvProjection.RowHeadersWidth = 51;
            this.dgvProjection.RowTemplate.Height = 29;
            this.dgvProjection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjection.Size = new System.Drawing.Size(687, 312);
            this.dgvProjection.TabIndex = 23;
            this.dgvProjection.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjection_CellContentDoubleClick);
            this.dgvProjection.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProjection_CellFormatting);
            // 
            // projectionDtoBindingSource
            // 
            this.projectionDtoBindingSource.DataSource = typeof(eCinema.Model.Dtos.ProjectionDto);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(627, 55);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(117, 27);
            this.btnShow.TabIndex = 22;
            this.btnShow.Text = "Prikaži";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(523, 56);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(98, 28);
            this.cmbStatus.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(57, 58);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(136, 27);
            this.txtName.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(542, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Sala";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Naziv";
            // 
            // cmbHall
            // 
            this.cmbHall.FormattingEnabled = true;
            this.cmbHall.Location = new System.Drawing.Point(214, 57);
            this.cmbHall.Name = "cmbHall";
            this.cmbHall.Size = new System.Drawing.Size(61, 28);
            this.cmbHall.TabIndex = 24;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(296, 58);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(207, 27);
            this.dtpDate.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "DatumProjekcije";
            // 
            // movieIdDataGridViewTextBoxColumn
            // 
            this.movieIdDataGridViewTextBoxColumn.HeaderText = "Film";
            this.movieIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.movieIdDataGridViewTextBoxColumn.Name = "movieIdDataGridViewTextBoxColumn";
            this.movieIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // movieIdDataGridViewTextBoxColumn1
            // 
            this.movieIdDataGridViewTextBoxColumn1.HeaderText = "Film";
            this.movieIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.movieIdDataGridViewTextBoxColumn1.Name = "movieIdDataGridViewTextBoxColumn1";
            this.movieIdDataGridViewTextBoxColumn1.ReadOnly = true;
            this.movieIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
            this.dateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
            this.dateTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            this.dateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // hallIdDataGridViewTextBoxColumn
            // 
            this.hallIdDataGridViewTextBoxColumn.HeaderText = "Sala";
            this.hallIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hallIdDataGridViewTextBoxColumn.Name = "hallIdDataGridViewTextBoxColumn";
            this.hallIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.hallIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // priceIdDataGridViewTextBoxColumn
            // 
            this.priceIdDataGridViewTextBoxColumn.HeaderText = "Cijena";
            this.priceIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceIdDataGridViewTextBoxColumn.Name = "priceIdDataGridViewTextBoxColumn";
            this.priceIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // projectionStatusDataGridViewTextBoxColumn
            // 
            this.projectionStatusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.projectionStatusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.projectionStatusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.projectionStatusDataGridViewTextBoxColumn.Name = "projectionStatusDataGridViewTextBoxColumn";
            this.projectionStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.projectionStatusDataGridViewTextBoxColumn.Width = 125;
            // 
            // StateMachine
            // 
            this.StateMachine.DataPropertyName = "StateMachine";
            this.StateMachine.HeaderText = "Stanje";
            this.StateMachine.MinimumWidth = 6;
            this.StateMachine.Name = "StateMachine";
            this.StateMachine.ReadOnly = true;
            this.StateMachine.Width = 125;
            // 
            // frmProjection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbHall);
            this.Controls.Add(this.dgvProjection);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProjection";
            this.Text = "frmProjection";
            this.Load += new System.EventHandler(this.frmProjection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectionDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvProjection;
        private Button btnShow;
        private ComboBox cmbStatus;
        private TextBox txtName;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbHall;
        private DateTimePicker dtpDate;
        private Label label4;
        private Label label5;
        private BindingSource projectionDtoBindingSource;
        private DataGridViewTextBoxColumn movieIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn movieIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn hallIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn projectionStatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn StateMachine;
    }
}