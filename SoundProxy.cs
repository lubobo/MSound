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
    public class SoundProxy
    {
        public async static Task<RootObject> GetSound(String id)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("http://music.163.com/api/playlist/detail?id=" + id);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }
	
    [DataContract]
    public class Creator
    {
        [DataMember(Name = "defaultAvatar")]
        public bool defaultAvatar { get; set; }

        [DataMember(Name = "province")]
        public int province { get; set; }

        [DataMember(Name = "authStatus")]
        public int authStatus { get; set; }

        [DataMember(Name = "followed")]
        public bool followed { get; set; }

        [DataMember(Name = "avatarUrl")]
        public string avatarUrl { get; set; }

        [DataMember(Name = "accountStatus")]
        public int accountStatus { get; set; }

        [DataMember(Name = "gender")]
        public int gender { get; set; }

        [DataMember(Name = "city")]
        public int city { get; set; }

        /*[DataMember(Name = "birthday")]
        public int birthday { get; set; }*/

        [DataMember(Name = "userId")]
        public int userId { get; set; }

        [DataMember(Name = "userType")]
        public int userType { get; set; }

        [DataMember(Name = "nickname")]
        public string nickname { get; set; }

        [DataMember(Name = "signature")]
        public string signature { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "detailDescription")]
        public string detailDescription { get; set; }

        [DataMember(Name = "avatarImgId")]
        public long avatarImgId { get; set; }

        [DataMember(Name = "backgroundImgId")]
        public long backgroundImgId { get; set; }

        [DataMember(Name = "backgroundUrl")]
        public string backgroundUrl { get; set; }

        [DataMember(Name = "authority")]
        public int authority { get; set; }

        [DataMember(Name = "mutual")]
        public bool mutual { get; set; }

        [DataMember(Name = "expertTags")]
        public List<string> expertTags { get; set; }

        [DataMember(Name = "djStatus")]
        public int djStatus { get; set; }

        [DataMember(Name = "vipType")]
        public int vipType { get; set; }

        [DataMember(Name = "remarkName ")]
        public object remarkName { get; set; }

        [DataMember(Name = "avatarImgIdStr")]
        public string avatarImgIdStr { get; set; }

        [DataMember(Name = "backgroundImgIdStr")]
        public string backgroundImgIdStr { get; set; }
    }

    [DataContract]
    public class Artist
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "picId")]
        public int picId { get; set; }

        [DataMember(Name = "img1v1Id")]
        public int img1v1Id { get; set; }

        [DataMember(Name = "briefDesc")]
        public string briefDesc { get; set; }

        [DataMember(Name = "picUrl")]
        public string picUrl { get; set; }

        [DataMember(Name = "img1v1Url")]
        public string img1v1Url { get; set; }

        [DataMember(Name = "albumSize")]
        public int albumSize { get; set; }

        [DataMember(Name = "alias")]
        public List<object> alias { get; set; }

        [DataMember(Name = "trans")]
        public string trans { get; set; }

        [DataMember(Name = "musicSize")]
        public int musicSize { get; set; }
    }

    [DataContract]
    public class Artist2
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "picId")]
        public int picId { get; set; }

        [DataMember(Name = "img1v1Id")]
        public int img1v1Id { get; set; }

        [DataMember(Name = "briefDesc")]
        public string briefDesc { get; set; }

        [DataMember(Name = "picUrl")]
        public string picUrl { get; set; }

        [DataMember(Name = "img1v1Url")]
        public string img1v1Url { get; set; }

        [DataMember(Name = "albumSize")]
        public int albumSize { get; set; }

        [DataMember(Name = "alias")]
        public List<object> alias { get; set; }

        [DataMember(Name = "trans")]
        public string trans { get; set; }

        [DataMember(Name = "musicSize")]
        public int musicSize { get; set; }
    }

    [DataContract]
    public class Artist3
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "picId")]
        public int picId { get; set; }

        [DataMember(Name = "img1v1Id")]
        public int img1v1Id { get; set; }

        [DataMember(Name = "briefDesc")]
        public string briefDesc { get; set; }

        [DataMember(Name = "picUrl")]
        public string picUrl { get; set; }

        [DataMember(Name = "img1v1Url")]
        public string img1v1Url { get; set; }

        [DataMember(Name = "albumSize")]
        public int albumSize { get; set; }

        [DataMember(Name = "alias")]
        public List<object> alias { get; set; }

        [DataMember(Name = "trans")]
        public string trans { get; set; }

        [DataMember(Name = "musicSize")]
        public int musicSize { get; set; }
    }

    [DataContract]
    public class Album
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "size")]
        public int size { get; set; }

        [DataMember(Name = "picId")]
        public object picId { get; set; }

        [DataMember(Name = "blurPicUrl")]
        public string blurPicUrl { get; set; }

        [DataMember(Name = "companyId")]
        public int companyId { get; set; }

        [DataMember(Name = "pic")]
        public object pic { get; set; }

        [DataMember(Name = "picUrl")]
        public string picUrl { get; set; }

        [DataMember(Name = "publishTime")]
        public object publishTime { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "tags")]
        public string tags { get; set; }

        [DataMember(Name = "company")]
        public string company { get; set; }

        [DataMember(Name = "briefDesc")]
        public string briefDesc { get; set; }

        [DataMember(Name = "artist")]
        public Artist2 artist { get; set; }

        [DataMember(Name = "songs")]
        public List<object> songs { get; set; }

        [DataMember(Name = "alias")]
        public List<object> alias { get; set; }

        [DataMember(Name = "status")]
        public int status { get; set; }

        [DataMember(Name = "copyrightId")]
        public int copyrightId { get; set; }

        [DataMember(Name = "commentThreadId")]
        public string commentThreadId { get; set; }

        [DataMember(Name = "artists")]
        public List<Artist3> artists { get; set; }
    }

    [DataContract]
    public class BMusic
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "size")]
        public int size { get; set; }

        [DataMember(Name = "extension")]
        public string extension { get; set; }

        [DataMember(Name = "sr")]
        public int sr { get; set; }

        [DataMember(Name = "dfsId")]
        public object dfsId { get; set; }

        [DataMember(Name = "bitrate")]
        public int bitrate { get; set; }

        [DataMember(Name = "playTime")]
        public int playTime { get; set; }

        [DataMember(Name = "volumeDelta")]
        public double volumeDelta { get; set; }
    }

    [DataContract]
    public class HMusic
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "size")]
        public int size { get; set; }

        [DataMember(Name = "extension")]
        public string extension { get; set; }

        [DataMember(Name = "sr")]
        public int sr { get; set; }

        [DataMember(Name = "dfsId")]
        public object dfsId { get; set; }

        [DataMember(Name = "bitrate")]
        public int bitrate { get; set; }

        [DataMember(Name = "playTime")]
        public int playTime { get; set; }

        [DataMember(Name = "volumeDelta")]
        public double volumeDelta { get; set; }
    }

    [DataContract]
    public class MMusic
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "size")]
        public int size { get; set; }

        [DataMember(Name = "extension")]
        public string extension { get; set; }

        [DataMember(Name = "sr")]
        public int sr { get; set; }

        [DataMember(Name = "dfsId")]
        public object dfsId { get; set; }

        [DataMember(Name = "bitrate")]
        public int bitrate { get; set; }

        [DataMember(Name = "playTime")]
        public int playTime { get; set; }

        [DataMember(Name = "volumeDelta")]
        public double volumeDelta { get; set; }
    }

    [DataContract]
    public class LMusic
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "size")]
        public int size { get; set; }

        [DataMember(Name = "extension")]
        public string extension { get; set; }

        [DataMember(Name = "sr")]
        public int sr { get; set; }

        [DataMember(Name = "dfsId")]
        public object dfsId { get; set; }

        [DataMember(Name = "bitrate")]
        public int bitrate { get; set; }

        [DataMember(Name = "playTime")]
        public int playTime { get; set; }

        [DataMember(Name = "volumeDelta")]
        public double volumeDelta { get; set; }
    }

    [DataContract]
    public class Track
    {
        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "position")]
        public int position { get; set; }

        [DataMember(Name = "alias")]
        public List<object> alias { get; set; }

        [DataMember(Name = "status")]
        public int status { get; set; }

        [DataMember(Name = "fee")]
        public int fee { get; set; }

        [DataMember(Name = "copyrightId")]
        public int copyrightId { get; set; }

        [DataMember(Name = "disc")]
        public string disc { get; set; }

        [DataMember(Name = "no")]
        public int no { get; set; }

        [DataMember(Name = "artists")]
        public List<Artist> artists { get; set; }

        [DataMember(Name = "album")]
        public Album album { get; set; }

        [DataMember(Name = "starred")]
        public bool starred { get; set; }

        [DataMember(Name = "popularity")]
        public double popularity { get; set; }

        [DataMember(Name = "score")]
        public int score { get; set; }

        [DataMember(Name = "starredNum")]
        public int starredNum { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "playedNum")]
        public int playedNum { get; set; }

        [DataMember(Name = "dayPlays")]
        public int dayPlays { get; set; }

        [DataMember(Name = "hearTime")]
        public int hearTime { get; set; }

        [DataMember(Name = "ringtone")]
        public string ringtone { get; set; }

        [DataMember(Name = "crbt")]
        public string crbt { get; set; }

        [DataMember(Name = "audition")]
        public object audition { get; set; }

        [DataMember(Name = "copyFrom")]
        public string copyFrom { get; set; }

        [DataMember(Name = "commentThreadId")]
        public string commentThreadId { get; set; }

        [DataMember(Name = "rtUrl")]
        public object rtUrl { get; set; }

        [DataMember(Name = "commentCount")]
        public int ftype { get; set; }

        [DataMember(Name = "rtUrls")]
        public List<object> rtUrls { get; set; }

        [DataMember(Name = "rtype")]
        public int rtype { get; set; }

        [DataMember(Name = "rurl")]
        public object rurl { get; set; }

        [DataMember(Name = "mvid")]
        public int mvid { get; set; }

        [DataMember(Name = "bMusic")]
        public BMusic bMusic { get; set; }

        [DataMember(Name = "mp3Url")]
        public string mp3Url { get; set; }

        [DataMember(Name = "hMusic")]
        public HMusic hMusic { get; set; }

        [DataMember(Name = "mMusic")]
        public MMusic mMusic { get; set; }

        [DataMember(Name = "lMusic")]
        public LMusic lMusic { get; set; }
    }

    [DataContract]
    public class Result
    {
        [DataMember(Name = "subscribers")]
        public List<object> subscribers { get; set; }

        [DataMember(Name = "subscribed")]
        public bool subscribed { get; set; }

        [DataMember(Name = "creator")]
        public Creator creator { get; set; }

        [DataMember(Name = "artists")]
        public object artists { get; set; }

        [DataMember(Name = "tracks")]
        public List<Track> tracks { get; set; }

        [DataMember(Name = "tags")]
        public List<string> tags { get; set; }

        [DataMember(Name = "ordered")]
        public bool ordered { get; set; }

        [DataMember(Name = "cloudTrackCount")]
        public int cloudTrackCount { get; set; }

        [DataMember(Name = "subscribedCount")]
        public int subscribedCount { get; set; }

        [DataMember(Name = "anonimous")]
        public bool anonimous { get; set; }

        [DataMember(Name = "trackUpdateTime")]
        public long trackUpdateTime { get; set; }

        [DataMember(Name = "adType")]
        public int adType { get; set; }

        [DataMember(Name = "trackNumberUpdateTime")]
        public long trackNumberUpdateTime { get; set; }

        [DataMember(Name = "specialType")]
        public int specialType { get; set; }

        [DataMember(Name = "userId")]
        public int userId { get; set; }

        [DataMember(Name = "privacy")]
        public int privacy { get; set; }

        [DataMember(Name = "newImported")]
        public bool newImported { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "status")]
        public int status { get; set; }

        [DataMember(Name = "updateTime")]
        public long updateTime { get; set; }

        [DataMember(Name = "commentThreadId")]
        public string commentThreadId { get; set; }

        [DataMember(Name = "playCount")]
        public int playCount { get; set; }

        [DataMember(Name = "coverImgUrl")]
        public string coverImgUrl { get; set; }

        [DataMember(Name = "coverImgId")]
        public long coverImgId { get; set; }

        [DataMember(Name = "totalDuration")]
        public int totalDuration { get; set; }

        [DataMember(Name = "trackCount")]
        public int trackCount { get; set; }

        [DataMember(Name = "createTime")]
        public long createTime { get; set; }

        [DataMember(Name = "highQuality")]
        public bool highQuality { get; set; }

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "id")]
        public int id { get; set; }

        [DataMember(Name = "shareCount")]
        public int shareCount { get; set; }

        [DataMember(Name = "commentCount")]
        public int commentCount { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember(Name = "result")]
        public Result result { get; set; }

        [DataMember(Name = "code")]
        public int code { get; set; }
    }

}
