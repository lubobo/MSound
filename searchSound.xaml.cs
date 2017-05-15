using MSound.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace MSound
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class searchSound : Page
    {
        public searchSound()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                listBox.ItemsSource = e.Parameter;

                List<Song> sounds = (List<Song>)e.Parameter;

                ImageBrush Image = new ImageBrush();
                flipImage1.Source = new BitmapImage(new Uri((sounds[0].album.picUrl)));
                Image.ImageSource = new BitmapImage(new Uri((sounds[0].album.picUrl)));
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listBox_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Song)e.ClickedItem;

            Uri musicUri = new Uri(sound.audio);
            User.instance.Credit = musicUri.ToString();

            ImageBrush Image = new ImageBrush();
            flipImage1.Source = new BitmapImage(new Uri((sound.album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((sound.album.picUrl)));
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void share_Click(object sender, RoutedEventArgs e)
        {

        }

        private void collect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void comments_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
