using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;


namespace Selejtezés
{
    public partial class Form7 : Form
    {
        public string pecset,cella="%";
       
        public Form7()
        {
            InitializeComponent();
            comboBox1.KeyPress += new KeyPressEventHandler(comboBox1_KeyPress);
           dataSet1.EnforceConstraints = false;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet11.VF_SY240300_Cells' table. You can move, or remove it, as needed.
            this.vF_SY240300_CellsTableAdapter.Fill(this.dataSet1.VF_SY240300_Cells);
         //    splitContainer1.Panel1Collapsed = false;
        //    splitContainer1.Panel2Collapsed = true;
           comboBox1.SelectedIndex = 0;
          }

       private void comboBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter || (int)e.KeyChar == (int)Keys.Tab)
            {
                if (comboBox1.Text == "")
                    comboBox1.Select();
                else
                    cella = comboBox1.Text.Trim();
                this.selejt1TableAdapter.Fill(this.dataSet1.Selejt1, cella);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Selejtezés.Report1.rdlc";
                this.reportViewer1.RefreshReport();
                button1.Select();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            autoprintme.Print();
            button1.Visible = false;
            button2.Select();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                comboBox1.Select();
            else
                cella = comboBox1.Text.Trim();
            this.selejt1TableAdapter.Fill(this.dataSet1.Selejt1, cella);
            reportViewer1.LocalReport.ReportEmbeddedResource = "Selejtezés.Report1.rdlc";
            this.reportViewer1.RefreshReport();
            button1.Visible = true;
            button1.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cella = "%";
            this.selejt1TableAdapter.Fill(this.dataSet1.Selejt1, cella);
            reportViewer1.LocalReport.ReportEmbeddedResource = "Selejtezés.Report1.rdlc";
            this.reportViewer1.RefreshReport();
            button1.Visible = true;
            button1.Select();
        }


   
    
    
    
    }
}
