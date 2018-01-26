using System;

namespace Planner_app
{
    class Menu
    { 
        public int ActivePunkt { set; get; }     // num of chosen punkt
        public short xPos { set; get; }          // x coord for menu
        public short yPos { set; get; }          // y coord for menu
        
        public string[] MenuPunkts { set; get; }       // string array of menu punkts
        public string Title { set; get; }              // menu title
        public ConsoleColor NormTxt { set; get; }      // common text color
        public ConsoleColor NormBackTxt { set; get; }  // common text background color
        public ConsoleColor MarkTxt { set; get; }      // mark text color
        public ConsoleColor MarkBackTxt { set; get; }  // mark text background color

        public Menu(string[] menuPunkts, string title = "", short x = 2, short y = 2)
        {
            ActivePunkt = 0;
            xPos = x;
            yPos = y;
            MenuPunkts = menuPunkts;
            Title = title;
            NormTxt = ConsoleColor.Black;
            NormBackTxt = ConsoleColor.White;
            MarkTxt = ConsoleColor.White;
            MarkBackTxt = ConsoleColor.DarkMagenta;
        }

        // displays the menu on the console screen, with active up and down arrows to choose punkt
        public int StartMenu ()    
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(xPos, yPos - 1);
 
            SetNormColor();
            Console.Write(Title);

            for (int i = 0; i < MenuPunkts.Length; ++i)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.Write(MenuPunkts[i]);
            }
            SetMarkColor();
            Console.SetCursorPosition(xPos, yPos + ActivePunkt);
            Console.Write(MenuPunkts[ActivePunkt]);

            ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();

            do
            {
                PressedKey = Console.ReadKey(true);

                if (PressedKey.Key == ConsoleKey.DownArrow || PressedKey.Key == ConsoleKey.UpArrow)
                {
                    SetNormColor();
                    Console.SetCursorPosition(xPos, yPos + ActivePunkt);
                    Console.Write(MenuPunkts[ActivePunkt]);

                    if (PressedKey.Key == ConsoleKey.UpArrow)
                    {
                        ActivePunkt = (ActivePunkt == 0) ? (MenuPunkts.Length - 1) : --ActivePunkt;
                    }
                    else
                    {
                        ActivePunkt = (ActivePunkt == MenuPunkts.Length - 1) ? 0 : ++ActivePunkt;
                    }
                    SetMarkColor();
                    Console.SetCursorPosition(xPos, yPos + ActivePunkt);
                    Console.Write(MenuPunkts[ActivePunkt]);
                }
            } while (PressedKey.Key != ConsoleKey.Enter);

            SetNormColor();
            Console.CursorVisible = true;
            return ActivePunkt;
        }
        
        // sets norm color mode
        public void SetNormColor()
        {
            Console.BackgroundColor = NormBackTxt;
            Console.ForegroundColor = NormTxt;
        }
        
        // sets mark color mode
        public void SetMarkColor()
        {
            Console.BackgroundColor = MarkBackTxt;
            Console.ForegroundColor = MarkTxt;
        }
    }
}
