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

        public void SetType(FieldType type, Direction dir)
        {
            switch (type)
            {
                case FieldType.empty:
                    Type = FieldType.empty;
                    GridImage = "";
                    break;
                case FieldType.hackable:
                    Type = FieldType.hackable;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/firewall.png";
                    break;
                case FieldType.unhackable:
                    Type = FieldType.unhackable;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/unbreakable.png";
                    break;
                case FieldType.powerup:
                    Type = FieldType.powerup;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/bitcoin.png";
                    break;
                case FieldType.temporary:
                    Type = FieldType.temporary;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/laptop.png";
                    break;
                case FieldType.player:
                    switch (dir)
                    {
                        case Direction.up:
                            Type = FieldType.player;
                            GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanup.png";
                            break;
                        case Direction.down:
                            Type = FieldType.player;
                            GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmandown.png";
                            break;
                        case Direction.left:
                            Type = FieldType.player;
                            GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanleft.png";
                            break;
                        case Direction.right:
                            Type = FieldType.player;
                            GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanright.png";
                            break;
                        default: break;
                    }
                    break;
                default: break;
            }
        }

        public FieldType Type { get; set; }
        public String GridImage { get; set; }
        public Position Position { get; set; }
    }
}
