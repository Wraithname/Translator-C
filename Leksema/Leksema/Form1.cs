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

namespace Leksema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            EditingText.Text = SaveLoad.Load();
        }

        private void SaveInFile_Click(object sender, EventArgs e)
        {
            SaveLoad.Save(EditingText.Text);
        }

        private void ActivateTranslater_Click(object sender, EventArgs e)
        {
            string str;
            str = EditingText.Text+'\0';
            char[] arr;
            arr = str.ToCharArray();
            Leksems gr = new Leksems();
            Form2 gh = new Form2();
            gh.dataGridView1.Rows.Clear();
            gh.dataGridView2.Rows.Clear();
            gh.dataGridView3.Rows.Clear();
            gh.dataGridView4.Rows.Clear();
            gh.dataGridView5.Rows.Clear();
            gh.Show();
            gr.analysis(arr,gh.dataGridView1,gh.textBox1,gh.dataGridView2,gh.dataGridView3);
            gr.deleteElements(gh.dataGridView2, gh.dataGridView4);
            gr.deleteElements1(gh.dataGridView3, gh.dataGridView5);
            gr.sum1(gh.dataGridView4,gh.textBox1);
            gr.sum2(gh.dataGridView5,gh.textBox2);
        }
    }
}
