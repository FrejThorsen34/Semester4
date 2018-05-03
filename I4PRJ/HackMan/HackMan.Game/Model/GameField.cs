﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public class GameField
    {
        public GameField()
        {

        }
        public GameField(Position position, FieldState field)
        {
            Position = position;
            SetGridImage(field);
        }

        public void SetGridImage(FieldState field)
        {
            switch (field)
            {
                case FieldState.hackerup:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanup.png";
                    break;
                case FieldState.hackerdown:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmandown.png";
                    break;
                case FieldState.hackerleft:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanleft.png";
                    break;
                case FieldState.hackerright:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/hackmanright.png";
                    break;
                case FieldState.firewall:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/firewall.png";
                    break;
                case FieldState.laptop:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/laptop.png";
                    break;
                case FieldState.unbreakable:
                    GridImage = "/HackMan.Game;component/ViewModel/HackManResources/unbreakable.png";
                    break;
                case FieldState.empty:
                    GridImage = "";
                    break;
                default:
                    GridImage = "";
                    break;
            }
        }        

        public String GridImage { get; set; }
        public Position Position { get; set; }
    }
}
