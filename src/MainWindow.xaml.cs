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
            data = new int[100];
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

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            InitializeData();
            ClipCanvas();
        }
    }
}