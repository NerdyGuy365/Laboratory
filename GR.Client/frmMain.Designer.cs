namespace GR.Client
{
    partial class frmMain
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
            this.dgvProfiles = new System.Windows.Forms.DataGridView();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdoGender = new System.Windows.Forms.RadioButton();
            this.rdoBirthDate = new System.Windows.Forms.RadioButton();
            this.rdoName = new System.Windows.Forms.RadioButton();
            this.lblSortBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProfiles
            // 
            this.dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LastName,
            this.FirstName,
            this.Gender,
            this.Color,
            this.BirthDate});
            this.dgvProfiles.Location = new System.Drawing.Point(0, 0);
            this.dgvProfiles.Name = "dgvProfiles";
            this.dgvProfiles.RowTemplate.Height = 24;
            this.dgvProfiles.Size = new System.Drawing.Size(775, 227);
            this.dgvProfiles.TabIndex = 0;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "LastName";
            this.LastName.Name = "LastName";
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "FirstName";
            this.FirstName.Name = "FirstName";
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "Birth Date";
            this.BirthDate.Name = "BirthDate";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(562, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(210, 51);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Post Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button_Click);
            // 
            // rdoGender
            // 
            this.rdoGender.AutoSize = true;
            this.rdoGender.Location = new System.Drawing.Point(423, 233);
            this.rdoGender.Name = "rdoGender";
            this.rdoGender.Size = new System.Drawing.Size(77, 21);
            this.rdoGender.TabIndex = 2;
            this.rdoGender.TabStop = true;
            this.rdoGender.Text = "Gender";
            this.rdoGender.UseVisualStyleBackColor = true;
            this.rdoGender.Visible = false;
            this.rdoGender.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // rdoBirthDate
            // 
            this.rdoBirthDate.AutoSize = true;
            this.rdoBirthDate.Location = new System.Drawing.Point(423, 264);
            this.rdoBirthDate.Name = "rdoBirthDate";
            this.rdoBirthDate.Size = new System.Drawing.Size(92, 21);
            this.rdoBirthDate.TabIndex = 3;
            this.rdoBirthDate.TabStop = true;
            this.rdoBirthDate.Text = "Birth Date";
            this.rdoBirthDate.UseVisualStyleBackColor = true;
            this.rdoBirthDate.Visible = false;
            this.rdoBirthDate.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // rdoName
            // 
            this.rdoName.AutoSize = true;
            this.rdoName.Location = new System.Drawing.Point(423, 296);
            this.rdoName.Name = "rdoName";
            this.rdoName.Size = new System.Drawing.Size(66, 21);
            this.rdoName.TabIndex = 4;
            this.rdoName.TabStop = true;
            this.rdoName.Text = "Name";
            this.rdoName.UseVisualStyleBackColor = true;
            this.rdoName.Visible = false;
            this.rdoName.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // lblSortBy
            // 
            this.lblSortBy.AutoSize = true;
            this.lblSortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSortBy.Location = new System.Drawing.Point(311, 232);
            this.lblSortBy.Name = "lblSortBy";
            this.lblSortBy.Size = new System.Drawing.Size(99, 25);
            this.lblSortBy.TabIndex = 5;
            this.lblSortBy.Text = "SORT BY";
            this.lblSortBy.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 319);
            this.Controls.Add(this.lblSortBy);
            this.Controls.Add(this.rdoName);
            this.Controls.Add(this.rdoBirthDate);
            this.Controls.Add(this.rdoGender);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvProfiles);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Personal Details";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProfiles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.RadioButton rdoGender;
        private System.Windows.Forms.RadioButton rdoBirthDate;
        private System.Windows.Forms.RadioButton rdoName;
        private System.Windows.Forms.Label lblSortBy;
    }
}

