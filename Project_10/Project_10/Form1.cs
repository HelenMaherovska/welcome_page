using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Project_10
{
    public partial class Form1 : Form
    {
        StreamReader rd = new StreamReader(@"C:\Users\ostap\Desktop\C# Programs 2-nd year\Project_10\Project_10\Text_test.txt");
        StreamWriter wr = new StreamWriter(@"C:\Users\ostap\Desktop\C# Programs 2-nd year\Project_10\Project_10\ResultFile.txt", false);
        DataSet ds = new DataSet();

        public Form1()
        {
           InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Download_btn_Click(object sender, EventArgs e)
        {
            ds.Tables.Add("Result");
            string header = rd.ReadLine();
            string[] number = System.Text.RegularExpressions.Regex.Split(header,",");
            
            for(int i=0;i<number.Length;i++)
            {
                ds.Tables[0].Columns.Add(number[i]);
            }

            string row = rd.ReadLine();

            while(row!=null)
            {
                string[] rvalue = System.Text.RegularExpressions.Regex.Split(row, ",");
                ds.Tables[0].Rows.Add(rvalue);
                row = rd.ReadLine();
            }

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                wr.WriteLine((ds.Tables[0].Rows[i][0]).ToString() + "\t" + (ds.Tables[0].Rows[i][1]).ToString() + "\t" + (ds.Tables[0].Rows[i][2]).ToString() + "\t" + (ds.Tables[0].Rows[i][3]).ToString());
            }

            wr.Close();

            //SaveFileDialog save = new SaveFileDialog();

            //save.Title = "Save File";
            //save.Filter = "Text file (*.txt)|*.txt|All Files(*.*)|*.*";

            //if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    StreamWriter write = new StreamWriter(File.Create(save.FileName));
            //    save.FileName = @"C:\Users\ostap\Desktop\C# Programs 2-nd year\Project_10\Project_10\ResultFile.txt";
            //    //write.Write(txt_Area.Text);
            //    write.Dispose();
            //} 
        }

        private void Sort_btn_Click(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            //bool r = false;
            //if (dataGridView1.RowCount != 0)
            //    if (textBox1.Text == "")
            //    {
            //        MessageBox.Show("You Didn't Input any data!!!");
            //    }
            //    else
            //    {
            //        for (int i = 0; i < dataGridView1.RowCount; i++)
            //        {
            //            if (string.Compare((ds.Tables[0].Rows[i][1]).ToString(), textBox1.Text, true) == 0)
            //            {
            //                r = true;
            //                string s = ds.Tables[0].Rows[i][0].ToString() + " " + ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i][2].ToString() + " " + ds.Tables[0].Rows[i][3].ToString();
            //                MessageBox.Show(s);
            //                break;
            //            }

            //        }
            //        if (!r)
            //        {
            //            MessageBox.Show("Didn't find anything!!!");
            //        }
            //    }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
