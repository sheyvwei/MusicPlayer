using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Un4seen.Bass;

namespace MusicPlayer.Model
{
    public class ConfigInfo : ObservableObject
    {
        private bool _isMuted;    /*  静音*/
        public bool IsMuted
        {
            get { return _isMuted; }
            set
            {
                _isMuted = value;
                RaisePropertyChanged("IsMuted");
            }
        }

        private float _volume = 1.0f;
        public float Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                RaisePropertyChanged("Volume");
            }
        }

        public OrderMode OrderMode { get; set; } = OrderMode.AddTime;   //默认按照时间顺序添加歌曲

        private PlayMode _playmode;
        public PlayMode PlayMode
        {
            get { return _playmode; }
            set
            {
                _playmode = value;
                RaisePropertyChanged("PlayMode");
            }
        }
        private BASSActive _playStatus;
        public BASSActive PlayStatus
        {
            get { return _playStatus; }
            set
            {
                _playStatus = value;
            }
        }

        private string _musicName;
        public string MusicName
        {
            get { return _musicName; }
            set { Set("MusicName", ref _musicName, value); }
        }
        private string _singer;
        public string Singer
        {
            get { return _singer; }
            set { Set("Singer", ref _singer, value); }
        }

        private double _position;
        public double Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                    return;
                _position = value;
                RaisePropertyChanged("Position");
            }
        }

        private double _timeLength;
        public double TimeLength
        {
            get { return _timeLength; }
            set { Set("TimieLength", ref _timeLength, value); }
        }
        public int _stream;
        public int Stream
        {
            get { return _stream; }
            set
            {
                _stream = value;
                RaisePropertyChanged("Stream");
            }
        }
        private double _musicTime;    //
        public double MusicTime
        {
            get { return _musicTime; }
            set
            {
                _musicTime = value;
                RaisePropertyChanged("MusicTime");
            }
            
        }
    }
}
