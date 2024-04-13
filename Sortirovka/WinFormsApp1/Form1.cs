using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ��������� ������� ������� �� numericUpDown
            int arraySize = 100;

            // ��������� ������� ��������� �����
            Random random = new Random();
            int[] randomNumbers = new int[arraySize];
            int[] randomNumbers2 = new int[arraySize];
            int[] randomNumbers3 = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                int rnd = random.Next(0, 100);// ��������� ��������� ����� �� 0 �� 100
                randomNumbers[i] = rnd;
                randomNumbers2[i] = rnd;
                randomNumbers3[i] = rnd;
            }

            // ������� ListBox ����� ����������� ����� ���������
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

            // ���������� ��������� ������� � listView1
            foreach (var number in randomNumbers)
            {
                listView1.Items.Add(number.ToString());
            }

            Thread bubbleSortThread = new Thread(() => BubbleSort(randomNumbers, label3));
            bubbleSortThread.Start();

            Thread QuickSortThread = new Thread(() => QuickSort(randomNumbers2, label4));
            QuickSortThread.Start();

            Thread InsertionSortThread = new Thread(() => InsertionSort(randomNumbers3, label5));
            InsertionSortThread.Start();
        }
        private void UpdateLabelSafe(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => label.Text = text));
            }
            else
            {
                label.Text = text;
            }
        }
        private void UpdatelistViewSafe(ListView listView, int[] Numbers)
        {
            if (listView.InvokeRequired)
            {
                foreach (var number in Numbers)
                {

                    listView.Invoke(new Action(() => listView.Items.Add(number.ToString())));
                }
            }
            else
            {
                foreach (var number in Numbers)
                {
                    listView.Items.Add(number.ToString());
                }
            }
        }
        public void BubbleSort(int[] randomNumbers, Label BubbleLabel)
        {
            int n = randomNumbers.Length;
            int comparisonCount = 0; // ��� �������� ���������� ���������
            int swapCount = 0; // ��� �������� ���������� �������
            Stopwatch stopwatch = new Stopwatch(); // ������ ��� ��������� ������� ����������

            stopwatch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisonCount++; // ����������� ������� ���������
                    if (randomNumbers[j] > randomNumbers[j + 1])
                    {
                        // ������ �������� �������
                        int temp = randomNumbers[j];
                        randomNumbers[j] = randomNumbers[j + 1];
                        randomNumbers[j + 1] = temp;
                        swapCount++; // ����������� ������� �������
                    }
                }
            }

            stopwatch.Stop();

            // ������� ����������
            UpdateLabelSafe(BubbleLabel, $"���������: {comparisonCount}, �������: {swapCount}, �����: {stopwatch.ElapsedMilliseconds} ��");
            UpdatelistViewSafe(listView2, randomNumbers);
        }

        public void QuickSort(int[] randomNumbers, Label QuickLabel)
        {
            int comparisonCount = 0; // ��� �������� ���������� ���������
            int swapCount = 0; // ��� �������� ���������� �������
            Stopwatch stopwatch = new Stopwatch(); // ������ ��� ��������� ������� ����������

            stopwatch.Start();
            QuickSortHelper(randomNumbers, 0, randomNumbers.Length - 1, ref comparisonCount, ref swapCount);
            stopwatch.Stop();

            // ������� ����������
            UpdateLabelSafe(QuickLabel, $"���������: {comparisonCount}, �������: {swapCount}, �����: {stopwatch.ElapsedMilliseconds} ��");
            UpdatelistViewSafe(listView3, randomNumbers);
        }

        private void QuickSortHelper(int[] array, int low, int high, ref int comparisonCount, ref int swapCount)
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high, ref comparisonCount, ref swapCount);
                QuickSortHelper(array, low, pivot - 1, ref comparisonCount, ref swapCount);
                QuickSortHelper(array, pivot + 1, high, ref comparisonCount, ref swapCount);
            }
        }

        private int Partition(int[] array, int low, int high, ref int comparisonCount, ref int swapCount)
        {
            int pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                comparisonCount++;
                if (array[j] < pivot)
                {
                    i++;
                    swapCount++;
                    Swap(ref array[i], ref array[j]);
                }
            }
            swapCount++;
            Swap(ref array[i + 1], ref array[high]);
            return i + 1;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public void InsertionSort(int[] randomNumbers, Label InsertLabel)
        {
            int comparisonCount = 0; // ��� �������� ���������� ���������
            int swapCount = 0; // ��� �������� ���������� �������
            Stopwatch stopwatch = new Stopwatch(); // ������ ��� ��������� ������� ����������

            stopwatch.Start();

            for (int i = 1; i < randomNumbers.Length; i++)
            {
                int current = randomNumbers[i];
                int j = i - 1;

                // ���������� �������� randomNumbers[0..i-1], ������� ������, ��� current,
                // �� ���� ������� ������ �� �� �������� ���������
                while (j >= 0 && randomNumbers[j] > current)
                {
                    comparisonCount++;
                    randomNumbers[j + 1] = randomNumbers[j];
                    j--;
                    swapCount++;
                }
                randomNumbers[j + 1] = current;
            }

            stopwatch.Stop();

            // ������� ����������
            UpdateLabelSafe(InsertLabel, $"���������: {comparisonCount}, �������: {swapCount}, �����: {stopwatch.ElapsedMilliseconds} ��");
            UpdatelistViewSafe(listView4, randomNumbers);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
