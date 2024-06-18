using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

/*
 *  
        <Image HorizontalAlignment="Left" Height="166" Margin="258,0,0,0" VerticalAlignment="Center" Width="242">
            <Image.Source>
                <BitmapImage DecodePixelWidth="300" UriSource="iamge/2.png" />
            </Image.Source>
            <Image.Effect>
                <local:RippleEffectShader Center="0.5,0.5" Time="{Binding ElementName=MainWindow, Path=CurrentTime}" Amplitude="0.05" Frequency="20"/>
            </Image.Effect>
        </Image>
 */
namespace RippleEffect
{
    public partial class MainWindow : Window
    {

        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(16); // ~60 FPS
            _timer.Tick += OnTimerTick;
            _timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
           // RippleEffect.Time += 0.1;
        }

    }
}
