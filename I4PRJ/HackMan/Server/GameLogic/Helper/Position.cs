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
        public bool Set { get; set; }

        #region Commands
        public int FieldIndex()
        {
            return ((UdpServer.NumberOfColumns * Row) + Column);
        }

        public int FieldAbove()
        {
            return ((UdpServer.NumberOfColumns * (Row - 1)) + Column);
        }

        public int FieldBelow()
        {
            return ((UdpServer.NumberOfColumns * (Row + 1)) + Column);
        }

        public int FieldLeft()
        {
            return ((UdpServer.NumberOfColumns * Row) + Column - 1);
        }

        public int FieldRight()
        {
            return ((UdpServer.NumberOfColumns * Row) + Column + 1);
        }
        #endregion
    }
}
