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
        private string _converted;

        public string ConvertGameboard(List<GameField> GameBoard)
        {
            foreach (GameField field in GameBoard)
            {
                string temp = field.TypeToString();
                _converted = temp + ";";
            }

            return _converted;
        }
    }
}
