using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;

namespace Selejtezés
{
    public partial class Form11 : Form
    {
        public string pecset;
        public Int32 sorszam;
        private double ossz = 0;
        public Form11()
        {
            InitializeComponent();
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView2.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView2.CellEndEdit += new DataGridViewCellEventHandler(dataGridView2_CellEndEdit);
            dataGridView2.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView2_EditingControlShowing);
            this.dataGridView2.KeyDown += new KeyEventHandler(dataGridView2_KeyDown);
        }

        private void Form11_Load(object sender, EventArgs e)
        {
           
            this.selejtTableAdapter.Fill(this.dataSet1.Selejt, "9");
            selejtBindingSource.Filter = "Sorszam=" + sorszam;
            this.vF_SC330300_StockBatchTableAdapter.Fill(this.dataSet2.VF_SC330300_StockBatch, dataGridView1.CurrentRow.Cells["cikkszamDataGridViewTextBoxColumn"].Value.ToString().Trim());
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[6];
            dataGridView2.Select();
            dataGridView2.CurrentCell = dataGridView2.Rows[0].Cells[2];
            label2.Text = dataGridView1.CurrentRow.Cells["meegysDataGridViewTextBoxColumn"].Value.ToString().Trim();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Columns[6].HeaderCell.Style.BackColor = Color.LightGreen;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.Columns[2].HeaderCell.Style.BackColor = Color.LightGreen;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
                connection.Open();
                SqlCommand mySqlCommand = connection.CreateCommand();
                mySqlCommand.CommandText = " update Selejt set Megjegyz=@Megjegyz where Sorszam=@Sorszam ";
                mySqlCommand.Parameters.Clear();
                mySqlCommand.Parameters.Add("@Sorszam", SqlDbType.Int);
                mySqlCommand.Parameters["@Sorszam"].Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells["sorszamDataGridViewTextBoxColumn"].Value.ToString().Trim());
                mySqlCommand.Parameters.Add("@Megjegyz", SqlDbType.NVarChar);
                 string megj = Convert.ToString(dataGridView1.Rows[0].Cells["megjegyzDataGridViewTextBoxColumn"].Value);
                  if (String.IsNullOrEmpty(megj))
                      mySqlCommand.Parameters["@Megjegyz"].Value =" "; 
                   else
                        mySqlCommand.Parameters["@Megjegyz"].Value =megj;
                       mySqlCommand.ExecuteNonQuery();
                       connection.Close();
            }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ossz = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                ossz += Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
            }
            textBox1.Text = ossz.ToString();

            if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["mennyDataGridViewTextBoxColumn"].Value)< ossz || Convert.ToDouble(dataGridView2.CurrentRow.Cells[1].Value) < Convert.ToDouble(dataGridView2.CurrentRow.Cells[2].Value))
            {
                MessageBox.Show("Az össz mennyiség nem lehet nagyobb a selejtezendő mennyiségnél !!");
                dataGridView2.CurrentRow.Cells[2].Value = "0";
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView2.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (label2.Text.Trim() == "db")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
                // only allow one decimal point 
                if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }
        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                dataGridView2.EndEdit();
                e.Handled = true;
                if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["mennyDataGridViewTextBoxColumn"].Value) != ossz)
                {
                    MessageBox.Show("Az össz mennyiség nem egyenlő a selejtezendő mennyiségel !!");
                    dataGridView2.Select();
                }
                else
                    button2.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.EndEdit();
            if (Convert.ToDouble(dataGridView1.CurrentRow.Cells["mennyDataGridViewTextBoxColumn"].Value) != ossz)
            {
                MessageBox.Show("Az össz mennyiség nem egyenlő a selejtezendő mennyiségel !!");
                dataGridView2.Select();
            }
            else
                Selejtez();
        }

        private void Selejtez()
        {
            dataGridView1.EndEdit();
            dataGridView2.EndEdit();
            SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
            connection.Open();
            SqlCommand mySqlCommand = connection.CreateCommand();


            mySqlCommand.CommandText = " update Selejt set Status='0',Sel_datum=@pontosido,Dolgozo=@pecset,Jelol='N' where Sorszam=@Sorszam ";
            mySqlCommand.Parameters.Clear();
            mySqlCommand.Parameters.Add("@Sorszam", SqlDbType.Int);
            mySqlCommand.Parameters["@Sorszam"].Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells["sorszamDataGridViewTextBoxColumn"].Value.ToString().Trim());
            mySqlCommand.Parameters.Add("@pontosido", SqlDbType.DateTime);
            mySqlCommand.Parameters["@pontosido"].Value = DateTime.Now;
            mySqlCommand.Parameters.Add("@pecset", SqlDbType.NVarChar);
            mySqlCommand.Parameters["@pecset"].Value = pecset;
            mySqlCommand.ExecuteNonQuery();
            connection.Close();

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (Convert.ToDouble(this.dataGridView2.Rows[i].Cells[2].Value) != 0)
                {
                    string datum = DateTime.Now.ToString("yyyy-MM-dd");
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml("<msg:Msg xsi:schemaLocation='http://Epicor.com/Message/2.0 http://scshost/schemas/epicor/ScalaMessage.xsd' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:msg='http://Epicor.com/Message/2.0'>" +
             "<msg:Hdr>" +
             "<msg:Sender>" +
             "<msg:Name>03</msg:Name>" +
             "<msg:Subname>{0}</msg:Subname>" +
             "</msg:Sender>" +
             "</msg:Hdr>" +
             "<msg:Body>" +
             "<msg:Req msg-type='Stock Transaction' action='Process'>" +
             "<msg:Dta>" +
             "<dta:StockTransaction xsi:schemaLocation='http://www.scala.net/StockTransaction/1.1 http://scshost/schemas/Scala/1.1/StockTransaction.xsd' xmlns:msg='http://Epicor.com/InternalMessage/1.1' xmlns:dta='http://www.scala.net/StockTransaction/1.1'>" +
             "<dta:Movement>" +
             "<dta:TransDate>" + datum + "</dta:TransDate>" +
             "<dta:Qty>" + dataGridView2.Rows[i].Cells[2].Value.ToString().Trim() + "</dta:Qty>" +
             "<dta:StockCode>" + dataGridView1.CurrentRow.Cells["cikkszamDataGridViewTextBoxColumn"].Value.ToString() + "</dta:StockCode>" +
             "<dta:WhCodeFrom>01</dta:WhCodeFrom>" +
             "<dta:BinCodeFrom>" + dataGridView2.Rows[i].Cells[0].Value.ToString().Trim() + "</dta:BinCodeFrom>" +
             "<dta:WhCodeTo>SE</dta:WhCodeTo>" +
             "<dta:BinCodeTo>STDSE</dta:BinCodeTo>" +
             "<dta:Ref>SELEJT</dta:Ref>" +
                        //"<dta:OrdNum>" + MRend.Trim() + "</dta:OrdNum>" +
             "<dta:Note>TM</dta:Note>" +
                "</dta:Movement>" +
                "</dta:StockTransaction>" +
                "</msg:Dta>" +
                "</msg:Req>" +
             "</msg:Body>" +
             "</msg:Msg>");
                    // Save the document to a file.
                    string f_nev = "SEAV" + dataGridView1.CurrentRow.Cells["cikkszamDataGridViewTextBoxColumn"].Value.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                   // doc.Save(f_nev);
                    doc.Save(@"\\10.0.0.11\inputxml\" + f_nev);
                   //Thread.Sleep(2000);
                   }
            }
            this.Close();
            Form12 form12 = new Form12();
            form12.ShowDialog();
        } 
        
    
    }
}
