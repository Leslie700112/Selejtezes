using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Selejtezés
{
    public partial class Form8 : Form
    {
        public string pecset,jelolt="N";
        private decimal mennyi;
        public Int32 sorszam;
        public Form8()
        {
            InitializeComponent();
       
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            this.selejtTableAdapter.Fill(this.dataSet1.Selejt, "9");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string wkeres = " ";

            string seekValue = this.textBox1.Text;
            if (seekValue != wkeres)
            {
                if (!string.IsNullOrEmpty(seekValue))
                {
                    selejtBindingSource.Filter = "Kereso like '%" + seekValue + "%'";
                }
                else
                {
                    try
                    {
                        selejtBindingSource.Filter = "";
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                wkeres = seekValue;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
         
            dataSet1.Selejt.Clear();
            this.selejtTableAdapter.Fill(this.dataSet1.Selejt, "9");
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["StockBalance"].Value) <Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["mennyDataGridViewTextBoxColumn"].Value))
                this.dataGridView1.Rows[e.RowIndex].Cells["StockBalance"].Style.BackColor = Color.LightSkyBlue;
        }
        
     private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] == this.Modo)
            {
                sorszam =Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells["sorszamDataGridViewTextBoxColumn"].Value);
                Form9 Form9 = new Form9();
                Form9.sorszam =sorszam;
                Form9.ShowDialog();
                dataSet1.Selejt.Clear();
                this.selejtTableAdapter.Fill(this.dataSet1.Selejt, "9");
            }
            if (dataGridView1.Columns[e.ColumnIndex] == this.Atvesz)
            {
                jelolt = "I";
                if (Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["StockBalance"].Value) >= Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["mennyDataGridViewTextBoxColumn"].Value))
                {
                    sorszam = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["sorszamDataGridViewTextBoxColumn"].Value);
                    Form11 Form11 = new Form11();
                    Form11.sorszam = sorszam;
                    Form11.pecset = pecset;
                    Form11.ShowDialog();
                    dataSet1.Selejt.Clear();
                    this.selejtTableAdapter.Fill(this.dataSet1.Selejt, "9");
                }
                else
                    MessageBox.Show("Nincs elég készlet !!");

            }
        }

    
    
    
    
    
    }
}
