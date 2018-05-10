using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GameLogic.Helper
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        #region Commands
        public int FieldIndex()
        {
            return ((HackManModel.NumberOfColumns * Row) + Column);
        }

        public int FieldAbove()
        {
            return ((HackManModel.NumberOfColumns * (Row - 1)) + Column);
        }

        public int FieldBelow()
        {
            return ((HackManModel.NumberOfColumns * (Row + 1)) + Column);
        }

        public int FieldLeft()
        {
            return ((HackManModel.NumberOfColumns * Row) + Column - 1);
        }

        public int FieldRight()
        {
            return ((HackManModel.NumberOfColumns * Row) + Column + 1);
        }
        #endregion
    }
}
