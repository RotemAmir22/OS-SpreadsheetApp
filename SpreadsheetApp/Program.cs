using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpreadsheetApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static Random random = new Random();
        public static string GenerateRandomCharacter()
        {
            int range1Min = 65;  // ASCII range for uppercase letters
            int range1Max = 90;
            int range2Min = 97;  // ASCII range for lowercase letters
            int range2Max = 122;

            // Randomly select one of the two ranges
            int selectedRange = random.Next(0, 2);

            // Generate a random integer within the selected range
            int randomNum;
            if (selectedRange == 0)
                randomNum = random.Next(range1Min, range1Max + 1);
            else
                randomNum = random.Next(range2Min, range2Max + 1);

            // Convert the integer to its corresponding ASCII character
            char randomChar = (char)randomNum;

            return randomChar.ToString();
        }

        public static void Simulator(int row, int col ,SharableSpreadSheet spreadSheet)
        {
            //SharableSpreadSheet.SharableSpreadSheet spreadSheet = new SharableSpreadSheet.SharableSpreadSheet(row, col, nThreads);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    string randomStr = GenerateRandomCharacter() + GenerateRandomCharacter() + GenerateRandomCharacter();
                    spreadSheet.dataTable.Rows[i][j] = randomStr;
                }
            }
            Console.ReadLine();
        }  

    }
}
