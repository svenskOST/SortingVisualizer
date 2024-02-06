using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortingVisualizer
{
    public partial class MainWindow : Window
    {
        static int[]? data;
        static int speed = 50;
        static double stapleWidth;

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
            data = new int[10];
            stapleWidth = VisualizerCanvas.ActualWidth / data.Length;
            Random rand = new();

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rand.Next(0, (int) VisualizerCanvas.ActualHeight);
            }

            UpdateCanvas();
        }

        private void UpdateCanvas()
        {
            VisualizerCanvas.Children.Clear();

            double positionX = 0;
            for (int i = 0; i < data!.Length; i++)
            {
                Border staple = new()
                {
                    Background = new SolidColorBrush(Colors.White),
                    Width = stapleWidth,
                    Height = data[i],
                    CornerRadius = new(5, 5, 0, 0)
                };
                VisualizerCanvas.Children.Add(staple);
                Canvas.SetBottom(staple, 0);
                Canvas.SetLeft(staple, positionX);
                positionX += stapleWidth;
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

                    await Task.Delay(speed);
                    UpdateCanvas();
                }
            }

            static int Partition(int low, int high)
            {
                int pivot = data![high];
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

        private void BubbleSort()
        {

        }

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            InitializeData();
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
    }
}