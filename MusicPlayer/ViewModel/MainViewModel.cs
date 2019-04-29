using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows.Input;
using Un4seen.Bass;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Command;

namespace MusicPlayer.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        //private string _musicInfo;
        //private int _stream;
        private BASSActive _status;
        private string icon;

        readonly static LocalMusicViewModel _localMusicViewModel = new LocalMusicViewModel();
        readonly static FindMusicViewModel _findMusicViewModel = new FindMusicViewModel();
        //导航

        private ViewModelBase _curentPageViewModel;
        private List<ViewModelBase> _pageViewModels;
        public ViewModelBase CurrentPageViewModel
        {
            get
            {
                return _curentPageViewModel;
            }
            set
            {
                if (_curentPageViewModel != value)
                {
                    _curentPageViewModel = value;
                    RaisePropertyChanged("CurrentPageViewModel");
                }
            }
        }
        public List<ViewModelBase> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)

                    _pageViewModels = new List<ViewModelBase>();

                return _pageViewModels;

            }
        }
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            CurrentPageViewModel = _localMusicViewModel;    //开始页面
            //AddMusicCommand = new RelayCommand(() => AddMusicCommandExecute(), () => true);
            //PlayCommand = new RelayCommand(() => PlayCommandExecute(), () => true);
            //PlayAndPauseCommand = new RelayCommand(() => PlayAndPauseExecute(), () => true);
            LocalMusicCommand = new RelayCommand(() => LocalMusicExecute());
            FindMusicCommand = new RelayCommand(() => FindMusicExecute());
            SearchMusicCommand = new RelayCommand(() => SearchMusicExecute());
        }
        public ICommand LocalMusicCommand { get; private set; }
        public ICommand FindMusicCommand { get; private set; }
        public ICommand SearchMusicCommand { get; private set; }

        ////顶部最小化最大化关闭命令
        //public ICommand MinimizeCommand { get; set; }
        //public ICommand MaximizeCommand { get; set; }
        //public ICommand CloseCommand { get; set; }

        //播放命令
        //public ICommand AddMusicCommand { get; private set; }
        //public ICommand PlayCommand { get; private set; }
        //public ICommand PlayAndPauseCommand { get; private set; }




        //private void AddMusicCommandExecute()
        //{
        //    OpenFileDialog open = new OpenFileDialog();
        //    open.Filter = "Music File(*.mp3;*.wma;*.m4a;*.wav;*.ape;*.flac;)|*.mp3;*.wma;*.m4a;*.wav;*.ape;*.flac";
        //    if (open.ShowDialog() == DialogResult.OK)
        //    {
        //        _musicInfo = open.FileName;
        //    }
        //}
        //private void PlayCommandExecute()
        //{

        //    Bass.BASS_StreamFree(_stream);
        //    _stream = Bass.BASS_StreamCreateFile(_musicInfo, 0, 0, BASSFlag.BASS_DEFAULT);
        //    Bass.BASS_ChannelPlay(_stream, false);      //开始播放，参数1位句柄，参数2位true时从头播放，为false时继续播放。
        //}
        //private void PlayAndPauseExecute()
        //{
        //    _status = Bass.BASS_ChannelIsActive(_stream);
        //    if (_status == BASSActive.BASS_ACTIVE_PLAYING)
        //    {
        //        Bass.BASS_ChannelPause(_stream);
        //        IconCode = "&#xe74f;";
        //    }
        //    if (_status == BASSActive.BASS_ACTIVE_PAUSED)
        //    {
        //        Bass.BASS_ChannelPlay(_stream, false);
        //        IconCode = "&#xe76a;";
        //    }
        //}



        //public void MinimizeCommandExecute()
        //{
        //    Window.WindowState= WindowState.Maximized;
        //}

        public void LocalMusicExecute()
        {
            CurrentPageViewModel = MainViewModel._localMusicViewModel;
        }
        public void FindMusicExecute()
        {
            CurrentPageViewModel = MainViewModel._findMusicViewModel;
        }
        public void SearchMusicExecute()
        {
            CurrentPageViewModel = new SearchMusicViewModel();
        }



        public string IconCode
        {
            get
            {
                return icon;
            }
            set
            {
                if (icon == value)
                    return;
                icon = value;
                RaisePropertyChanged(IconCode);
            }
        }
        public BASSActive Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
    }
}