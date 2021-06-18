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
    public partial class Form10 : Form
    {
        public string pecset,Polc;
        public Form10()
        {
            InitializeComponent();
            dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
            this.dataGridView1.SelectionChanged += new System.EventHandler(dataGridView1_SelectionChanged);
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.VF_SC360300_StockBinNo' table. You can move, or remove it, as needed.
            this.vF_SC360300_StockBinNoTableAdapter.Fill(this.dataSet1.VF_SC360300_StockBinNo);
            this.selejtTableAdapter.Visszmenny(this.dataSet1.Selejt, "0");
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
        }
     
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          if (Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value) != 0)
                this.dataGridView1.Rows[e.RowIndex].Cells["Column1"].Style.BackColor = Color.Plum;
            else
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           if (Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["mennyDataGridViewTextBoxColumn"].Value) < Convert.ToDouble(this.dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value))
            {
                MessageBox.Show("A Visszaforgatandó mennyiség nem lehet nagyobb a selejtezett mennyiségnél !!");
                 this.dataGridView1.CurrentCell.Value="0";
            }
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
            this.selejtTableAdapter.Visszmenny(this.dataSet1.Selejt, "0");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            dataGridView1.Visible = false;
            SqlConnection connection = new SqlConnection("Data Source=SCALA1;Initial Catalog=Fusetech;Persist Security Info=True;User ID=termelesmonitor;Password=TERM123");
            connection.Open();
            SqlCommand mySqlCommand = connection.CreateCommand();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToDouble(this.dataGridView1.Rows[i].Cells["Column1"].Value) != 0 )
                {
                    mySqlCommand.CommandText = " update Selejt set Megjegyz=@Megjegyz,VisszMenny=@Visszmenny where Sorszam=@Sorszam ";
                    mySqlCommand.Parameters.Clear();
                    mySqlCommand.Parameters.Add("@Sorszam", SqlDbType.Int);
                    mySqlCommand.Parameters["@Sorszam"].Value = Convert.ToInt32(dataGridView1.Rows[i].Cells["sorszamDataGridViewTextBoxColumn"].Value.ToString().Trim());
                    mySqlCommand.Parameters.Add("@Visszmenny", SqlDbType.Decimal);
                    mySqlCommand.Parameters["@Visszmenny"].Value = Convert.ToDouble(this.dataGridView1.Rows[i].Cells["Column1"].Value.ToString());
                    mySqlCommand.Parameters.Add("@Megjegyz", SqlDbType.NVarChar);
                    string megj = Convert.ToString(dataGridView1.Rows[i].Cells["megjegyzDataGridViewTextBoxColumn"].Value);
                    if (String.IsNullOrEmpty(megj))
                        mySqlCommand.Parameters["@Megjegyz"].Value = " ";
                    else
                        mySqlCommand.Parameters["@Megjegyz"].Value = dataGridView1.Rows[i].Cells["megjegyzDataGridViewTextBoxColumn"].Value.ToString().Trim();
                    mySqlCommand.ExecuteNonQuery();

                    if (dataGridView1.Rows[i].Cells["Polcok"].Value ==null)
                        Polc = "STD01";
                    else
                        Polc = dataGridView1.Rows[i].Cells["Polcok"].Value.ToString().Trim().ToUpper();
                 
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
                    "<dta:Qty>" + Convert.ToDouble(this.dataGridView1.Rows[i].Cells["Column1"].Value) + "</dta:Qty>" +
                    "<dta:StockCode>" + dataGridView1.Rows[i].Cells["cikkszamDataGridViewTextBoxColumn"].Value.ToString().Trim() + "</dta:StockCode>" +
                    "<dta:WhCodeFrom>SE</dta:WhCodeFrom>" +
                    "<dta:BinCodeFrom>STDSE</dta:BinCodeFrom>" +
                    "<dta:WhCodeTo>01</dta:WhCodeTo>" +
                    "<dta:BinCodeTo>"+Polc+"</dta:BinCodeTo>" +
                    "<dta:Ref>SE_VI</dta:Ref>" +
                        //"<dta:OrdNum>" + MRend.Trim() + "</dta:OrdNum>" +
                    "<dta:Note>TM</dta:Note>" +
                    "</dta:Movement>" +
                    "</dta:StockTransaction>" +
                    "</msg:Dta>" +
                    "</msg:Req>" +
                    "</msg:Body>" +
                    "</msg:Msg>");
                    // Save the document to a file.
                    string f_nev = "SETV" + dataGridView1.Rows[i].Cells["cikkszamDataGridViewTextBoxColumn"].Value.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                //  doc.Save(f_nev);
                    doc.Save(@"\\10.0.0.11\inputxml\" + f_nev);
                   // Thread.Sleep(2000);
              }
            }
            connection.Close();
            //   Thread.Sleep(5000);
            Form12 form12 = new Form12();
            form12.ShowDialog();
            dataSet1.Selejt.Clear();
            this.selejtTableAdapter.Visszmenny(this.dataSet1.Selejt, "0");
            dataGridView1.Visible = true;
        }


        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 5) //Desired Column
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
            if (dataGridView1.CurrentRow.Cells["meegysDataGridViewTextBoxColumn"].Value.ToString().Trim() == "db")
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
                if (e.KeyChar == '.' &&  (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
           
        }
    
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int[] sor = new int[dataGridView1.SelectedCells.Count];
            int sorindex = 0, i;
            double szam;
            double orm = 0, rm;
            double ogym = 0, gym;
                        
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {
                    i = sorindex - 1;
                    while (i > -1 && cell.RowIndex != sor[i]) i--;
                    if (i == -1)
                    {
                        if (double.TryParse(dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString(), out szam))
                        {
                            double.TryParse(dataGridView1.Rows[cell.RowIndex].Cells["mennyDataGridViewTextBoxColumn"].Value.ToString(), out rm);
                            if (dataGridView1.Rows[cell.RowIndex].Cells["Column1"].Value == "" || dataGridView1.Rows[cell.RowIndex].Cells["Column1"].Value == null)
                                gym = 0;
                              
                            else
                                double.TryParse(dataGridView1.Rows[cell.RowIndex].Cells["Column1"].Value.ToString(), out gym);
                            orm += rm;
                            ogym += gym;
                            toolStripStatusLabel3.Text = orm.ToString("N0");
                           toolStripStatusLabel5.Text = ogym.ToString("N0");
                        }
                        sor[sorindex] = cell.RowIndex;
                        sorindex++;
                    }

                }
        }


    
    
    }
}
