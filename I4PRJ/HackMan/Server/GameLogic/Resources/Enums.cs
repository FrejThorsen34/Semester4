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
        right
    };
    public enum Powerup
    {
        laptop,
        laptoplength
    };
    public enum FieldType
    {
        playerdown,
        playerup,
        playerleft,
        playerright,
        bitcoin,
        laptop,
        firewall,
        unbreakable,
        explosion,
        empty,
        playeruplaptop,
        playerdownlaptop,
        playerleftlaptop,
        playerrightlaptop
    }
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
