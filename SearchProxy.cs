using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MSound
{
    public class SearchProxy
    {
        public async static Task<RootObjects> searchSound(String searchName)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://s.music.163.com/search/get/?type=1&limit=50&s=" + searchName);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObjects));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObjects)serializer.ReadObject(ms);

            return data;
        }
    }

    [DataContract]
    public class Artists
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "picUrl")]
        public object picUrl { get; set; }
    }

    [DataContract]
    public class Artists2
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "picUrl")]
        public object picUrl { get; set; }
    }

    [DataContract]
    public class Albums
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "artist")]
        public Artist2 artist { get; set; }
        [DataMember(Name = "picUrl")]
        public string picUrl { get; set; }
    }

    [DataContract]
    public class Song
    {
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "artists")]
        public List<Artists> artists { get; set; }
        [DataMember(Name = "album")]
        public Albums album { get; set; }
        [DataMember(Name = "audio")]
        public string audio { get; set; }
        [DataMember(Name = "djProgramId")]
        public int djProgramId { get; set; }
        [DataMember(Name = "page")]
        public string page { get; set; }
    }

    [DataContract]
    public class Results
    {
        [DataMember(Name = "songCount")]
        public int songCount { get; set; }
        [DataMember(Name = "songs")]
        public List<Song> songs { get; set; }
    }

    [DataContract]
    public class RootObjects
    {
        [DataMember(Name = "result")]
        public Results result { get; set; }
        [DataMember(Name = "code")]
        public int code { get; set; }
    }
}
