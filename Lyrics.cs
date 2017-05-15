using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MSound
{
    public class Lyrics
    {


        public async static Task<RootObjectly> SoundLyrics(string soundId)
        {
            var http = new HttpClient();
            Uri uri = new Uri("http://" + "music.163.com/api/song/lyric?os=pc&id=" + soundId+ "&lv=-1&kv=-1&tv=-1");
            var response = await http.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObjectly));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObjectly)serializer.ReadObject(ms);

            return data;
        }



        public class Lrc
        {
            public int version { get; set; }
            public string lyric { get; set; }
        }

        public class Klyric
        {
            public int version { get; set; }
            public string lyric { get; set; }
        }

        public class Tlyric
        {
            public int version { get; set; }
            public object lyric { get; set; }
        }

        public class RootObjectly
        {
            public bool sgc { get; set; }
            public bool sfy { get; set; }
            public bool qfy { get; set; }
            public Lrc lrc { get; set; }
            public Klyric klyric { get; set; }
            public Tlyric tlyric { get; set; }
            public int code { get; set; }
        }

    }
}
