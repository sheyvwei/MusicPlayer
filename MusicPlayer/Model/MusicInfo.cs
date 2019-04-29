using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Un4seen.Bass;

namespace MusicPlayer.Model
{
    public class MusicInfo : ObservableObject
    {
        private int _number;
        public int Number
        {
            get { return _number; }
            set { Set("Number", ref _number, value); }
        }

        public bool IsSelected { get; set; }
        public string Url { get; set; }
        public string  FilePath { get; set; }
        public string MusicName { get; set; }
        public string Singer { get; set; }
        public string Album { get; set; }
        public string Rate { get; set; }       //比率
        public string TimeLength { get; set; }  //  时间总长度
        public DateTime AddTime { get; set; }   //添加时间
        public int PlayTimes { get; set; }      //播放次数
        public string Duration { get; set; }  //持续时间


        private BASSActive _playStatus;
        public BASSActive PlayStatus
        {
            get { return _playStatus; }
            set { Set("PlayStatus", ref _playStatus, value); }
        }

        public MusicInfo(string filePath, int num)
        {
            try
            {
                var file = TagLib.File.Create(filePath);
                //var file = TagLib.File.Create(path.LocalPath)  public Uri path
                MusicName = file.Tag.Title;
                if (file.Tag.Performers.Length != 0)
                    Singer = file.Tag.Performers[0];
                else
                    Singer = null;
                Album = file.Tag.Album;
                Duration = file.Properties.Duration.ToString("mm':'ss");

                FilePath = filePath;
                Number = num;
            }
            catch
            {
                MusicName = null;
                Singer = null;
                this.FilePath = null;
            }
        }
        public MusicInfo(string url, string musicName, string singer)
        {
                Url = url;
                MusicName = musicName;
                Singer = singer;
        }
    }
}
