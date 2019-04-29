using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Un4seen.Bass;
using System.Net;
using MusicPlayer;
using GEEKiDoS.MusicPlayer.NeteaseCloudMusicApi;

namespace MusicPlayer.ViewModel
{
    public class FindMusicViewModel : ViewModelBase
    {
        //int stream;
        private string  _musicName;
        public string MusicName
        {
            get
            {
                return _musicName;
            }
            set
            {
                _musicName = value;
                RaisePropertyChanged("MusicName");
            }
        }
        private ICommand PlayUrlCommand { get; set; }
        public FindMusicViewModel()
        {
            PlayUrlCommand = new RelayCommand(() => PlayUrlCommandExecute(), () => true);
        }

        private void PlayUrlCommandExecute()
        {
            NeteaseMusicAPI api = new NeteaseMusicAPI();
            var apiresult = api.Search(MusicName);
            var songList = "";
            foreach(var song in apiresult.Result.Songs)
            {
                songList += string.Format("{0} - {1} ({2})\r\n,", song.Name, song.Ar[0].Name, api.GetSongsUrl(new long[] { song.Id }).Data[0].Url);
            }
        }


    }
}
