using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Un4seen.Bass;
using MusicPlayer.Model;
using GalaSoft.MvvmLight.Messaging;

namespace MusicPlayer.Helpers
{
    public class MusicPlayHelper
    {
        public  int Stream;


        private readonly DispatcherTimer _timer = new DispatcherTimer();
        public void Play(MusicInfo musicInfo)
        {
            Bass.BASS_StreamFree(Stream);
            Stream = Bass.BASS_StreamCreateFile(musicInfo.FilePath,0, 0, BASSFlag.BASS_DEFAULT);
            Bass.BASS_ChannelPlay(Stream, false);
            //_timer.Interval = TimeSpan.FromMilliseconds(500);
            //_timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Send("UpdatePlayProgress", Bass.BASS_ChannelGetPosition(Stream));
        }

        public static void Send<T>(string token, T message)
        {
            Messenger.Default.Send(message, token);
        }
    }
}
