using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Constants
    {
        private static int window_width = 800;
        private static int window_height = 600;
        private static int hp_bar_width = 100;
        private static int hp_bar_height = 20;

        public static int gameWindowWidth
        {
            get { return window_width; }
        }

        public static int gameWindowHeight
        {
            get { return window_height; }
        }

        public static int hpBarWidth
        {
            get { return hp_bar_width; }
        }

        public static int hpBarHeight
        {
            get { return hp_bar_height; }
        }
    }
}
