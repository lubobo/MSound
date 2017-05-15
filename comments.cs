using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSound
{
    public class comments
    {
        public string user_picture { get; set; }
        public string user_name { get; set; }
        public string time { get; set; }
        public string notice { get; set; }
    }
    public class comments_manager
    {
        public static ObservableCollection<comments> GetComments()
        {
            string c1 = @"她说民谣太穷了，一听就是一根烟，一听就是一瓶酒。而我只有一根烟了，还要撑一夜，只剩一点爱了，还要过一生。";
            string c2 = @"听不腻的歌就是这样吧，不会太惊艳也不会太吵闹，随着时间过去，像沉默的化石存在记忆里。";
            string c3 = @"音乐的魅力就是这样，它把你当时听到这首音乐时的心境融入到音乐当中，以后无论任何时候你再听到这个音乐，当时的心境就会重现";
            var comments = new ObservableCollection<comments>();
            comments.Add(new comments { user_picture = "Assets/pic.jpg", user_name = "灯等登", time = "2017年4月23日", notice = "仓鼠鼓着腮帮子来到医院，龙猫大夫说：“上火了吗，开点药吧。”“不，不是，我给你送点吃的来。有时候就是这样，你对别人的爱，在别人眼里像是病。”"});
            comments.Add(new comments { user_picture = "Assets/Icon.jpg", user_name = "GGGGorden", time = "2016年8月29日", notice = "有些人光是遇到就已经赚了。" });
            comments.Add(new comments { user_picture = "Assets/08.jpg", user_name = "柚子冰1210", time = "2016年2月29日", notice = c1 });
            comments.Add(new comments { user_picture = "Assets/Icon4.png", user_name = "一枚海贝", time = "2015年6月27日", notice = c2});
            comments.Add(new comments { user_picture = "Assets/Icon3.jpg", user_name = "逍遥e书生", time = "2015年10月7日", notice = c3 });
            comments.Add(new comments { user_picture = "Assets/06.jpg", user_name = "BUNNYDXW", time = "2013年4月23日", notice = "我仅有一个一生，无法慷慨赠与我不爱的人。" });
            return comments;
        }
    }

    public class songlist
    {
        public string Sname { get; set; }
        public string Ssinger { get; set; }
        public string Stime { get; set; }
    }
    public class songlist_manager
    {
        public static ObservableCollection<songlist> Getsonglist()
        {
            var songlist = new ObservableCollection<songlist>();
            songlist.Add(new songlist { Sname = "小相思", Ssinger = "花粥", Stime = "03：40" });
            return songlist;
        }
    }
}
