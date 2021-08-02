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
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace eLink_Section_1
{
    public partial class Form1 : Form
    {
        List<ulong> a = new List<ulong>();
        List<double> b = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            FileInfo info = new FileInfo("Section_1.xlsx");

            using (ExcelPackage xlPackage = new ExcelPackage(info))
            {
                loadButton.Text = "Loading...";
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets[0];

                for (int iCol = 1; iCol <=2; iCol++)
                {
                    for (int iRow = 1; true; iRow++)
                    {
                        if (worksheet.GetValue(iRow, iCol)==null || string.IsNullOrWhiteSpace(worksheet.GetValue(iRow, iCol).ToString()))
                            break;
                        if (iCol == 1 && iRow > 1)
                        {
                            a.Add(ulong.Parse(worksheet.GetValue(iRow, iCol).ToString()));
                        }
                        else if (iCol == 2 && iRow > 1)
                        {
                            b.Add((double)worksheet.GetValue(iRow, iCol));
                        }

                    }
                }
                loadButton.Text = "Loaded";
            }
        }

        private void visualizeButton_Click(object sender, EventArgs e)
        {
            loadButton.Text = "Load";
            showTable();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            for(int i=0; i<a.Count; i++)
            {
                a[i] *= a[i];
                b[i] *= b[i];
            }

            showTable();
        }

        private void showTable()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("a", "a");
            dataGridView1.Columns.Add("b", "b");
            dataGridView1.Rows.Clear();
            for (int i = 0; i < a.Count; i++)
            {
                dataGridView1.Rows.Add(a[i], b[i]);
            }
        }
    }
}
