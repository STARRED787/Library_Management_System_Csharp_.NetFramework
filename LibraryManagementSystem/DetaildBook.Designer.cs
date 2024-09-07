namespace LibraryManagementSystem
{
    partial class DetaildBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetaildBook));
            this.button4 = new System.Windows.Forms.Button();
            this.dgv_addBooks = new Guna.UI.WinForms.GunaDataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_bnameS = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tb_bookquantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addBookTBTableAdapter = new LibraryManagementSystem.LibManagementSystemDataSetTableAdapters.AddBookTBTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.libManagementSystemDataSet = new LibraryManagementSystem.LibManagementSystemDataSet();
            this.addBookTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addBooks)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libManagementSystemDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBookTBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(593, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 29);
            this.button4.TabIndex = 25;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // dgv_addBooks
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgv_addBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_addBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_addBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgv_addBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_addBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_addBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_addBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_addBooks.ColumnHeadersHeight = 21;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_addBooks.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_addBooks.EnableHeadersVisualStyles = false;
            this.dgv_addBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_addBooks.Location = new System.Drawing.Point(26, 205);
            this.dgv_addBooks.Name = "dgv_addBooks";
            this.dgv_addBooks.RowHeadersVisible = false;
            this.dgv_addBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_addBooks.Size = new System.Drawing.Size(871, 150);
            this.dgv_addBooks.TabIndex = 24;
            this.dgv_addBooks.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgv_addBooks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_addBooks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_addBooks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_addBooks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_addBooks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_addBooks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_addBooks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_addBooks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_addBooks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_addBooks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgv_addBooks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_addBooks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv_addBooks.ThemeStyle.HeaderStyle.Height = 21;
            this.dgv_addBooks.ThemeStyle.ReadOnly = false;
            this.dgv_addBooks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_addBooks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_addBooks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgv_addBooks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv_addBooks.ThemeStyle.RowsStyle.Height = 22;
            this.dgv_addBooks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_addBooks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(203, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 30);
            this.label9.TabIndex = 20;
            this.label9.Text = "Book Name";
            // 
            // tb_bnameS
            // 
            this.tb_bnameS.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_bnameS.Location = new System.Drawing.Point(343, 151);
            this.tb_bnameS.Name = "tb_bnameS";
            this.tb_bnameS.Size = new System.Drawing.Size(244, 23);
            this.tb_bnameS.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.tb_bookquantity);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(26, 377);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(871, 168);
            this.panel3.TabIndex = 22;
            // 
            // tb_bookquantity
            // 
            this.tb_bookquantity.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.tb_bookquantity.Location = new System.Drawing.Point(197, 277);
            this.tb_bookquantity.Name = "tb_bookquantity";
            this.tb_bookquantity.Size = new System.Drawing.Size(244, 23);
            this.tb_bookquantity.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Book Quantity";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 37);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(884, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 21);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(854, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suhada Welfair Society Library Management System";
            // 
            // addBookTBTableAdapter
            // 
            this.addBookTBTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 92);
            this.panel2.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "View Books";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(345, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(110, 86);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // libManagementSystemDataSet
            // 
            this.libManagementSystemDataSet.DataSetName = "LibManagementSystemDataSet";
            this.libManagementSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // addBookTBBindingSource
            // 
            this.addBookTBBindingSource.DataMember = "AddBookTB";
            this.addBookTBBindingSource.DataSource = this.libManagementSystemDataSet;
            // 
            // DetaildBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(917, 552);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgv_addBooks);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_bnameS);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetaildBook";
            this.Text = "DetaildBook";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addBooks)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libManagementSystemDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBookTBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private Guna.UI.WinForms.GunaDataGridView dgv_addBooks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_bnameS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tb_bookquantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private LibManagementSystemDataSetTableAdapters.AddBookTBTableAdapter addBookTBTableAdapter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private LibManagementSystemDataSet libManagementSystemDataSet;
        private System.Windows.Forms.BindingSource addBookTBBindingSource;
    }
}