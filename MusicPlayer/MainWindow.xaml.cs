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
using Un4seen.Bass;
using WpfCustomControlLibrary.Controls;
using MusicPlayer.View;

namespace MusicPlayer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            BassNet.Registration("matheuslps@yahoo.com.br", "2X223282334337");
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
            {
                MessageBox.Show("Basssd" + Bass.BASS_ErrorGetCode().ToString());
            }
            Bass.BASS_PluginLoad("bass_ape.dll");   //可以再增加解码程序集，已支持更多格式
            Bass.BASS_PluginLoad("bassflac.dll");
            InitializeComponent();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void MinimizeCommand(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeCommand(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void WindowCloseCommand(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MusicButton_Click(object sender, RoutedEventArgs e)
        {
            MusicButton button = (MusicButton)sender;
            if (button.MusicIcon == "\ue76a")
                button.MusicIcon = "\ue74f";
            else
                button.MusicIcon = "\ue76a";
        }

    }
}
