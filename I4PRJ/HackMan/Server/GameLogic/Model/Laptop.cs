using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.GameLogic.Helper;
using Server.GameLogic.Resources;

namespace Server.GameLogic.Model
{
    public class Laptop
    {
        public Player _owner;
        private Position _position;
        private List<Int32> _affectedFields;
        private List<Int32> _toDrop;
        private int _timeLeft;
        private RandomGenerator _randomGenerator;

        public bool Remove;
        //private int _powerLevel;


        public Laptop(UdpServer model, Player player, Position position, int laptopLenght)
        {
            _timeLeft = 30;
            _position = position;
            _affectedFields = new List<Int32>();
            _toDrop = new List<int>();
            _owner = player;
            _randomGenerator = new RandomGenerator();
            Remove = false;

            var positions = new List<Position>();
            var toDropPositions = new List<Position>();
            positions.Add(_position);

            bool lockedRight = false;
            bool lockedLeft = false;
            bool lockedUp = false;
            bool lockedDown = false;



            for (int i = 0; i <= laptopLenght; i++)
            {
                Position newPosition = position;

                if (position.Column + i < UdpServer.NumberOfColumns)
                {
                    newPosition = new Position { Column = _position.Column + i, Row = _position.Row };
                    if (model.GameBoard[newPosition.FieldIndex()].Type != FieldType.unbreakable && lockedRight == false)
                    {
                        positions.Add(newPosition);
                        if (model.GameBoard[newPosition.FieldIndex()].Type == FieldType.firewall)
                        {
                            toDropPositions.Add(newPosition);
                            lockedRight = true;
                        }
                    }
                    else
                        lockedRight = true;
                }

                if (position.Column - i >= 0)
                {
                    newPosition = new Position { Column = _position.Column - i, Row = _position.Row };
                    if (model.GameBoard[newPosition.FieldIndex()].Type != FieldType.unbreakable && lockedLeft != true)
                    {
                        positions.Add(newPosition);
                        if (model.GameBoard[newPosition.FieldIndex()].Type == FieldType.firewall)
                        {
                            toDropPositions.Add(newPosition);
                            lockedLeft = true;
                        }
                    }
                    else
                        lockedLeft = true;
                }

                if (position.Row + i < UdpServer.NumberOfRows)
                {
                    newPosition = new Position { Column = _position.Column, Row = _position.Row + i };
                    if (model.GameBoard[newPosition.FieldIndex()].Type != FieldType.unbreakable && lockedDown == false)
                    {
                        positions.Add(newPosition);
                        if (model.GameBoard[newPosition.FieldIndex()].Type == FieldType.firewall)
                        {
                            toDropPositions.Add(newPosition);
                            lockedDown = true;
                        }
                    }
                    else
                        lockedDown = true;
                }

                if (position.Row - i >= 0)
                {
                    newPosition = new Position { Column = _position.Column, Row = _position.Row - i };
                    if (model.GameBoard[newPosition.FieldIndex()].Type != FieldType.unbreakable && lockedUp == false)
                    {
                        positions.Add(newPosition);
                        if (model.GameBoard[newPosition.FieldIndex()].Type == FieldType.firewall)
                        {
                            toDropPositions.Add(newPosition);
                            lockedUp = true;
                        }
                    }
                    else
                        lockedUp = true;
                }
            }

            foreach (var p in positions)
            {
                _affectedFields.Add(p.FieldIndex());
            }

            foreach (var tdp in toDropPositions)
            {
                if (_randomGenerator.DropOrNotDrop())
                {
                    _toDrop.Add(tdp.FieldIndex());
                }
            }
        }        

    }
}
