using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);
        public static int GetNextIndex(int count, int nowNumber)
        {
            var index = random.Next(0, count);
            while(index == nowNumber)
            {
                index = random.Next(0, count);
            }
            return index;
        }
    }
}
