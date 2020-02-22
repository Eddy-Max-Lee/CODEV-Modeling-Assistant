using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.Data.SqlClient; //取得SqlClient相關物件必須的

using System.Globalization;

namespace Offner_D
{
    public partial class Form1 : Form
    {

        public DataTableCollection tableCollection;
        public Form1()
        {
            InitializeComponent();
            
            //txtFilename.Text = openFileDialog.FileName;
            using (var stream = System.IO.File.Open(txtFilename.Text, System.IO.FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;

                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);//add sheet to combobox
                        }
                    }

            DataTable dt = tableCollection["Offner imaging design procedure"];
            dataGridView1.DataSource = dt;

        }




        private void button1_Click(object sender, EventArgs e)
        {



            //------------------------------------


            //DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()]; 這邊的加強版可以做旗標
            DataTable dt = tableCollection["Offner imaging design procedure"];

            richTextBox1.Text =CodeV.Part1+ 
                                     CodeV.Part2(textBox1.Text)+
                                     CodeV.Part3(textBox2.Text, textBox3.Text, textBox1.Text)+
                                     CodeV.Part4(dt.Rows[9][0].ToString(),
                                                              dt.Rows[30][4].ToString(), dt.Rows[31][4].ToString(),dt.Rows[32][4].ToString(), dt.Rows[33][4].ToString(),
                                                               dt.Rows[35][3].ToString(), dt.Rows[36][3].ToString(), dt.Rows[37][3].ToString(),
                                                               dt.Rows[39][3].ToString(), dt.Rows[40][3].ToString(), dt.Rows[41][3].ToString())+
                                    CodeV.Part5(dt.Rows[15][0].ToString())+
                                    CodeV.Part6(textBox1.Text);

            Clipboard.SetText(richTextBox1.Text); //複製到剪貼簿
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
           


            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter =""  })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using (var stream = System.IO.File.Open(openFileDialog.FileName, System.IO.FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                  
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);//add sheet to combobox
                        }
                    }
                }
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text!="" )
            {
                button1.Visible = true;
                if (int.Parse(textBox1.Text) <= 1)
                {
                    textBox2.Visible = false;
                    label2.Visible = false;
                }
                else
                {
                    textBox2.Visible = true;
                    label2.Visible = true;
                }
            }else
            {
                button1.Visible = false;

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
