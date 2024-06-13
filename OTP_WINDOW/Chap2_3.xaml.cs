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
    /// Chap2_3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Chap2_3 : Page
    {
        public Chap2_3()
        {
            InitializeComponent();
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            Chap2_2 newPage = new Chap2_2();
            NavigationService.Navigate(newPage);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            Chap2_4 newPage = new Chap2_4();
            NavigationService.Navigate(newPage);
        }
    }
}
