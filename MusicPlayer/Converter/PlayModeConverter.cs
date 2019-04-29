using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MusicPlayer.Model;

namespace MusicPlayer.Converter
{
    public class PlayModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PlayMode playMode = (PlayMode)value;
            string result = "\ue60b";
            switch (playMode)
            {
                case PlayMode.RandomPlay:
                    result = "\ue60b";
                    break;
                case PlayMode.LoopPlay:
                    result = "\ue60d";
                    break;
                case PlayMode.SequentialPlay:
                    result = "\ue60a";
                    break;
                case PlayMode.SinglePlay:
                    result = "\ue609";
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
