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
            // Получение размера массива из numericUpDown
            int arraySize = 100;

            // Генерация массива случайных чисел
            Random random = new Random();
            int[] randomNumbers = new int[arraySize];
            int[] randomNumbers2 = new int[arraySize];
            int[] randomNumbers3 = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                int rnd = random.Next(0, 100);// Генерация случайных чисел от 0 до 100
                randomNumbers[i] = rnd;
                randomNumbers2[i] = rnd;
                randomNumbers3[i] = rnd;
            }

            // Очистка ListBox перед добавлением новых элементов
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();

            // Добавление элементов массива в listView1
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
            int comparisonCount = 0; // Для подсчета количества сравнений
            int swapCount = 0; // Для подсчета количества обменов
            Stopwatch stopwatch = new Stopwatch(); // Таймер для измерения времени выполнения

            stopwatch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisonCount++; // Увеличиваем счетчик сравнений
                    if (randomNumbers[j] > randomNumbers[j + 1])
                    {
                        // Меняем элементы местами
                        int temp = randomNumbers[j];
                        randomNumbers[j] = randomNumbers[j + 1];
                        randomNumbers[j + 1] = temp;
                        swapCount++; // Увеличиваем счетчик обменов
                    }
                }
            }

            stopwatch.Stop();

            // Выводим результаты
            UpdateLabelSafe(BubbleLabel, $"Сравнений: {comparisonCount}, Обменов: {swapCount}, Время: {stopwatch.ElapsedMilliseconds} мс");
            UpdatelistViewSafe(listView2, randomNumbers);
        }

        public void QuickSort(int[] randomNumbers, Label QuickLabel)
        {
            int comparisonCount = 0; // Для подсчета количества сравнений
            int swapCount = 0; // Для подсчета количества обменов
            Stopwatch stopwatch = new Stopwatch(); // Таймер для измерения времени выполнения

            stopwatch.Start();
            QuickSortHelper(randomNumbers, 0, randomNumbers.Length - 1, ref comparisonCount, ref swapCount);
            stopwatch.Stop();

            // Выводим результаты
            UpdateLabelSafe(QuickLabel, $"Сравнений: {comparisonCount}, Обменов: {swapCount}, Время: {stopwatch.ElapsedMilliseconds} мс");
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
            int comparisonCount = 0; // Для подсчета количества сравнений
            int swapCount = 0; // Для подсчета количества обменов
            Stopwatch stopwatch = new Stopwatch(); // Таймер для измерения времени выполнения

            stopwatch.Start();

            for (int i = 1; i < randomNumbers.Length; i++)
            {
                int current = randomNumbers[i];
                int j = i - 1;

                // Перемещаем элементы randomNumbers[0..i-1], которые больше, чем current,
                // на одну позицию вперед от их текущего положения
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

            // Выводим результаты
            UpdateLabelSafe(InsertLabel, $"Сравнений: {comparisonCount}, Обменов: {swapCount}, Время: {stopwatch.ElapsedMilliseconds} мс");
            UpdatelistViewSafe(listView4, randomNumbers);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
