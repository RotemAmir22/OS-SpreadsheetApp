    using System;
using System.Collections.Generic;
using System.Data;
    using System.IO;
    using System.Threading;

    public class SharableSpreadSheet
    {
        public DataTable dataTable;
        public int nR;
        public int nC;

        public SharableSpreadSheet(int nRows, int nCols)
        {
            // Construct a nRows*nCols spreadsheet
            dataTable = new DataTable();
            nR = nRows;
            nC = nCols;

            // Add columns to the DataTable
            for (int col = 0; col < nCols; col++)
            {
                dataTable.Columns.Add(col.ToString(), typeof(string));
            }

            // Add rows to the DataTable
            for (int row = 0; row < nRows; row++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);
            }
        }

        public void Capitalize()
        {
            // Return the string at [row, col]
            for (int i=0; i<dataTable.Rows.Count; i++)
                for (int j = 0; j < dataTable.Columns.Count; j++)
                    dataTable.Rows[i][j] = dataTable.Rows[i][j].ToString().ToUpper();
            
        }

        public void Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    DataRow dataRow = dataTable.Rows[row];
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        string cellValue = dataRow[col].ToString();
                        writer.Write(cellValue);
                        if (col < dataTable.Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }
        }

        public void Load(string fileName)
        {  
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                dataTable.Clear();
                while ((line = reader.ReadLine()) != null)
                { 
                    string[] cellValues = line.Split(',');
                    DataRow dataRow = dataTable.Rows.Add();

                    for (int col = 0; col < cellValues.Length; col++)
                        dataRow[col] = cellValues[col].Trim();
                }
            }
        }
  
    }
