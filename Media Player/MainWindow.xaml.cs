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
using System.Windows.Threading;
using MahApps.Metro.Controls;
using System.Windows.Controls.Primitives;
using System.IO;

namespace MediaPlayer
{
    
    public partial class MainWindow : MetroWindow
    {
        DispatcherTimer timer = new DispatcherTimer();
        bool dragStarted = false, volDragStarted = false;
        double vol = 0;
        List<string> filenames = new List<string>();
        int playIndex = -1;
        MediaElement meOld;

        public MainWindow()
        {
            InitializeComponent();
            setIcon();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(timer_Tick);
            sliVol.Value = 100;
            mePlayer.Volume = (double)sliVol.Value / 100;
            maFlyout.FontSize = 16;
        }

        private void setIcon()
        {
            string dir = Directory.GetCurrentDirectory();
            if (dir.Contains("bin"))
            {
                dir = dir.Remove(dir.LastIndexOf('\\'));
                dir = dir.Remove(dir.LastIndexOf('\\'));
            }
            Uri iconUri = new Uri(dir+ "/windows_media_player.png", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            sliSeek.Value = mePlayer.Position.TotalSeconds;
            lblSeek.Content = mePlayer.Position.ToString(@"hh\:mm\:ss");
        }

        private void btnPlayPause_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (filenames.Count != 0 && mePlayer.Source != null)
            {
                if (btn.Content.Equals("Play"))
                {
                    mePlayer.Play();
                    timer.Start();
                    btn.Content = "Pause";
                }
                else if (btn.Content.Equals("Pause"))
                {
                    mePlayer.Pause();
                    timer.Stop();
                    btn.Content = "Play";
                }
            }
            else
            {
                MessageBox.Show("Please drag and drop medias to play");
            } 
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (mePlayer.Source != null)
            {
                mePlayer.Stop();
                timer.Stop();
                btnPlayPause.Content = "Play";
                sliSeek.Value = 0;
                lblSeek.Content = "00:00:00";
            }
            else
            {
                MessageBox.Show("There is no medias to stop");
            } 
        }

        private void sliVol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!volDragStarted)
            {
                mePlayer.Volume = (double)sliVol.Value / 100;

                if (sliVol.Value > 0)
                    tBtnMute.IsChecked = false;
                else
                    tBtnMute.IsChecked = true;
            }
        }

        private void MySlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.dragStarted = false;
            mePlayer.Position = TimeSpan.FromSeconds(sliSeek.Value);
            timer.Start();
        }

        private void MySlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.dragStarted = true;
            timer.Stop();
        }

        private void VolSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            this.volDragStarted = false;
            mePlayer.Volume = (double)sliVol.Value / 100;

            if (sliVol.Value > 0)
                tBtnMute.IsChecked = false;
            else
                tBtnMute.IsChecked = true;
        }

        private void VolSlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.volDragStarted = true;
        }
        
        private void MP_Drop(object sender, DragEventArgs e)
        {
            string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);

            for (int i = 0; i < dropFiles.Count(); i++)
            {
                filenames.Add(dropFiles[i]);
                ListBoxItem item = new ListBoxItem();
                item.Content = System.IO.Path.GetFileName(dropFiles[i]);
                listBox.Items.Add(item);
            }

            if (playIndex == -1)
                loadPlayer(0);
        }

        private void loadPlayer(int index)
        {
            if(System.IO.Path.GetExtension(filenames[index]) != ".mp3" && meOld != null)
            {
                mePlayer = null;
                mePlayer = meOld;
            }

            mePlayer.Source = new Uri(filenames[index]);
            ListBoxItem itemChange = (ListBoxItem)listBox.Items[index];
            itemChange.Content = ">> " + System.IO.Path.GetFileName(filenames[index]);
            mePlayer.LoadedBehavior = MediaState.Manual;
            mePlayer.UnloadedBehavior = MediaState.Manual;
            mePlayer.Play();
            mePlayer.Pause();
            playIndex = index;
        }

        private void mePlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mePlayer.NaturalDuration.TimeSpan;
            sliSeek.Maximum = ts.TotalSeconds;
            lblTotalSeek.Content = mePlayer.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss");
        }

        private void mePlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (filenames.Count - 1 == playIndex)
            {
                mePlayer.Stop();
                timer.Stop();
                btnPlayPause.Content = "Play";
                sliSeek.Value = 0;
                lblSeek.Content = "00:00:00";
                createNewME();
                loadPlayer(playIndex);
            }
            else
            {
                mePlayer.Stop();
                timer.Stop();
                ListBoxItem item = (ListBoxItem)listBox.Items[playIndex];
                if (item.Content.ToString().Contains(">> "))
                {
                    item.Content = item.Content.ToString().Substring(3);
                }
                loadPlayer(playIndex + 1);
                mePlayer.Play();
                timer.Start();
            }
        }

        private void createNewME()
        {
            meOld = mePlayer;
            mePlayer = null;
            mePlayer = new MediaElement();
            mePlayer.MediaEnded += mePlayer_MediaEnded;
            mePlayer.MediaOpened += mePlayer_MediaOpened;
            mePlayer.Volume = (double)sliVol.Value / 100;
        }

        private void sliVol_MouseEnter(object sender, MouseEventArgs e)
        {
            sliVol.ToolTip = sliVol.Value.ToString();
        }

        private void tBtnMute_Click(object sender, RoutedEventArgs e)
        {
            if (tBtnMute.IsChecked == true)
            {
                vol = sliVol.Value;
                sliVol.Value = 0;
            }
            else
                sliVol.Value = vol;
        }

        private void tBtnExpand_Click(object sender, RoutedEventArgs e)
        {
            if (tBtnExpand.IsChecked == true)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ListBoxItem item;
                int index = listBox.SelectedIndex;

                for (int i = 0; i < listBox.Items.Count; i++)
                {
                    item = (ListBoxItem)listBox.Items[i];
                    if (item.Content.ToString().Contains(">> "))
                    {
                        item.Content = item.Content.ToString().Substring(3);
                    }
                }

                if (listBox.Items.Count > 0)
                {
                    loadPlayer(index);
                    mePlayer.Play();
                    btnPlayPause.Content = "Pause";

                    if (timer.IsEnabled == false)
                        timer.Start();
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item;
            int index = listBox.SelectedIndex;

            item = (ListBoxItem)listBox.Items[index];
            if (item.Content.ToString().Contains(">> "))
            {
                item = null;
                listBox.Items.RemoveAt(index);
                filenames.RemoveAt(index);

                if (listBox.Items.Count > 0)
                {
                    if (index > listBox.Items.Count - 1)
                        loadPlayer(0);
                    else
                        loadPlayer(index);
                }

                mePlayer.Stop();
                btnPlayPause.Content = "Play";
                timer.Stop();
            }
            else
            {
                listBox.Items.RemoveAt(index);
                filenames.RemoveAt(index);
            }
        }

        private void sliSeek_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mePlayer.Source != null)
            {
                if (!dragStarted)
                {
                    mePlayer.Position = TimeSpan.FromSeconds(sliSeek.Value);
                }

                lblSeek.Content = mePlayer.Position.ToString(@"hh\:mm\:ss");
            }
        }
    }
}
