using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HackMan.Game
{
    public enum Direction
    {
        up,
        down,
        left,
        right,
        none
    };

    public enum Powerup
    {
        laptop,
        power
    };

    public enum FieldType
    {
        player,
        powerup,
        empty,
        hackable,
        unhackable,
        temporary
    };

    public class HackManModel : INotifyPropertyChanged
    {
        #region Variables

        private Position HackManPosition;
        private ObservableCollection<GameField> _gameBoard;
        public static int NumberOfColumns = 14;
        public static int NumberOfRows = 14;

        #endregion

        #region Commands

        public HackManModel()
        {
            HackManPosition = new Position();
            GameBoard = new ObservableCollection<GameField>();
            GenerateGameBoard();
        }

        public void MoveHacker(Direction dir)
        {
            GameField moveFrom = new GameField();
            GameField moveTo = new GameField();
            switch (dir)
            {
                case Direction.up:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    moveFrom.SetType(FieldType.player, Direction.up);
                    moveFrom.Position.Row--;
                    moveTo = GameBoard[HackManPosition.FieldAbove()];
                    moveTo.SetType(FieldType.empty, Direction.none);
                    moveTo.Position.Row++;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldAbove()] = moveFrom;
                    HackManPosition.Row--;
                    break;
                case Direction.down:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    moveFrom.SetType(FieldType.player, Direction.down);
                    moveFrom.Position.Row++;
                    moveTo = GameBoard[HackManPosition.FieldBelow()];
                    moveTo.SetType(FieldType.empty, Direction.none);
                    moveTo.Position.Row--;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldBelow()] = moveFrom;
                    HackManPosition.Row++;
                    break;
                case Direction.left:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    moveFrom.SetType(FieldType.player, Direction.left);
                    moveFrom.Position.Column--;
                    moveTo = GameBoard[HackManPosition.FieldLeft()];
                    moveTo.SetType(FieldType.empty, Direction.none);
                    moveTo.Position.Column++;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldLeft()] = moveFrom;
                    HackManPosition.Column--;
                    break;
                case Direction.right:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    moveFrom.SetType(FieldType.player, Direction.right);
                    moveFrom.Position.Column++;
                    moveTo = GameBoard[HackManPosition.FieldRight()];
                    moveTo.SetType(FieldType.empty, Direction.none);
                    moveTo.Position.Column--;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldRight()] = moveFrom;
                    HackManPosition.Column++;
                    break;
                default: break;
            }
        }

        public bool CanStep(Direction dir)
        {
            switch (dir)
            {
                case Direction.up:
                    if (HackManPosition.Row == 0)
                        return false;
                    if (GameBoard[HackManPosition.FieldAbove()].Type == FieldType.empty)
                        return true;
                    if (GameBoard[HackManPosition.FieldAbove()].Type == FieldType.powerup)
                        return true;
                    return false;
                case Direction.down:
                    if (HackManPosition.Row == NumberOfRows - 1)
                        return false;
                    if (GameBoard[HackManPosition.FieldBelow()].Type == FieldType.empty)
                        return true;
                    if (GameBoard[HackManPosition.FieldBelow()].Type == FieldType.powerup)
                        return true;
                    return false;
                case Direction.left:
                    if (HackManPosition.Column == 0)
                        return false;
                    if (GameBoard[HackManPosition.FieldLeft()].Type == FieldType.empty)
                        return true;
                    if (GameBoard[HackManPosition.FieldLeft()].Type == FieldType.powerup)
                        return true;
                    return false;
                case Direction.right:
                    if (HackManPosition.Column == NumberOfColumns - 1)
                        return false;
                    if (GameBoard[HackManPosition.FieldRight()].Type == FieldType.empty)
                        return true;
                    if (GameBoard[HackManPosition.FieldRight()].Type == FieldType.powerup)
                        return true;
                    return false;
                default:
                    return false;
            }
        }

        public void PlaceLaptop()
        {

        }

        public void BuyPower(Powerup pow)
        {

        }

        public void GenerateGameBoard()
        {
            String level = Properties.Resources.Level;
            String[] gameBoard = level.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int rowCounter = 0;
            int listCounter = 0;
            foreach (String row in gameBoard)
            {
                String[] columns = row.Split(' ');
                for (int columnCounter = 0; columnCounter < NumberOfColumns; columnCounter++)
                {
                    switch (columns[columnCounter])
                    {
                        case "HD":
                            GameBoard.Add(new GameField { Position = new Position{ Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.player, Direction.down);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "FW":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.hackable, Direction.none);
                            break;
                        case "EP":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.empty, Direction.none);
                            break;
                        case "UB":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.unhackable, Direction.none);
                            break;
                        case "BC":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.powerup, Direction.none);
                            break;
                        default:
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.empty, Direction.none);
                            break;
                    }                    
                    listCounter++;
                }
                rowCounter++;
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<GameField> GameBoard
        {
            get { return _gameBoard;}
            set
            {
                if (value != _gameBoard)
                {
                    _gameBoard = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
