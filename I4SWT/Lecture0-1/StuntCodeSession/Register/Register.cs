using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register
{
    public interface IRegister
    {
        void AddItem(double item);
        int GetItemSum();
        double GetTotal();
    }

    public class MyRegister : IRegister
    {
        private List<double> _items = new List<double>();
        public void AddItem(double item)
        {
            _items.Add(item);
        }

        public int GetItemSum()
        {
            return _items.Count;
        }

        public double GetTotal()
        {
            return _items.Sum();
        }
    }
}
