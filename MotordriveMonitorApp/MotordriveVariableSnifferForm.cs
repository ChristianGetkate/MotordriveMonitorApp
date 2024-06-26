using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotordriveMonitorApp;

namespace MotordriveMonitorApp
{
    public partial class MotordriveVariableSnifferForm : Form
    {
        private TwinCATConnector connector = new TwinCATConnector();
        private Dictionary<string, uint> readvalues;

        // The array to compare against
        private uint[] compareArray = { 563, 51208, 51209, 35072, 35073 };
        public MotordriveVariableSnifferForm(string amsNetId, int port)
        {
            InitializeComponent();
            connector.Connect(amsNetId, port);

            for (int i = 0; i < 41; i++)
            {
                connector.AddReadValue($"MachineObjectsArray.MotorDrive[{i}].Communication.DriveStatusWord", typeof(uint));
            }
            dataGridView1.Columns.Add("MotorDrive", "MotorDrive");
            dataGridView1.Columns.Add("DriveStatusWord", "DriveStatusWord");
            dataGridView1.Columns.Add("Functional name", "Functional name");
            dataGridView1.Columns.Add("Motordrive ready", "Motordrive ready");
            dataGridView1.Columns[0].Width = 470;
            dataGridView1.Columns[2].Width = 150;

            dataGridView1.KeyDown += dataGridView1_KeyDown; // Add the KeyDown event handler
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteData();
                e.Handled = true;
            }
        }
        private void PasteData()
        {
            try
            {
                string clipboardText = Clipboard.GetText();
                string[] rows = clipboardText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                int currentRowIndex = dataGridView1.CurrentCell.RowIndex;
                int currentColumnIndex = dataGridView1.CurrentCell.ColumnIndex;

                foreach (string row in rows)
                {
                    // Skip adding new row at the end if row is empty and is the last one
                    if (row == string.Empty && currentRowIndex >= dataGridView1.Rows.Count - 1)
                        continue;

                    string[] cells = row.Split('\t');
                    for (int i = 0; i < cells.Length; i++)
                    {
                        if (currentColumnIndex + i < dataGridView1.Columns.Count)
                        {
                            dataGridView1[currentColumnIndex + i, currentRowIndex].Value = cells[i];
                        }
                    }
                    currentRowIndex++;
                    if (currentRowIndex >= dataGridView1.Rows.Count)
                    {
                        dataGridView1.Rows.Add();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error pasting data: " + ex.Message);
            }
        }

        //===================================================================================
        // This function adds readvalues to dataGridView1
        //===================================================================================
        private void AddRows()
        {
            // Save the current scroll position
            int firstDisplayedScrollingRowIndex = dataGridView1.FirstDisplayedScrollingRowIndex;

            // Clear the rows' values in the first two columns without resetting the scroll position
            dataGridView1.SuspendLayout();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = ""; // Clear first column
                row.Cells[1].Value = ""; // Clear second column
                row.Cells[3].Value = ""; // Clear second column
            }
            dataGridView1.ResumeLayout(false);

            // Add new rows with read values to the first two columns
            int rowIndex = 0;
            foreach (var kvp in readvalues)
            {
                bool isInArray = Array.Exists(compareArray, element => element == kvp.Value);
                string isInArrayString = isInArray.ToString().ToUpper();

                if (rowIndex < dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows[rowIndex].Cells[0].Value = kvp.Key;     // Update first column
                    dataGridView1.Rows[rowIndex].Cells[1].Value = kvp.Value;   // Update second column
                    dataGridView1.Rows[rowIndex].Cells[3].Value = isInArrayString;

                    rowIndex++;
                }
                else
                {
                    // Add new row if needed
                    dataGridView1.Rows.Add(kvp.Key, kvp.Value, "", isInArrayString); // Add third and fourth columns with values
                }
            }

            // Remove extra rows if any
            while (dataGridView1.Rows.Count > readvalues.Count)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }

            // Restore the scroll position if it was valid
            if (firstDisplayedScrollingRowIndex >= 0 &&
                firstDisplayedScrollingRowIndex < dataGridView1.RowCount)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = firstDisplayedScrollingRowIndex;
            }
        }
        private void MotordriveVariableSnifferForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //===================================================================================
        // This button starts the ReadCycle
        //===================================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            ReadCycle();
        }

        private async void ReadCycle()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    readvalues = connector.ReadValues();
                    Invoke(new Action(() => AddRows()));
                }
            });
        }
    }
}
