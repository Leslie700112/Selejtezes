namespace Selejtezés
{
    partial class Form8
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selejtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Selejtezés.DataSet1();
            this.selejtTableAdapter = new Selejtezés.DataSet1TableAdapters.SelejtTableAdapter();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Atvesz = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Jelol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cikkszamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.internRem1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meegysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mennyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portSelejtDatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.megnevezésDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorszamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Megjegyz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modo = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Atvesz,
            this.Jelol,
            this.cikkszamDataGridViewTextBoxColumn,
            this.description1DataGridViewTextBoxColumn,
            this.description2DataGridViewTextBoxColumn,
            this.internRem1DataGridViewTextBoxColumn,
            this.meegysDataGridViewTextBoxColumn,
            this.StockBalance,
            this.mennyDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.TextDescription,
            this.portSelejtDatumDataGridViewTextBoxColumn,
            this.megnevezésDataGridViewTextBoxColumn,
            this.sorszamDataGridViewTextBoxColumn,
            this.Megjegyz,
            this.Modo});
            this.dataGridView1.DataSource = this.selejtBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 21;
            this.dataGridView1.Size = new System.Drawing.Size(1177, 604);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // selejtBindingSource
            // 
            this.selejtBindingSource.DataMember = "Selejt";
            this.selejtBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // selejtTableAdapter
            // 
            this.selejtTableAdapter.ClearBeforeFill = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1177, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(115, 36);
            this.toolStripButton2.Text = "Frissítés";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(122, 36);
            this.toolStripLabel1.Text = "Keresés :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(267, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Atvesz
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Atvesz.DefaultCellStyle = dataGridViewCellStyle2;
            this.Atvesz.HeaderText = "Átvesz";
            this.Atvesz.Name = "Atvesz";
            this.Atvesz.ReadOnly = true;
            this.Atvesz.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Atvesz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Atvesz.Text = "Átvesz";
            this.Atvesz.UseColumnTextForButtonValue = true;
            this.Atvesz.Width = 60;
            // 
            // Jelol
            // 
            this.Jelol.DataPropertyName = "Jelol";
            this.Jelol.HeaderText = "Jelol";
            this.Jelol.Name = "Jelol";
            this.Jelol.ReadOnly = true;
            this.Jelol.Visible = false;
            // 
            // cikkszamDataGridViewTextBoxColumn
            // 
            this.cikkszamDataGridViewTextBoxColumn.DataPropertyName = "Cikkszam";
            this.cikkszamDataGridViewTextBoxColumn.HeaderText = "Cikkszám";
            this.cikkszamDataGridViewTextBoxColumn.Name = "cikkszamDataGridViewTextBoxColumn";
            this.cikkszamDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // description1DataGridViewTextBoxColumn
            // 
            this.description1DataGridViewTextBoxColumn.DataPropertyName = "Description1";
            this.description1DataGridViewTextBoxColumn.HeaderText = "Megnevezés";
            this.description1DataGridViewTextBoxColumn.Name = "description1DataGridViewTextBoxColumn";
            this.description1DataGridViewTextBoxColumn.ReadOnly = true;
            this.description1DataGridViewTextBoxColumn.Width = 200;
            // 
            // description2DataGridViewTextBoxColumn
            // 
            this.description2DataGridViewTextBoxColumn.DataPropertyName = "Description2";
            this.description2DataGridViewTextBoxColumn.HeaderText = "Megnevezés";
            this.description2DataGridViewTextBoxColumn.Name = "description2DataGridViewTextBoxColumn";
            this.description2DataGridViewTextBoxColumn.ReadOnly = true;
            this.description2DataGridViewTextBoxColumn.Width = 200;
            // 
            // internRem1DataGridViewTextBoxColumn
            // 
            this.internRem1DataGridViewTextBoxColumn.DataPropertyName = "InternRem1";
            this.internRem1DataGridViewTextBoxColumn.HeaderText = "Rajzszám";
            this.internRem1DataGridViewTextBoxColumn.Name = "internRem1DataGridViewTextBoxColumn";
            this.internRem1DataGridViewTextBoxColumn.ReadOnly = true;
            this.internRem1DataGridViewTextBoxColumn.Width = 200;
            // 
            // meegysDataGridViewTextBoxColumn
            // 
            this.meegysDataGridViewTextBoxColumn.DataPropertyName = "Meegys";
            this.meegysDataGridViewTextBoxColumn.HeaderText = "M.egys.";
            this.meegysDataGridViewTextBoxColumn.Name = "meegysDataGridViewTextBoxColumn";
            this.meegysDataGridViewTextBoxColumn.ReadOnly = true;
            this.meegysDataGridViewTextBoxColumn.Width = 60;
            // 
            // StockBalance
            // 
            this.StockBalance.DataPropertyName = "StockBalance";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.StockBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.StockBalance.HeaderText = "Készlet";
            this.StockBalance.Name = "StockBalance";
            this.StockBalance.ReadOnly = true;
            this.StockBalance.Width = 80;
            // 
            // mennyDataGridViewTextBoxColumn
            // 
            this.mennyDataGridViewTextBoxColumn.DataPropertyName = "Menny";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.mennyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.mennyDataGridViewTextBoxColumn.HeaderText = "Mennyiség";
            this.mennyDataGridViewTextBoxColumn.Name = "mennyDataGridViewTextBoxColumn";
            this.mennyDataGridViewTextBoxColumn.ReadOnly = true;
            this.mennyDataGridViewTextBoxColumn.Width = 90;
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Munkahely";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            this.portDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // TextDescription
            // 
            this.TextDescription.DataPropertyName = "TextDescription";
            this.TextDescription.HeaderText = "Dolgozó";
            this.TextDescription.Name = "TextDescription";
            this.TextDescription.ReadOnly = true;
            this.TextDescription.Width = 200;
            // 
            // portSelejtDatumDataGridViewTextBoxColumn
            // 
            this.portSelejtDatumDataGridViewTextBoxColumn.DataPropertyName = "PortSelejtDatum";
            this.portSelejtDatumDataGridViewTextBoxColumn.HeaderText = "Selejtezés Ideje";
            this.portSelejtDatumDataGridViewTextBoxColumn.Name = "portSelejtDatumDataGridViewTextBoxColumn";
            this.portSelejtDatumDataGridViewTextBoxColumn.ReadOnly = true;
            this.portSelejtDatumDataGridViewTextBoxColumn.Width = 120;
            // 
            // megnevezésDataGridViewTextBoxColumn
            // 
            this.megnevezésDataGridViewTextBoxColumn.DataPropertyName = "Megnevezés";
            this.megnevezésDataGridViewTextBoxColumn.HeaderText = "Selejt Kategória";
            this.megnevezésDataGridViewTextBoxColumn.Name = "megnevezésDataGridViewTextBoxColumn";
            this.megnevezésDataGridViewTextBoxColumn.ReadOnly = true;
            this.megnevezésDataGridViewTextBoxColumn.Width = 120;
            // 
            // sorszamDataGridViewTextBoxColumn
            // 
            this.sorszamDataGridViewTextBoxColumn.DataPropertyName = "Sorszam";
            this.sorszamDataGridViewTextBoxColumn.HeaderText = "Sorszam";
            this.sorszamDataGridViewTextBoxColumn.Name = "sorszamDataGridViewTextBoxColumn";
            this.sorszamDataGridViewTextBoxColumn.ReadOnly = true;
            this.sorszamDataGridViewTextBoxColumn.Visible = false;
            // 
            // Megjegyz
            // 
            this.Megjegyz.DataPropertyName = "Megjegyz";
            this.Megjegyz.HeaderText = "Megjegyzés";
            this.Megjegyz.MaxInputLength = 200;
            this.Megjegyz.Name = "Megjegyz";
            this.Megjegyz.ReadOnly = true;
            this.Megjegyz.Width = 200;
            // 
            // Modo
            // 
            this.Modo.HeaderText = "Módosítás";
            this.Modo.Name = "Modo";
            this.Modo.ReadOnly = true;
            this.Modo.Text = "Módosítás";
            this.Modo.ToolTipText = "Selejtezett tétel módosítása";
            this.Modo.UseColumnTextForButtonValue = true;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 643);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form8";
            this.Text = "Selejt átvétel a munkahelyektől";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource selejtBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.SelejtTableAdapter selejtTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridViewButtonColumn Atvesz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jelol;
        private System.Windows.Forms.DataGridViewTextBoxColumn cikkszamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn description1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn description2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn internRem1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn meegysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn mennyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn portSelejtDatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn megnevezésDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorszamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Megjegyz;
        private System.Windows.Forms.DataGridViewButtonColumn Modo;
    }
}