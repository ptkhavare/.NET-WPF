using System.Windows;

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SinisterBtnClick(object sender, RoutedEventArgs e)
        {
            englishTranslationLabel.Content = "Left";
        }
        private void DexterBtnClick(object sender, RoutedEventArgs e)
        {
            englishTranslationLabel.Content = "Right";
        }
        private void MediumBtnClick(object sender, RoutedEventArgs e)
        {
            englishTranslationLabel.Content = "Center";
        }
        private void ClearBtnClick(object sender, RoutedEventArgs e)
        {
            englishTranslationLabel.Content = "";
        }
    }
}
