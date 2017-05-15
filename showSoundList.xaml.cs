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
    public sealed partial class showSoundList : Page
    {
        public showSoundList()
        {
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                    Dictionary<string, RootObject> getListData = (Dictionary<string, RootObject>)e.Parameter;

                    List<Track> list = getListData["sound"].result.tracks;

                    ImageBrush Image = new ImageBrush();

                    flipImage1.Source = new BitmapImage(new Uri((getListData["sound"].result.tracks[0].album.picUrl)));
                    Image.ImageSource = new BitmapImage(new Uri((getListData["sound"].result.tracks[0].album.picUrl)));

                    listBox.ItemsSource = list;
            }
        }



        

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            var getSound = new MainPage();

            getSound.GridView_ItemClick(sender,e);


            var sound = (Track)e.ClickedItem;
            Uri musicUri = new Uri(sound.mp3Url);

            MainPage soundPlay = new MainPage();

            

            User.instance.Credit = musicUri.ToString();
            User.instance.imageCredit = sound.album.name;

            ImageBrush Image = new ImageBrush();
            flipImage1.Source = new BitmapImage(new Uri((sound.album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((sound.album.picUrl)));

        }

        private void myFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(SoundLists));
        }

        private void comments_Click(object sender, RoutedEventArgs e)
        {

        }

        private void collect_Click(object sender, RoutedEventArgs e)
        {

        }

        private void share_Click(object sender, RoutedEventArgs e)
        {

        }

        private void play_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
