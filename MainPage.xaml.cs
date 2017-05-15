using MSound.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static MSound.Lyrics;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace MSound
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    /// 

    public class SoundPlay
    {
        public Uri mp3Url { get; set; }
    }

    public sealed partial class MainPage : Page
    {
        public ObservableCollection<comments> comments;
        public string message;
        public MainPage()
        {
            
            this.InitializeComponent();
            comments = comments_manager.GetComments();
            this.DataContext = this;
            this.getImage();
            this.check();
            //this.DataContext=myData;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            User.instance.CreditUpdated += Instance_CreditUpdated;
            User.instance.imageCreditUpdated += Instance_CreditUpdated;

        }

        private void Instance_CreditUpdated(object sender, EventArgs e)
        {
            ResultSound.Source =new Uri (User.instance.Credit.ToString());

            //source1.Text = User.instance.imageCredit.ToString();


        }

        //public SoundPlay myData;

        public static int awaits;

        public void check()
        {
            if (MainPage.awaits == 1)
            {
                //wait.IsActive = false;
            }
        }
        public static List<Track> list;

        public async void getImage()
        {

            if (MainPage.list == null)
            {
                //wait.IsActive = true;
            }
            else
            {
                //wait.IsActive = false;
            }

            int a = 559992539;
            string s1 = a.ToString();
            string s2 = Convert.ToString(a);
            RootObject mySound = await SoundProxy.GetSound(s2);

            MainPage.list = mySound.result.tracks;

            listBox.ItemsSource = MainPage.list;
            

            ImageBrush Image = new ImageBrush();

            flipImage1.Source = new BitmapImage(new Uri((mySound.result.tracks[0].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((mySound.result.tracks[0].album.picUrl)));

            flipImage2.Source = new BitmapImage(new Uri((mySound.result.tracks[1].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((mySound.result.tracks[1].album.picUrl)));

            flipImage3.Source = new BitmapImage(new Uri((mySound.result.tracks[2].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((mySound.result.tracks[2].album.picUrl)));

            flipImage4.Source = new BitmapImage(new Uri((mySound.result.tracks[3].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((mySound.result.tracks[3].album.picUrl)));

            flipImage.Source = new BitmapImage(new Uri((mySound.result.tracks[0].album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((mySound.result.tracks[0].album.picUrl)));

            MainPage.awaits = 1;
        }

        private void PlayviewIn(object sender, RoutedEventArgs e)
        {
            PlayIn.Begin();
            EllRound.Begin();
        }


        private void PlayviewOut(object sender, RoutedEventArgs e)
        {
            EllRound.Stop();
            PlayOut.Begin();
        }



        private void send_comment(object sender, RoutedEventArgs e)
        {
            DateTime send_time = DateTime.Now;
            comments.Add(new comments { user_picture = "Assets/Icon.jpg", user_name = "匿名", time = send_time.GetDateTimeFormats('f')[0].ToString(), notice = sentences.Text });
            
            sentences.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string soundName = sender.Text;
            RootObjects getSearch = await SearchProxy.searchSound(soundName);
            if (getSearch != null)
            {
                List<Song> searchSounds = getSearch.result.songs;
                MyFrame.Navigate(typeof(searchSound), searchSounds);
            }
            
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (Users.IsSelected)
            {
                if (App.soundsLists != null)
                {
                    wait.IsActive = false;
                    MyFrame.Navigate(typeof(SoundLists));
                }
                else
                {
                    wait.IsActive = true;
                }
               
            }
            else if (Home.IsSelected)
            {
                if (MainPage.list != null)
                {
                    wait.IsActive = false;
                    MyFrame.Navigate(typeof(HomePage));
                    
                }
                else
                {
                    wait.IsActive = true;
                }
            }
           /* else if (refresh.IsSelected)
            {
                var tests = App.soundsLists;
            }*/
            else if (shezhi.IsSelected)
            {
                MyFrame.Navigate(typeof(PageSetting));
            }
            else if (Messages.IsSelected)
            {
                MyFrame.Navigate(typeof(Pagemesaage));
            }

        }

        private void myFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

   

        public async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {

            /*if (MainPage.awaits == 1)
            {
                wait.IsActive = false;
            }*/

            var sound = (Track)e.ClickedItem;

            Uri musicUri = new Uri(sound.mp3Url);

            ResultSound.Source = musicUri;

            ImageBrush Image = new ImageBrush();
            flipImage1.Source = new BitmapImage(new Uri((sound.album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((sound.album.picUrl)));
            
            flipImage.Source = new BitmapImage(new Uri((sound.album.picUrl)));
            Image.ImageSource = new BitmapImage(new Uri((sound.album.picUrl)));

            SoundName.Text = sound.name;
            source1.Text = sound.album.name;
            singer1.Text = sound.artists[0].name;


            var Id = sound.id;
            string s2 = Convert.ToString(Id);
            RootObjectly soundLyric = await Lyrics.SoundLyrics(s2);

            if (soundLyric != null)
            {
                if (soundLyric.lrc != null)
                {
                    Lyric.Text = soundLyric.lrc.lyric;
                }
                else if (soundLyric.klyric != null)
                {
                    Lyric.Text = soundLyric.klyric.lyric;
                }
                else
                {
                    Lyric.Text = "抱歉，歌词尚未查询到。。。";
                }
            }
           
        }

        private void share_comments(object sender, ItemClickEventArgs e)
        {
            var One_comment = (comments)e.ClickedItem;
            message = "[" + One_comment.time + "]@" + One_comment.user_name + ":" + One_comment.notice;
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }
        private async void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            string textSource;
            textSource = "O(∩_∩)O";
            string textTitle = "分享给好友";//“确认分享”
            string textDescription = message;//应该改分享的文字内容

            DataPackage data = args.Request.Data;
            data.Properties.Title = textTitle;
            data.Properties.Description = textDescription;
            data.SetText(textSource);
            DataRequestDeferral GetFiles = args.Request.GetDeferral();
            try
            {
                StorageFile imageFile = await Package.Current.InstalledLocation.GetFileAsync("Assets\\r2.2.jpg");
                data.Properties.Thumbnail = RandomAccessStreamReference.CreateFromFile(imageFile);
                data.SetBitmap(RandomAccessStreamReference.CreateFromFile(imageFile));
            }
            finally
            {
                GetFiles.Complete();
            }
        }

        private void Like(object sender, TappedRoutedEventArgs e)
        {
            SolidColorBrush one = new SolidColorBrush();
            one.Color = Color.FromArgb(
               100, 238, 16, 16
            );
            like.Foreground = one;
            
           
        }

        private void Collect_Tap(object sender, TappedRoutedEventArgs e)
        {
        }
    }

}
