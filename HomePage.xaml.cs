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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();
            this.getImage();
        }


        public void getImage()
        {
            
            listBox.ItemsSource = MainPage.list;
            
            ImageBrush Image = new ImageBrush();

            flipImage1.Source = new BitmapImage(new Uri((MainPage.list[0].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((MainPage.list[0].album.picUrl)));

            flipImage2.Source = new BitmapImage(new Uri((MainPage.list[1].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((MainPage.list[1].album.picUrl)));

            flipImage3.Source = new BitmapImage(new Uri((MainPage.list[2].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((MainPage.list[2].album.picUrl)));

            flipImage4.Source = new BitmapImage(new Uri((MainPage.list[3].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((MainPage.list[3].album.picUrl)));


        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        { 
            var sound = (Track)e.ClickedItem;

            Uri musicUri = new Uri(sound.mp3Url);
            User.instance.Credit = musicUri.ToString();

            ImageBrush Image = new ImageBrush();
            flipImage1.Source = new BitmapImage(new Uri((sound.album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((sound.album.picUrl)));

        }

        private void myFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}