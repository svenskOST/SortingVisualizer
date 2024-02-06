using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
                Rectangle rect = new()
                {
                    Fill = new SolidColorBrush(Colors.White),
                    Width = stapleWidth,
                    Height = data[i]
                };
                VisualizerCanvas.Children.Add(rect);
                Canvas.SetBottom(rect, 0);
                Canvas.SetLeft(rect, positionX);
                positionX += stapleWidth;
            }
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            InitializeData();
        }
    }
}