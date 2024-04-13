using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private int[,] matrixA;
        private int[,] matrixB;
        private void button2_Click(object sender, EventArgs e)
        {
            CreateAndDisplayMatrix(10, 10, richTextBox1, out matrixA);
            // первые два аргумента - размерность матриц
            CreateAndDisplayMatrix(10, 10, richTextBox2, out matrixB);
        }
        private void CreateAndDisplayMatrix(int weight, int height, RichTextBox richTextBox, out int[,] matrix)
        {
            int rows = weight;
            int cols = height;
            Random random = new Random();
            StringBuilder matrixString = new StringBuilder();

            // Инициализация матрицы
            matrix = new int[rows, cols];

            // Генерация и заполнение матрицы
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(0, 100);
                    matrixString.Append(matrix[i, j] + "\t");
                }
                matrixString.AppendLine();
            }

            // Отображение в RichTextBox
            richTextBox.Text = matrixString.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Последовательное умножение
            var stopwatch = Stopwatch.StartNew();
            var resultSequential = SequentialMatrixMultiply(matrixA, matrixB);
            stopwatch.Stop();
            long sequentialTime = stopwatch.ElapsedMilliseconds;

            // Параллельное умножение
            stopwatch.Restart();
            var resultParallel = ParallelMatrixMultiply(matrixA, matrixB);
            stopwatch.Stop();
            long parallelTime = stopwatch.ElapsedMilliseconds;

            // Вывод результата и времени
            DisplayMatrix(resultParallel, richTextBox3); // Можно отобразить resultSequential для сравнения
            label2.Text = $"Последовательное: {sequentialTime} мс, Параллельное: {parallelTime} мс";
        }

        private int[,] SequentialMatrixMultiply(int[,] A, int[,] B)
        {
            int aRows = A.GetLength(0);
            int aCols = A.GetLength(1);
            int bCols = B.GetLength(1);
            var result = new int[aRows, bCols];

            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    for (int k = 0; k < aCols; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return result;
        }

        private int[,] ParallelMatrixMultiply(int[,] A, int[,] B)
        {
            int aRows = A.GetLength(0);
            int bCols = B.GetLength(1);
            var result = new int[aRows, bCols];
            //Parallel.For, который является частью TPL (Task Parallel Library) и обеспечивает параллельное выполнение, но не использует класс Task напрямую.
            Parallel.For(0, aRows, i =>
            {
                for (int j = 0; j < bCols; j++)
                {
                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }
                }
            });

            return result;
        }

        private void DisplayMatrix(int[,] matrix, RichTextBox richTextBox)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    builder.Append(matrix[i, j] + "\t");
                }
                builder.AppendLine();
            }

            richTextBox.Text = builder.ToString();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
