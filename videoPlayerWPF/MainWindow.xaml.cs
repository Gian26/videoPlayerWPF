using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace videoPlayerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        private bool fullScreen;
        private double currentposition;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
            // Initialize the MediaElement property values.
            InitializePropertyValues();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if ((Player.Source != null) && (Player.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = Player.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = Player.Position.TotalSeconds;
            }
        }


        private void Media_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                AddExtension = true,
                DefaultExt = "*.*",
                Filter = "Media(*.*)|*.*"
            };
            ofd.ShowDialog();
            //Player.MediaOpened += new RoutedEventHandler(Player_MediaOpened);
            Player.Source = new Uri(ofd.FileName);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Player.Pause();
        }

        private void Player_MediaOpened(object sender, RoutedEventArgs e)
        {
           // MediaName.Content = Player.Source.ToString();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Player.Play();

        }

        private void SliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void SliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            Player.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void SliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        // Change the volume of the media.
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            Player.Volume = (double)volumeSlider.Value;
        }

        // When the media opens, initialize the "Seek To" slider maximum value
        // to the total number of miliseconds in the length of the media clip.
        private void Element_MediaOpened(object sender, EventArgs e)
        {

            //timelineSlider.Maximum = Player.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        // When the media playback is finished. Stop() the media to seek to media start.
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            Player.Stop();
        }


        // Change the speed of the media.
        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            //Player.SpeedRatio = (double)speedRatioSlider.Value;
        }

        void InitializePropertyValues()
        {
            // Set the media's starting Volume and SpeedRatio to the current value of the
            // their respective slider controls.
            Player.Volume = (double)volumeSlider.Value;
            //Player.SpeedRatio = (double)speedRatioSlider.Value;
        }
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Player.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        private void Full_Click(object sender, RoutedEventArgs e)
        {
            if (!fullScreen)
            {

                var child = Player;
                var parent = VisualTreeHelper.GetParent(child);
                var parentAsPanel = parent as Panel;
                if (parentAsPanel != null)
                {
                    parentAsPanel.Children.Remove(child);
                }
                var parentAsContentControl = parent as ContentControl;
                if (parentAsContentControl != null)
                {
                    parentAsContentControl.Content = null;
                }
                var parentAsDecorator = parent as Decorator;
                if (parentAsDecorator != null)
                {
                    parentAsDecorator.Child = null;
                }


                this.Background = new SolidColorBrush(Colors.Black);
                this.Content = Player;
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;

                Player.Position = TimeSpan.FromSeconds(currentposition = 0);
            }
            else {
                this.Background = new SolidColorBrush(Colors.White);
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                Player.Position = TimeSpan.FromSeconds(currentposition = 0);
            }
            fullScreen = !fullScreen;

        }
    }
}
