using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SortingVisualizer
{
    public partial class MainWindow : Window
    {
        static float[] data = [];
        static float[] prevData = [];
        static int speed = 50;
        static double stapleWidth;
        static double stapleMargin;

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

            for (int i = 0; i < data.Length; i++)
            {
                Border staple = new()
                {
                    Background = new SolidColorBrush(data[i] == prevData[i] ? Colors.White : Colors.Red),
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
                CopyData();

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

        private void BubbleSort()
        {

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
                    speed = 200;
                    break;
                case 2:
                    speed = 100;
                    break;
                case 3:
                    speed = 50;
                    break;
                case 4:
                    speed = 25;
                    break;
                case 5:
                    speed = 5;
                    break;
            }
        }
    }
}