using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MSound
{
    /// <summary>
    /// 提供特定于应用程序的行为，以补充默认的应用程序类。
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// 初始化单一实例应用程序对象。这是执行的创作代码的第一行，
        /// 已执行，逻辑上等同于 main() 或 WinMain()。
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.getList();
        }

        public static List<RootObject> soundsLists;

        public static List<string> sounds=new List<string>();

        public async void getList()
        {
            App.sounds.Add("442355750");
            App.sounds.Add("627258287");
            App.sounds.Add("696322868");
            App.sounds.Add("634167180");
            App.sounds.Add("700730423");
            App.sounds.Add("699894366");
            App.sounds.Add("574360371");
            App.sounds.Add("697601210");
            App.sounds.Add("696391518");
            App.sounds.Add("695592862");
            App.sounds.Add("700814566");
            App.sounds.Add("700834544");
            App.sounds.Add("700334544");
            App.sounds.Add("700834568");
            App.sounds.Add("652047874");
            App.sounds.Add("147279391");
            App.sounds.Add("695389522");
            App.sounds.Add("692893056");
            App.sounds.Add("594763827");

            App.soundsLists = new List<RootObject>();

            for (int i = 0; i < App.sounds.Count; i++)
            {
                if (await SoundProxy.GetSound(App.sounds[i]) != null)
                {
                    RootObject mySound = await SoundProxy.GetSound(App.sounds[i]);
                    if (mySound.result != null)
                    {
                        if (mySound.result.tracks.Count != 0)
                        {
                            soundsLists.Add(mySound);
                        }
                    }
                }
            }
            for (int i = 702410323; i < 702410350; i++)
            {
                int a = i;
                string s1 = a.ToString();
                string s2 = Convert.ToString(a);

                if (await SoundProxy.GetSound(s2) != null)
                {
                    RootObject mySound = await SoundProxy.GetSound(s2);
                    if (mySound.result != null)
                    {
                        if (mySound.result.tracks.Count != 0)
                        {
                            soundsLists.Add(mySound);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 在应用程序由最终用户正常启动时进行调用。
        /// 将在启动应用程序以打开特定文件等情况下使用。
        /// </summary>
        /// <param name="e">有关启动请求和过程的详细信息。</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = false;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // 不要在窗口已包含内容时重复应用程序初始化，
            // 只需确保窗口处于活动状态
            if (rootFrame == null)
            {
                // 创建要充当导航上下文的框架，并导航到第一页
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: 从之前挂起的应用程序加载状态
                }

                // 将框架放在当前窗口中
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // 当导航堆栈尚未还原时，导航到第一页，
                    // 并通过将所需信息作为导航参数传入来配置
                    // 参数
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // 确保当前窗口处于活动状态
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// 导航到特定页失败时调用
        /// </summary>
        ///<param name="sender">导航失败的框架</param>
        ///<param name="e">有关导航失败的详细信息</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// 在将要挂起应用程序执行时调用。  在不知道应用程序
        /// 无需知道应用程序会被终止还是会恢复，
        /// 并让内存内容保持不变。
        /// </summary>
        /// <param name="sender">挂起的请求的源。</param>
        /// <param name="e">有关挂起请求的详细信息。</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: 保存应用程序状态并停止任何后台活动
            deferral.Complete();
        }
    }
}
