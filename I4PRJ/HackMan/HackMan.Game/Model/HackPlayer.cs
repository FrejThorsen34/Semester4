using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public class HackPlayer
    {
        public HackPlayer()
        {
            HackPower = 1;
            Laptops = 5;
            Bitcoins = 5;
            LaptopPlaced = new List<Laptop>();
        }

        #region Commands

        public int LaptopPrice()
        {
            return Laptops + 1;
        }

        public int HackPowerPrice()
        {
            return HackPower + 1;
        }

        public void PlaceLaptop(Position pos)
        {
            LaptopPlaced.Add(new Laptop(pos));
        }
        #endregion

        #region Properties
        public int HackPower { get; set; }
        public int Laptops { get; set; }
        public int Bitcoins { get; set; }
        public List<Laptop> LaptopPlaced { get; set; }
        #endregion
    }
}
