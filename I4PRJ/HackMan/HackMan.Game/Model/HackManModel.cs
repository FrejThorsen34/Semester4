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
            switch (dir)
            {
                case Direction.up:
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.empty);
                    HackManPosition.Row--;
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.hacker);
                    NotifyPropertyChanged("GameBoard.GridImage");
                    break;
                case Direction.down:
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.empty);
                    HackManPosition.Row++;
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.hacker);
                    NotifyPropertyChanged("GameBoard.GridImage");
                    break;
                case Direction.left:
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.empty);
                    HackManPosition.Column--;
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.hacker);
                    NotifyPropertyChanged("GameBoard.GridImage");
                    break;
                case Direction.right:
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.empty);
                    HackManPosition.Column++;
                    GameBoard[HackManPosition.FieldIndex()].SetGridImage(FieldState.hacker);
                    NotifyPropertyChanged("GameBoard.GridImage");
                    break;
                default: break;
            }
        }

        public bool CanStep(Direction dir)
        {
            String check = "";
            switch (dir)
            {
                case Direction.up:
                    if (HackManPosition.Row == 0)
                        return false;
                    if (GameBoard[HackManPosition.FieldAbove()].GridImage != check)
                        return false;
                    return true;
                case Direction.down:
                    if (HackManPosition.Row == NumberOfRows - 1)
                        return false;
                    if (GameBoard[HackManPosition.FieldBelow()].GridImage != check)
                        return false;
                    return true;
                case Direction.left:
                    if (HackManPosition.Column == 0)
                        return false;
                    if (GameBoard[HackManPosition.FieldLeft()].GridImage != check)
                        return false;
                    return true;
                case Direction.right:
                    if (HackManPosition.Column == NumberOfColumns - 1)
                        return false;
                    if (GameBoard[HackManPosition.FieldRight()].GridImage != check)
                        return false;
                    return true;
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
                        case "HM":
                            GameBoard.Add(new GameField { Position = new Position{ Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetGridImage(FieldState.hacker);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "FW":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetGridImage(FieldState.firewall);
                            break;
                        case "EP":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetGridImage(FieldState.empty);
                            break;
                        case "UB":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetGridImage(FieldState.unbreakable);
                            break;
                        default:
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetGridImage(FieldState.empty);
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
