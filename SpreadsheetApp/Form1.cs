using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {
        int rows, cols, threds, oper, sleep;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rows = int.Parse(rows_textBox.Text);
            cols = int.Parse(col_textBox.Text);
            threds = int.Parse(user_textBox.Text);
            oper = int.Parse(oper_textBox.Text);
            sleep = int.Parse(sleep_textBox.Text);
            SharableSpreadSheet spreadSheet = new SharableSpreadSheet(rows, cols, threds);
            Program.Simulator(rows,cols,threds,oper,sleep, spreadSheet);
            dataGridView1.DataSource = spreadSheet;
        }
    }
}
