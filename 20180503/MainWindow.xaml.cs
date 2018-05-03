using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20180503
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // 讀取身高數值
            double value = Math.Round(HeightSlider.Value, 1);
            HeightNumber.Text = value.ToString();

            // 讓上方物件隨數值移動
            double v = (value / 200) * 350; // 將數值轉換 0~1 再調整
            Canvas.SetLeft(Height, v);

            // BMI
            double h = double.Parse(HeightNumber.Text);
            double w = double.Parse(WeightNumber.Text);
            double BMI = w / Math.Pow((h / 100), 2);

            // Split將數值分割
            string[] parts = Math.Round(BMI, 1).ToString().Split('.');
            
            BigNumber.Text = parts[0];
            if (parts.Length > 1)
                SmallNumber.Text = "."+parts[1];
            else
                SmallNumber.Text = ".0";


        }

        private void WeightSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // 讀取體重數值
            double value = Math.Round(WeightSlider.Value,1);
            WeightNumber.Text = value.ToString();

            // 隨數值移動方塊       
            double v = (value / 200) * 350;
            Canvas.SetLeft(Weight, v);

            // BMI
            double h = double.Parse(HeightNumber.Text);
            double w = double.Parse(WeightNumber.Text);
            double BMI = w / Math.Pow((h / 100), 2);

            // Split將數值分割
            string[] parts = Math.Round(BMI, 1).ToString().Split('.');

            BigNumber.Text = parts[0];
            if (parts.Length > 1)
                SmallNumber.Text = "." + parts[1];
            else
                SmallNumber.Text = ".0";
        }
    }
}
