using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.GameLogic.Helper;
using Server.GameLogic.Resources;

namespace Server.GameLogic.Model
{
    public class GameField
    {
        public GameField()
        {

        }

        public GameField(Position position, FieldType field)
        {
            Position = position;
            SetType(field);
        }

        public void SetType(FieldType type)
        {
            switch (type)
            {
                case FieldType.empty:
                    Type = FieldType.empty;
                    SimpleType = SimpleType.empty;
                    GridImage = "";
                    break;
                case FieldType.firewall:
                    Type = FieldType.firewall;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/firewall.png";
                    break;
                case FieldType.unbreakable:
                    Type = FieldType.unbreakable;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/unbreakable.png";
                    break;
                case FieldType.bitcoin:
                    Type = FieldType.bitcoin;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/bitcoin.png";
                    break;
                case FieldType.laptop:
                    Type = FieldType.laptop;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/laptop.png";
                    break;
                case FieldType.playerup:
                    Type = FieldType.playerup;
                    SimpleType = SimpleType.player;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanup.png";
                    break;
                case FieldType.playerdown:
                    Type = FieldType.playerdown;
                    SimpleType = SimpleType.player;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmandown.png";
                    break;
                case FieldType.playerleft:
                    Type = FieldType.playerleft;
                    SimpleType = SimpleType.player;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanleft.png";
                    break;
                case FieldType.playerright:
                    Type = FieldType.playerright;
                    SimpleType = SimpleType.player;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanright.png";
                    break;
                case FieldType.playeruplaptop:
                    Type = FieldType.playeruplaptop;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanupbomb.png";
                    break;
                case FieldType.playerdownlaptop:
                    Type = FieldType.playerdownlaptop;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmandownbomb.png";
                    break;
                case FieldType.playerrightlaptop:
                    Type = FieldType.playerrightlaptop;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanrightbomb.png";
                    break;
                case FieldType.playerleftlaptop:
                    Type = FieldType.playerleftlaptop;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanleftbomb.png";
                    break;
                case FieldType.explosion:
                    Type = FieldType.explosion;
                    SimpleType = SimpleType.thing;
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/explosion.png";
                    break;
                default: break;
            }
        }

        public FieldType Type { get; set; }
        public SimpleType SimpleType { get; set; }
        public String GridImage { get; set; }
        public Position Position { get; set; }
    }
}
