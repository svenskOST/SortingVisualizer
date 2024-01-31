using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer
{
    public partial class MainForm : Form
    {
        static int[] data;
        private int PanelWidth { get; set; }
        private int PanelHeight { get; set; }
        private int RectWidth { get; set; }

        static int speed = 50;

        public MainForm()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            data = new int[SizeTrackBar.Value];
            Random rand = new Random();

            PanelWidth = VisualizerPanel.Width;
            PanelHeight = VisualizerPanel.Height;
            RectWidth = PanelWidth / data.Length;

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = rand.Next(0, PanelHeight);
            }

            VisualizerPanel.Invalidate();
        }

        private void RefreshFrame()
        {
            Graphics graphics = VisualizerPanel.CreateGraphics();
            int positionX = 0;
            for (int i = 0; i < data.Length; i++)
            {
                graphics.FillRectangle(new SolidBrush(Color.White), positionX, PanelHeight - data[i], RectWidth, data[i]);
                positionX += RectWidth;
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
            Stack<int> stack = new Stack<int>();
            stack.Push(0);
            stack.Push(data.Length - 1);

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
                    VisualizerPanel.Invalidate();
                }
            }

            int Partition(int low, int high)
            {
                int pivot = data[high];
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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (VisualizerPanel.Width < 1000)
            {
                SizeTrackBar.Maximum = 738;
                SizeTrackBar.Value = 200;
            }
            else
            {
                SizeTrackBar.Maximum = 1520;
                SizeTrackBar.Value = 400;
            }
            InitializeData();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            InitializeData();
        }

        private void SizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SizeLabel2.Text = SizeTrackBar.Value.ToString();
        }

        private void SpeedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            switch (SpeedTrackBar.Value)
            {
                case 0:
                    speed = 500;
                    break;
                case 1:
                    speed = 250;
                    break;
                case 2:
                    speed = 50;
                    break;
                case 3:
                    speed = 25;
                    break;
                case 4:
                    speed = 1;
                    break;
            }
        }

        private void VisualizerPanel_Paint(object sender, PaintEventArgs e)
        {
            RefreshFrame();
        }
    }
}