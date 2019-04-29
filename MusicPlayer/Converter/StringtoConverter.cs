using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Un4seen.Bass;

namespace MusicPlayer.Converter
{
    class StringtoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BASSActive status = (BASSActive)value;
            string result = "\ue74f";
            switch (status.ToString())
            {
                case "BASS_ACTIVE_STOPPED":
                    result = "\ue74f";
                    break;
                case "BASS_ACTIVE_PAUSED":
                    result = "\ue74f";
                    break;
                case "BASS_ACTIVE_PLAYING":
                    result = "\ue76a";
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
