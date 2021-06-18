namespace Selejtezés
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.selejtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Selejtezés.DataSet1();
            this.selejtTableAdapter = new Selejtezés.DataSet1TableAdapters.SelejtTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Cikkszam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MRendeles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dolgozoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seldatumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternRem1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meegys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.megjegyzDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dolgozo1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keresoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortDolg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortSelejtDatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelejtFajta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.megnevezésDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sorszamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cikkszam,
            this.MRendeles,
            this.Menny,
            this.dolgozoDataGridViewTextBoxColumn,
            this.seldatumDataGridViewTextBoxColumn,
            this.Description1,
            this.Description2,
            this.InternRem1,
            this.Meegys,
            this.Port,
            this.megjegyzDataGridViewTextBoxColumn,
            this.dolgozo1DataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.keresoDataGridViewTextBoxColumn,
            this.PortDolg,
            this.PortSelejtDatum,
            this.SelejtFajta,
            this.megnevezésDataGridViewTextBoxColumn,
            this.sorszamDataGridViewTextBoxColumn,
            this.textDescriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.selejtBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(96, 280);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(769, 65);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.Visible = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(42, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(42, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mennyiség :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(155, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(270, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Beszállítói selejt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(224, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ellenőrzési selejt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(445, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gyártási selejt";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(648, 26);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Homok selejt";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(95, 139);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(779, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selejt Kategóriák";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox4.Location = new System.Drawing.Point(637, 70);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox4.MaxLength = 10;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 23);
            this.textBox4.TabIndex = 8;
            this.textBox4.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox3.Location = new System.Drawing.Point(446, 70);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(132, 23);
            this.textBox3.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.Location = new System.Drawing.Point(234, 70);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(132, 23);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(11, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 23);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(244, 348);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 43);
            this.button1.TabIndex = 10;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(516, 348);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 43);
            this.button2.TabIndex = 12;
            this.button2.Text = "Kilépés";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(398, 252);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Összesen :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(484, 252);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 14);
            this.label10.TabIndex = 14;
            this.label10.Text = "label10";
            // 
            // Cikkszam
            // 
            this.Cikkszam.DataPropertyName = "Cikkszam";
            this.Cikkszam.HeaderText = "Cikkszam";
            this.Cikkszam.Name = "Cikkszam";
            this.Cikkszam.ReadOnly = true;
            // 
            // MRendeles
            // 
            this.MRendeles.DataPropertyName = "MRendeles";
            this.MRendeles.HeaderText = "MRendeles";
            this.MRendeles.Name = "MRendeles";
            this.MRendeles.ReadOnly = true;
            // 
            // Menny
            // 
            this.Menny.DataPropertyName = "Menny";
            this.Menny.HeaderText = "Menny";
            this.Menny.Name = "Menny";
            this.Menny.ReadOnly = true;
            // 
            // dolgozoDataGridViewTextBoxColumn
            // 
            this.dolgozoDataGridViewTextBoxColumn.DataPropertyName = "Dolgozo";
            this.dolgozoDataGridViewTextBoxColumn.HeaderText = "Dolgozo";
            this.dolgozoDataGridViewTextBoxColumn.Name = "dolgozoDataGridViewTextBoxColumn";
            this.dolgozoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // seldatumDataGridViewTextBoxColumn
            // 
            this.seldatumDataGridViewTextBoxColumn.DataPropertyName = "Sel_datum";
            this.seldatumDataGridViewTextBoxColumn.HeaderText = "Sel_datum";
            this.seldatumDataGridViewTextBoxColumn.Name = "seldatumDataGridViewTextBoxColumn";
            this.seldatumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Description1
            // 
            this.Description1.DataPropertyName = "Description1";
            this.Description1.HeaderText = "Description1";
            this.Description1.Name = "Description1";
            this.Description1.ReadOnly = true;
            // 
            // Description2
            // 
            this.Description2.DataPropertyName = "Description2";
            this.Description2.HeaderText = "Description2";
            this.Description2.Name = "Description2";
            this.Description2.ReadOnly = true;
            // 
            // InternRem1
            // 
            this.InternRem1.DataPropertyName = "InternRem1";
            this.InternRem1.HeaderText = "InternRem1";
            this.InternRem1.Name = "InternRem1";
            this.InternRem1.ReadOnly = true;
            // 
            // Meegys
            // 
            this.Meegys.DataPropertyName = "Meegys";
            this.Meegys.HeaderText = "Meegys";
            this.Meegys.Name = "Meegys";
            this.Meegys.ReadOnly = true;
            // 
            // Port
            // 
            this.Port.DataPropertyName = "Port";
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.ReadOnly = true;
            // 
            // megjegyzDataGridViewTextBoxColumn
            // 
            this.megjegyzDataGridViewTextBoxColumn.DataPropertyName = "Megjegyz";
            this.megjegyzDataGridViewTextBoxColumn.HeaderText = "Megjegyz";
            this.megjegyzDataGridViewTextBoxColumn.Name = "megjegyzDataGridViewTextBoxColumn";
            this.megjegyzDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dolgozo1DataGridViewTextBoxColumn
            // 
            this.dolgozo1DataGridViewTextBoxColumn.DataPropertyName = "Dolgozo1";
            this.dolgozo1DataGridViewTextBoxColumn.HeaderText = "Dolgozo1";
            this.dolgozo1DataGridViewTextBoxColumn.Name = "dolgozo1DataGridViewTextBoxColumn";
            this.dolgozo1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keresoDataGridViewTextBoxColumn
            // 
            this.keresoDataGridViewTextBoxColumn.DataPropertyName = "Kereso";
            this.keresoDataGridViewTextBoxColumn.HeaderText = "Kereso";
            this.keresoDataGridViewTextBoxColumn.Name = "keresoDataGridViewTextBoxColumn";
            this.keresoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PortDolg
            // 
            this.PortDolg.DataPropertyName = "PortDolg";
            this.PortDolg.HeaderText = "PortDolg";
            this.PortDolg.Name = "PortDolg";
            this.PortDolg.ReadOnly = true;
            // 
            // PortSelejtDatum
            // 
            this.PortSelejtDatum.DataPropertyName = "PortSelejtDatum";
            this.PortSelejtDatum.HeaderText = "PortSelejtDatum";
            this.PortSelejtDatum.Name = "PortSelejtDatum";
            this.PortSelejtDatum.ReadOnly = true;
            // 
            // SelejtFajta
            // 
            this.SelejtFajta.DataPropertyName = "SelejtFajta";
            this.SelejtFajta.HeaderText = "SelejtFajta";
            this.SelejtFajta.Name = "SelejtFajta";
            this.SelejtFajta.ReadOnly = true;
            // 
            // megnevezésDataGridViewTextBoxColumn
            // 
            this.megnevezésDataGridViewTextBoxColumn.DataPropertyName = "Megnevezés";
            this.megnevezésDataGridViewTextBoxColumn.HeaderText = "Megnevezés";
            this.megnevezésDataGridViewTextBoxColumn.Name = "megnevezésDataGridViewTextBoxColumn";
            this.megnevezésDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sorszamDataGridViewTextBoxColumn
            // 
            this.sorszamDataGridViewTextBoxColumn.DataPropertyName = "Sorszam";
            this.sorszamDataGridViewTextBoxColumn.HeaderText = "Sorszam";
            this.sorszamDataGridViewTextBoxColumn.Name = "sorszamDataGridViewTextBoxColumn";
            this.sorszamDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // textDescriptionDataGridViewTextBoxColumn
            // 
            this.textDescriptionDataGridViewTextBoxColumn.DataPropertyName = "TextDescription";
            this.textDescriptionDataGridViewTextBoxColumn.HeaderText = "TextDescription";
            this.textDescriptionDataGridViewTextBoxColumn.Name = "textDescriptionDataGridViewTextBoxColumn";
            this.textDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(968, 414);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form9";
            this.Text = "Módosítás";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selejtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource selejtBindingSource;
        private DataSet1 dataSet1;
        private DataSet1TableAdapters.SelejtTableAdapter selejtTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cikkszam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MRendeles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menny;
        private System.Windows.Forms.DataGridViewTextBoxColumn dolgozoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seldatumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description2;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternRem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meegys;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn megjegyzDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dolgozo1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keresoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortDolg;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortSelejtDatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelejtFajta;
        private System.Windows.Forms.DataGridViewTextBoxColumn megnevezésDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sorszamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn textDescriptionDataGridViewTextBoxColumn;
    }
}