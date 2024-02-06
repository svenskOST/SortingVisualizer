using System.Drawing;
using System.Windows;

namespace SortingVisualizer
{
    public partial class MainWindow : Window
    {
        static int[]? data;
        static int speed = 50;
        static int? stapleWidth;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            data = new int[100];
            stapleWidth = (int) VisualizerCanvas.ActualWidth / data.Length;
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

            int positionX = 0;
            for (int i = 0; i < data!.Length; i++)
            {
                Rectangle rect = new();
                VisualizerCanvas.Children.Add(rect);
            }
        }
    }
}