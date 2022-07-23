using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Game
    {
        private static Game GameInstance;

        public static Game Instance
        {
            get
            {
                if (GameInstance == null)
                    GameInstance = new Game();
                return GameInstance;
            }
        }

        // Destroys this entire object and starts anew.
        public void Reset()
        {
            GameInstance = new Game();
        }

        /*
         * Determine here what happens when you press a button. The x and y coordinates are in parameters and are 0-based starting top left.
         * E.g. If the width and height are 5 and 10 respectively, the top left box has coordinate (0, 0), the top right box has coordinate (4, 0), the bottom left has (0, 9) and the bottom right has (4, 9).
         * 
         * The returning string will be put as text in the box. Use "M" for mine, i.e. you fucked up. By default this always returns "M" right now.
         */
        public string ButtonClick(int x, int y)
        {
            return "M";
        }
    }
}
