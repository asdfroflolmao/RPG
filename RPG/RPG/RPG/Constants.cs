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

        public static int gameWindowWidth
        {
            get { return window_width; }
        }

        public static int gameWindowHeight
        {
            get { return window_height; }
        }
    }
}
