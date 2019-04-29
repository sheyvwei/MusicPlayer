using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Model
{
    /// <summary>
    /// 放些常量
    /// </summary>
    public enum OrderMode       //播放列表的 排序顺序 选择按照歌手。播放次数 添加时间 
    {
        MusicName = 0,
        Singer = 1,
        PlayTimies,
        AddTime = 3
    }

    public enum PlayMode        //播放模式选择， 随机， 顺序， 列表， 单曲
    {
        /// <summary>
        /// 随机播放
        /// </summary>
        RandomPlay = 0,
        /// <summary>
        /// 循环播放
        /// </summary>
        LoopPlay = 1,
        /// <summary>
        /// 顺序播放
        /// </summary>
        SequentialPlay = 2,
        /// <summary>
        /// 单曲循环
        /// </summary>
        SinglePlay = 3
    }

    public enum Sort            /*升序，还是降序*/
    {
        Ase,
        Desc
    }
    public class GlobalInfo
    {
        public static string[] PlayOrPauseTexts = { "&#xe74f;", "&#xe76a;" };  /* 开始，暂停*/
        public static string[] PlayModeTexts = { "&#xe60b;", "&#xe60d;", "&#xe60a;", "&#xe609;" };     //随机播放， 顺序， 列表， 单曲

    }
}
