using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortingVisualizer
{
    public partial class MainWindow : Window
    {
        static bool diff = false;

        static float[] data = [];
        static float[] prevData = [];
        static int speed = 50;
        static int count = 0;
        static double stapleWidth;
        static double stapleMargin;

        readonly static SolidColorBrush whiteBrush = new(Colors.White);
        readonly static SolidColorBrush redBrush = new(Colors.Red);
        readonly static SolidColorBrush greenBrush = new(Colors.LimeGreen);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClipCanvas()
        {
            Rect canvasRectangle = new(-1, -1, VisualizerCanvas.ActualWidth + 2, VisualizerCanvas.ActualHeight + 2);
            RectangleGeometry canvasGeometry = new(canvasRectangle, 20, 20);
            VisualizerCanvas.Clip = canvasGeometry;
        }

        private void InitializeData()
        {
            data = new float[(int)SizeSlider.Value];

            SetStapleWidth();

            Random rand = new();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rand.NextSingle();
            }
            CopyData();

            UpdateCanvas();
        }

        static private void CopyData()
        {
            prevData = new float[data.Length];
            Array.Copy(data, prevData, data.Length);
        }

        private void SetStapleWidth()
        {
            double canvasWidth = VisualizerCanvas.ActualWidth;

            if (data.Length < 201)
            {
                stapleWidth = canvasWidth / data.Length * 0.90;
                stapleMargin = canvasWidth / data.Length * 0.1;
            }
            else
            {
                stapleWidth = VisualizerCanvas.ActualWidth / data.Length;
                stapleMargin = 0;
            }
        }

        private void UpdateCanvas()
        {
            VisualizerCanvas.Children.Clear();

            double positionX = 0;
            double stapleRadius = stapleWidth * 0.6;

            diff = false;

            for (int i = 0; i < data.Length; i++)
            {
                SolidColorBrush stapleBrush;

                if (data[i] == prevData[i])
                {
                    stapleBrush = whiteBrush;
                }
                else
                {
                    stapleBrush = redBrush;
                    diff = true;
                }

                Border staple = new()
                {
                    Background = stapleBrush,
                    Width = stapleWidth,
                    Height = (int)VisualizerCanvas.ActualHeight * data[i],
                    CornerRadius = new(stapleRadius, stapleRadius, 0, 0),
                };
                VisualizerCanvas.Children.Add(staple);
                Canvas.SetBottom(staple, 0);
                Canvas.SetLeft(staple, positionX);
                positionX += stapleWidth + stapleMargin;
            }
        }

        private async void DisplayCompletion()
        {
            await Task.Delay(200);
            for (int i = 0; i < data.Length * 1.5; i++)
            {
                int startIndex = i - data.Length / 2;
                int endIndex = i;

                if (startIndex >= 0 && startIndex < data.Length)
                {
                    Border startStaple = (Border)VisualizerCanvas.Children[startIndex];
                    startStaple.Background = whiteBrush;
                }

                if (i < data.Length)
                {
                    Border endStaple = (Border)VisualizerCanvas.Children[endIndex];
                    endStaple.Background = greenBrush;
                }

                await Task.Delay(600 / data.Length);
            }
        }

        private void Sort()
        {
            switch (AlgorithmComboBox.Text)
            {
                case "Quicksort":
                    Quicksort();
                    break;
                case "Bubble sort":
                    BubbleSort();
                    break;
                case "Stooge sort":
                    StoogeSort();
                    break;
                default:
                    MessageBox.Show("Please select an algorithm");
                    break;
            }
        }

        private async void Quicksort()
        {
            Stack<int> stack = new();
            stack.Push(0);
            stack.Push(data!.Length - 1);

            while (stack.Count > 0)
            {
                int high = stack.Pop();
                int low = stack.Pop();

                if (low < high)
                {
                    int partitionIndex = Partition(low, high);

                    stack.Push(low);
                    stack.Push(partitionIndex - 1);

                    stack.Push(partitionIndex + 1);
                    stack.Push(high);
                }

                UpdateCanvas();
                CopyData();
                if (diff) await Task.Delay(speed);
            }

            if (data.Length > 200)
            {
                UpdateCanvas();
                CopyData();
            }
            DisplayCompletion();

            static int Partition(int low, int high)
            {
                float pivot = data![high];
                int a = low - 1;

                for (int b = low; b <= high; b++)
                {
                    if (data[b] < pivot)
                    {
                        a++;
                        (data[b], data[a]) = (data[a], data[b]);
                    }
                }

                (data[high], data[a + 1]) = (data[a + 1], data[high]);

                return a + 1;
            }
        }

        private async void BubbleSort()
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        (data[j + 1], data[j]) = (data[j], data[j + 1]);
                        swapped = true;
                    }
                }

                UpdateCanvas();
                CopyData();

                if (diff) await Task.Delay(speed / 2);
                if (swapped == false) break;
            }

            DisplayCompletion();
        }

        private async void StoogeSort()
        {
            await RecursiveStoogeSort(0, data.Length - 1);
            CopyData();
            UpdateCanvas();
            DisplayCompletion();
        }

        private async Task RecursiveStoogeSort(int low, int high)
        {
            if (low >= high) return;

            if (data[low] > data[high])
            {
                (data[low], data[high]) = (data[high], data[low]);
                count++;

                if (count >= data.Length / 20)
                {
                    count = 0;
                    UpdateCanvas();
                    CopyData();
                    if (diff) await Task.Delay(speed);
                }
            }

            if (high - low + 1 > 2)
            {
                int third = (high - low + 1) / 3;
                await RecursiveStoogeSort(low, high - third);
                await RecursiveStoogeSort(low + third, high);
                await RecursiveStoogeSort(low, high - third);
            }
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            InitializeData();
            ClipCanvas();
        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetStapleWidth();
            UpdateCanvas();
            ClipCanvas();
        }

        private void OnSortClick(object sender, RoutedEventArgs e)
        {
            Sort();
        }

        private void OnResetClick(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }

        private void OnSizeValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VisualizerCanvas != null)
            {
                InitializeData();
            }
        }

        private void OnSpeedValueChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            switch (SpeedSlider.Value)
            {
                case 1:
                    speed = 400;
                    break;
                case 2:
                    speed = 200;
                    break;
                case 3:
                    speed = 100;
                    break;
                case 4:
                    speed = 50;
                    break;
                case 5:
                    speed = 25;
                    break;
            }
        }
    }
}