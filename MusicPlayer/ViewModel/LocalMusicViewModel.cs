using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;
using Un4seen.Bass;
using MusicPlayer.Model;
using System.ComponentModel;
using System;
using System.Windows.Threading;
using MusicPlayer.Helpers;
using System.Linq;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.ViewModel
{
    public class LocalMusicViewModel : ViewModelBase
    {


        public ConfigInfo Config { get; set; }
        public LocalMusicViewModel()
        {
            Config = new ConfigInfo();
            //readPlayList();
            PlayCommand = new RelayCommand(() => PlayCommandExecute(), () => true);
            PlayAndPauseCommand = new RelayCommand(() => PlayAndPauseExecute(), () => true);
            addItemCommand = new RelayCommand(() => addItemCommandExecute(), () => true);
            ValueChangedCommand = new RelayCommand(() => ValueChangedCommandExecute(), () => true);
            VolumnChangedCommand = new RelayCommand(() => VolumnChangedCommandExecute(), () => true);
            StopThreadCommand = new RelayCommand(() => StopThreadCommandExecute());
            LastCommand = new RelayCommand(() => LastCommandExecute(), () => true);
            NextCommand = new RelayCommand(() => NextCommandExecute(), () => true);
            PlayModeCommand = new RelayCommand(() => PlayModeCommandExecute(), () => true);
            MuteCommand = new RelayCommand(() => MuteCommandExecute(), () => true);
            DeleteMusicCommand = new RelayCommand(() => DeleteMusicCommandExecute());

        }

        public ICommand DeleteMusicCommand { get; private set; }
        //播放命令
        public ICommand AddMusicCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand PlayAndPauseCommand { get; private set; }
        public ICommand ValueChangedCommand { get; private set; }
        public ICommand VolumnChangedCommand { get; private set; }
        public ICommand StopThreadCommand { get; private set; }
        public ICommand LastCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        public ICommand PlayModeCommand { get; private set; }
        public ICommand MuteCommand { get; private set; }
        public void DeleteMusicCommandExecute()
        {
            playList.Remove(Music);
        }
        public void MuteCommandExecute()
        {
            Config.IsMuted = !Config.IsMuted;
            SetIsMuted(Config.IsMuted);

        }
        public void SetIsMuted(bool isMuted)
        {
            if(isMuted)
                Bass.BASS_ChannelSetAttribute(Config.Stream, BASSAttribute.BASS_ATTRIB_VOL, 0);
            else
                Bass.BASS_ChannelSetAttribute(Config.Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Volume);
        }
        public void PlayModeCommandExecute()
        {
            switch (Config.PlayMode)
            {
                case PlayMode.RandomPlay:
                    Config.PlayMode = PlayMode.LoopPlay;
                    break;
                case PlayMode.LoopPlay:
                    Config.PlayMode = PlayMode.SequentialPlay;
                    break;
                case PlayMode.SequentialPlay:
                    Config.PlayMode = PlayMode.SinglePlay;
                    break;
                case PlayMode.SinglePlay:
                    Config.PlayMode = PlayMode.RandomPlay;
                    break;
            }
        }
        private void LastCommandExecute()
        {
             if(playList.Count == 0)
            {
                return;
            }
            MusicInfo playMusic;
            switch (Config.PlayMode)
            {
                case PlayMode.RandomPlay:
                    int index = RandomHelper.GetNextIndex(playList.Count, Num);
                    playMusic = playList[index];
                    break;
                default:
                    index = Music.Number - 2;
                    playMusic = index > 0 ? playList[index] : playList.LastOrDefault();
                    break;
            }
            Music = playMusic;
            PlayCommandExecute();
        }
        private void NextCommandExecute()
        {
            if(playList.Count == 0)
            {
                return;
            }
            MusicInfo playMusic;
            switch (Config.PlayMode)
            {
                case PlayMode.RandomPlay:
                    int index = RandomHelper.GetNextIndex(playList.Count, Num);
                    playMusic = playList[index];
                    break;
                default:
                    index = Music.Number;
                    playMusic = index < playList.Count ? playList[index] : playList.FirstOrDefault();
                    break;
            }
            Music = playMusic;
            PlayCommandExecute();

        }
        private void VolumnChangedCommandExecute()
        {
            Bass.BASS_ChannelSetAttribute(Config.Stream, BASSAttribute.BASS_ATTRIB_VOL, Config.Volume);
        }
        private void StopThreadCommandExecute()
        {
            _timer.Stop();
        }
        public void ValueChangedCommandExecute()
        {
            Bass.BASS_ChannelSetPosition(Config.Stream, (long)Config.Position, BASSMode.BASS_POS_BYTES);
            _timer.Start();
        }

        //public ICommand SelectedChangedCommand { get; private set; }


        //public void SelectedChangedExecute()
        // {

        // }

        public MusicInfo _music;
        public MusicInfo Music
        {
            get { return _music; }
            set { _music = value; }
        }

        //public int _stream;
        //public int Stream
        //{
        //    get
        //    {
        //        return _stream;
        //    }
        //}
        private double _length;
        public double Length
        {
            get { return _length; }
            set
            {
                _length = value;
                RaisePropertyChanged("Length");
            }
        }


        public DispatcherTimer _timer;
        private void PlayCommandExecute()
        {
            if (Music.Url != null && Music.Url.Length == 14)
            {
                Bass.BASS_StreamFree(Config.Stream);
                Status = BASSActive.BASS_ACTIVE_PLAYING;
                Music.Url = "http://dl.stream.qqmusic.qq.com/C400" + Music.Url + ".m4a?vkey=" + getvkey(Music.Url) + "&guid=9774163462&uin=0&fromtag=66";
                Config.Stream = Bass.BASS_StreamCreateURL(Music.Url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
                Bass.BASS_ChannelPlay(Config.Stream, false);      //开始播放，参数1位句柄，参数2位true时从头播放，为false时继续播放。
                Length = Bass.BASS_ChannelGetLength(Config.Stream);
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(500);
                _timer.Tick += Timer_Tick;
                _timer.Start();
                return;
            }
            if (Music.Url != null)
            {
                Bass.BASS_StreamFree(Config.Stream);
                Status = BASSActive.BASS_ACTIVE_PLAYING;
                Config.Stream = Bass.BASS_StreamCreateURL(Music.Url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);
                Bass.BASS_ChannelPlay(Config.Stream, false);      //开始播放，参数1位句柄，参数2位true时从头播放，为false时继续播放。
                Length = Bass.BASS_ChannelGetLength(Config.Stream);
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(500);
                _timer.Tick += Timer_Tick;
                _timer.Start();
                return;
            }
            Bass.FreeMe();
            Bass.BASS_StreamFree(Config.Stream);
            Status = BASSActive.BASS_ACTIVE_PLAYING;
            Config.Stream = Bass.BASS_StreamCreateFile(Music.FilePath, 0, 0, BASSFlag.BASS_DEFAULT);
            Bass.BASS_ChannelPlay(Config.Stream, false);      //开始播放，参数1位句柄，参数2位true时从头播放，为false时继续播放。
            Length = Bass.BASS_ChannelGetLength(Config.Stream);
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        /// <summary>
        /// 获取vkey
        /// </summary>
        /// <param name="songmid"></param>
        /// <returns></returns>
        public  string getvkey(string songmid)
        {
            string url = "https://c.y.qq.com/base/fcgi-bin/fcg_music_express_mobile3.fcg?&jsonpCallback=MusicJsonCallback&cid=205361747&songmid=" + songmid + "&filename=C400" + songmid + ".m4a&guid=9774163462";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
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
                            JObject jo = JObject.Parse(html);
                            string vkey = jo["data"]["items"][0]["vkey"].ToString();
                            return vkey;
                        }
                    }

                }
                else
                {
                    return "服务器错误";
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Config.Position = Bass.BASS_ChannelGetPosition(Config.Stream, BASSMode.BASS_POS_BYTES);
            if (Config.Position == Length)
                switch (Config.PlayMode)
                {
                    case PlayMode.SinglePlay:
                        PlayCommandExecute();
                        break;
                    default:
                        NextCommandExecute();
                        break;
                }

        }

        public BASSActive _status;
        public BASSActive Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }
        private void PlayAndPauseExecute()
        {
            Status = Bass.BASS_ChannelIsActive(Config.Stream);
            if (Status == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(Config.Stream);
                Status = Bass.BASS_ChannelIsActive(Config.Stream);
                return;
            }
            if (Status == BASSActive.BASS_ACTIVE_PAUSED)
            {
                Bass.BASS_ChannelPlay(Config.Stream, false);
                Status = Bass.BASS_ChannelIsActive(Config.Stream);
                return;
            }
        }
        public ICommand addItemCommand { get; set; }
        public BindingList<MusicInfo> playList { get; set; } = new BindingList<MusicInfo>();
        public int Num =1;
        public void addItemCommandExecute()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            open.Filter = "Music File(*.mp3;*.wma;*.m4a;*.wav;*.ape;*.flac;)|*.mp3;*.wma;*.m4a;*.wav;*.ape;*.flac";
            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            foreach(var item in open.FileNames)
            {
                
                if(findMusic(item) == null)
                {
                    playList.Add(new MusicInfo(item, Num));
                    Num++;
                }

            }

        }
        private MusicInfo findMusic(string filePath)
        {
            foreach(var item in playList)
            {
                if(item.FilePath == filePath)
                {
                    return item;
                }
            }
            return null;
        }


    }
}
