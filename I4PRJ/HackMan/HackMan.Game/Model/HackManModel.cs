using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
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
        power
    };

    public enum FieldState
    {
        hacker,
        laptop,
        firewall,
        unbreakable,
        empty
    }

    public class HackManModel
    {
        #region Commands

        public HackManModel()
        {

        }

        public void MoveHacker(Direction dir)
        {

        }

        public void PlaceLaptop()
        {

        }

        public void BuyPower(Powerup pow)
        {

        }

        #endregion

        #region Properties

        #endregion
    }
}
