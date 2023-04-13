using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_4_прак_2
{
    public partial class Form1 : Form
    {
        int int_row1, int_row2, int_col1, int_col2, colRes, rowRes, sumCell;

        bool firstMatrixSet = false, SecondMatrixSet = false;
        private void Button5_Click(object sender, EventArgs e)
        {
            secondMatrix.ColumnCount = 0;
            SecondMatrixSet = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (firstMatrixSet && SecondMatrixSet)
            {
                try
                {
                    if (int_col1 != int_row2) throw new ArgumentException("Кол-во столюцов в первой матрице должно быть равно числу строк во второй матрице");
                    resultMatrix.ColumnCount = 0;
                    resultMatrix.ColumnCount = int_col2;
                    for (int i = 0; i < int_row1; i++)
                    {
                        ArrayList row = new ArrayList();
                        for (int j = 0; j < int_col2; j++)
                        {
                            sumCell = 0;
                            for (int k = 0; k < int_row2; k++)
                            {
                                if(Convert.ToInt32(firstMatrix.Rows[i].Cells[k].Value) < 0) throw new ArgumentException($"Matrix1 contains an invalid entry in cell[{i}, {k}].");
                                if (Convert.ToInt32(secondMatrix.Rows[k].Cells[j].Value) < 0) throw new ArgumentException($"Matrix2 contains an invalid entry in cell[{k}, {j}].");
                                sumCell += Convert.ToInt32(firstMatrix.Rows[i].Cells[k].Value) * Convert.ToInt32(secondMatrix.Rows[k].Cells[j].Value);
                            }
                            row.Add(sumCell);
                            sumCell = 0;
                        }
                        resultMatrix.Rows.Add(row.ToArray());
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    return;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            firstMatrix.ColumnCount = 0;
            firstMatrixSet = false;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            secondMatrix.ColumnCount = 0;
            SecondMatrixSet = true;
            int_col2 = Convert.ToInt32(columns2.Text);
            int_row2 = Convert.ToInt32(raw2.Text);
            secondMatrix.ColumnCount = int_col2;
            for (int i = 0; i < int_row2; i++)
            {
                ArrayList row = new ArrayList();
                for (int j = 0; j < int_col2; j++)
                {
                    row.Add(rnd.Next(0, 100));
                }
                secondMatrix.Rows.Add(row.ToArray());
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            firstMatrix.ColumnCount = 0;
            firstMatrixSet = true;
            int_col1 = Convert.ToInt32(columns1.Text);
            int_row1 = Convert.ToInt32(raw1.Text);
            firstMatrix.ColumnCount = int_col1;
            for(int i = 0; i < int_row1; i++)
            {
                ArrayList row = new ArrayList();
                for (int j = 0; j < int_col1; j++)
                {
                    row.Add(rnd.Next(0, 100));
                }
                firstMatrix.Rows.Add(row.ToArray());

            }
        }
    }
}
