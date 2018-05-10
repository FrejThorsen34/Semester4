using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GameLogic.Resources
{
    public enum Direction
    {
        up,
        down,
        left,
        right,
        none
    };

    public enum Powerup
    {
        laptop,
        power
    };

    public enum FieldType
    {
        playerup,
        playerdown,
        playerleft,
        playerright,
        powerup,
        empty,
        hackable,
        unhackable,
        laptop,
        playeruplaptop,
        playerdownlaptop,
        playerleftlaptop,
        playerrightlaptop
    };

    public enum SimpleType
    {
        player,
        empty,
        thing
    }
    public class Enums
    {
    }
}
