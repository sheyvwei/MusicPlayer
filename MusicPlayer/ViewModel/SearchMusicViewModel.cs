using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEEKiDoS.MusicPlayer.NeteaseCloudMusicApi;
using MusicPlayer.Model;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Un4seen.Bass;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.ViewModel
{
    public class SearchMusicViewModel : ViewModelBase
    {
        private string  _searchName;
        public string SearchName
        {
            get
            {
                return _searchName;
            }
            set
            {
                _searchName = value;
                RaisePropertyChanged("SearchName");
            }
        }

        //public ICommand PlayUrlCommand { get; set; }
        public ICommand PlayUrlCommand { get; set; }
        public ICommand PlayQQCommand { get; set; }
        public SearchMusicViewModel()
        {
            
            PlayUrlCommand = new RelayCommand(() => Init());
            PlayQQCommand = new RelayCommand(() => PlayQQCommandExecute());

        }
        public void PlayQQCommandExecute()
        {
            playList.Clear();
            string html = getHtml(SearchName).Remove(0,9);
            string json = html.Substring(0, html.Length - 1);
            JObject jo = JObject.Parse(json);
            foreach(var value in jo["data"]["song"]["list"])
            {
                playList.Add(new MusicInfo(value["songmid"].ToString(),value["songname"].ToString(), value["singer"][0]["name"].ToString()));
            }
        }
        public  void Init()
        {
            var count = 0;
            var api =  new NeteaseMusicAPI();
            var request = api.Search(SearchName);
            playList.Clear();
            foreach (var song in request.Result.Songs)
            {
                count++;
                if (count < 20)
                    playList.Add(new MusicInfo(api.GetSongsUrl(new long[] { song.Id }).Data[0].Url, song.Name, song.Ar[0].Name));
            }
        }

        public BindingList<MusicInfo>  playList { get; set; } = new BindingList<MusicInfo>();
        public MusicInfo _music;
        
        /// <summary>
        /// 获取第一个URL
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public  string getHtml(string name)
        {
            string url = "https://c.y.qq.com/soso/fcgi-bin/client_search_cp?&lossless=0&flag_qc=0&p=1&n=20&w=";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + name);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // 请求成功的状态码：200
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string html = reader.ReadToEnd();
                            return html;
                        }
                    }

                }
                else
                {
                    return "服务器错误";
                }
            }
        }
        
        /// <summary>
        /// 获取vkey
        /// </summary>
        /// <param name="songmid"></param>
        /// <returns></returns>
        //public string getvkey(string songmid)
        //{
        //    string url = "https://c.y.qq.com/base/fcgi-bin/fcg_music_express_mobile3.fcg?&jsonpCallback=MusicJsonCallback&cid=205361747&songmid=" + songmid + "&filename=C400" + songmid + ".m4a&guid=6612300644";
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //    {
        //        // 请求成功的状态码：200
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            using (Stream stream = response.GetResponseStream())
        //            {
        //                using (StreamReader reader = new StreamReader(stream))
        //                {
        //                    string html = reader.ReadToEnd();
        //                    JObject jo = JObject.Parse(html);
        //                    string vkey = jo["data"]["items"][0]["vkey"].ToString();
        //                    return vkey;
        //                }
        //            }

        //        }
        //        else
        //        {
        //            return "服务器错误";
        //        }
        //    }
        //}
    }
}
