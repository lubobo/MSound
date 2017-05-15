using MSound;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class SoundLists : Page
    {
        public SoundLists()
        {
            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.InitializeComponent();
            this.getList();
            this.check();
        }

        public void check()
        {
                wait.IsActive = false;
        }
        private void getList()
        {
            if (App.soundsLists == null)
            {
                wait.IsActive = true;
            }
            else
            {
                wait.IsActive = false;
            }
            soundList.ItemsSource = App.soundsLists;
        }

        private void soundList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mySounds = (RootObject)e.ClickedItem;

            Dictionary<string, RootObject> listData = new Dictionary<string, RootObject>();

            listData.Add("sound", mySounds);

            MyFrame.Navigate(typeof(showSoundList), listData);

        }

        private void myFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
