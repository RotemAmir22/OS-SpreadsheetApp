using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SpreadsheetApp
{
    public partial class Form1 : Form
    {

        SharableSpreadSheet spreadSheet;
        public Form1()
        {
            InitializeComponent();
            spreadSheet = new SharableSpreadSheet(15, 8);
            dataGridView1.DataSource = spreadSheet.dataTable;
            Program.Simulator(15, 8, spreadSheet);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = "newFile_" + rows_textBox.Text + ".txt";
            if (File.Exists(name))
            {
                spreadSheet.Load(name);
                MessageBox.Show("Success", "Update!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else    
                MessageBox.Show("Cannot find this file", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            spreadSheet.Capitalize();
        }

        private void rows_textBox_TextChanged(object sender, EventArgs e)
        {

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
            string name = "newFile_" + rows_textBox.Text + ".txt";
            if (!File.Exists(name))
            {
                spreadSheet.Save(name);
                MessageBox.Show("Success", "Update!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("This number already taken!", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
