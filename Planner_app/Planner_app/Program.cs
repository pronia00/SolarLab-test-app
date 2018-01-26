
namespace Planner_app
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] MainMenuPunkts = {
                " Add Task    ",
                " Delete Task ",
                " Edit Task   ",
                " View Tasks  ",
                " Load Plan   ",
                " Save Plan   ",
                " Exit        "
            };

            string[] YesNoMenuPunkts =
            {
                "   Sure    ",
                " Missclick "
            };

            Menu MainMenu = new Menu (title: "   Menu", menuPunkts: MainMenuPunkts);
            Menu YesNoMenu = new Menu(y : 2, menuPunkts: YesNoMenuPunkts, title : "  Exit ??? ");
            Planner planner = new Planner();

            while (true)
            {
                switch (MainMenu.StartMenu())
                { 
                    case 0:
                        planner.AddTodo();
                        break;
                    case 1:
                        planner.DeleteTodo();
                        break;
                    case 2:
                        planner.EditTodo();
                        break;
                    case 3:
                        planner.DisplayTodos();
                        break;
                    case 4:
                        planner.LoadFile();
                        break;
                    case 5:
                        planner.SaveFile();
                        break;
                    case 6:
                        if (YesNoMenu.StartMenu() == 0) {
                            return;
                        }
                        break;
                }
            }
        }
    }
}
