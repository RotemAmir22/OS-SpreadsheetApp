    using System;
using System.Collections.Generic;
using System.Data;
    using System.IO;
    using System.Threading;

    public class SharableSpreadSheet
    {
        private readonly ReaderWriterLockSlim lockObject = new ReaderWriterLockSlim();
        public DataTable dataTable;
        public int nR;
        public int nC;

        public SharableSpreadSheet(int nRows, int nCols, int nUsers = -1)
        {
            // nUsers used for setConcurrentSearchLimit, -1 means no limit.
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

        public void SetCell(int row, int col, String str)
        {
            // Return the string at [row, col]
            lockObject.EnterWriteLock();
            try
            {
                dataTable.Rows[row][col] = str;
            
            }
            finally
            {
                lockObject.ExitWriteLock();
            }
        }

        public Tuple<int, int> getSize()
        {
            // return the size of the spreadsheet in nRows, nCols
            return Tuple.Create(nR, nC);
        }

        public void Save(string fileName)
        {
            lockObject.EnterReadLock();
            try
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
            finally
            {
                lockObject.ExitReadLock();
            }
        }

        public void Load(string fileName)
        {
            lockObject.EnterWriteLock();
            try
            {
                dataTable.Clear();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] cellValues = line.Split(',');
                        DataRow dataRow = dataTable.Rows.Add();

                        for (int col = 0; col < cellValues.Length; col++)
                        {
                            dataRow[col] = cellValues[col].Trim();
                        }
                    }
                }
            }
            finally
            {
                lockObject.ExitWriteLock();
            }
        }

        public void PrintDataTable()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }
        //done
    }
