using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.GameLogic.Model;

namespace Server.GameLogic.Helper
{
    public class ConvertGameboardToString
    {
        private List<string> _converted;

        public List<string> ConvertGameboard(List<GameField> GameBoard)
        {
            _converted = new List<string>();

            foreach (GameField field in GameBoard)
            {
                string temp = field.TypeToString();
                _converted.Add(temp);
            }

            return _converted;
        }
    }
}
