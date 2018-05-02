using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public class GameField
    {
        public GameField()
        {

        }
        public GameField(int column, int row, FieldState field)
        {
            Column = column;
            Row = row;
            SetGridImage(field);
        }

        public void SetGridImage(FieldState field)
        {
            switch (field)
            {
                case FieldState.hacker:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackman.png";
                    break;
                case FieldState.firewall:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/firewall.png";
                    break;
                case FieldState.laptop:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/laptop.png";
                    break;
                case FieldState.unbreakable:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/unbreakable.png";
                    break;
                case FieldState.empty:
                    GridImage = "";
                    break;
                default:
                    GridImage = null;
                    break;
            }
        }
        public String GridImage { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
    }
}
