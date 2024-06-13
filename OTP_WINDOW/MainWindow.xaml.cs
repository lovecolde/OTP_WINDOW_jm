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

namespace OTP_WINDOW
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new IntroPage());
        }

        private void OTP_LOGO_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new IntroPage());
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // START 버튼 클릭 시 동작 정의
            MainFrame.Navigate(new StartPage());
        }

        private void Chapter1Button_Click(object sender, RoutedEventArgs e)
        {
            // Chapter 1 버튼 클릭 시 동작 정의
            MainFrame.Navigate(new Chap1_0());
        }

        private void Chapter2Button_Click(object sender, RoutedEventArgs e)
        {
            // Chapter 2 버튼 클릭 시 동작 정의
            MainFrame.Navigate(new Chap2_0());
        }

        private void Chapter3Button_Click(object sender, RoutedEventArgs e)
        {
            // Chapter 3 버튼 클릭 시 동작 정의
            MainFrame.Navigate(new Chap3());
        }

        private void Chapter4Button_Click(object sender, RoutedEventArgs e)
        {
            // Chapter 4 버튼 클릭 시 동작 정의
            //MainFrame.Navigate(new Chap4());
        }
    }
}
