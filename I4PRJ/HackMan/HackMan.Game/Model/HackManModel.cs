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
        private int NumberOfColumns = 14;
        private int NumberOfRows = 14;

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
                    GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column].SetGridImage(FieldState.empty);
                    GameBoard[(NumberOfColumns * HackManPosition.Row - 1) + HackManPosition.Column].SetGridImage(FieldState.hacker);
                    HackManPosition.Row--;
                    break;
                case Direction.down:
                    GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column].SetGridImage(FieldState.empty);
                    GameBoard[(NumberOfColumns * HackManPosition.Row + 1) + HackManPosition.Column].SetGridImage(FieldState.hacker);
                    HackManPosition.Row++;
                    break;
                case Direction.left:
                    GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column].SetGridImage(FieldState.empty);
                    GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column - 1].SetGridImage(FieldState.hacker);
                    HackManPosition.Column--;
                    break;
                case Direction.right:
                    GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column].SetGridImage(FieldState.empty);
                    GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column + 1].SetGridImage(FieldState.hacker);
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
                    if (GameBoard[(NumberOfColumns * (HackManPosition.Row - 1)) + HackManPosition.Column].GridImage != "")
                        return false;
                    return true;
                case Direction.down:
                    if (HackManPosition.Row == NumberOfRows - 1)
                        return false;
                    if (GameBoard[(NumberOfColumns * (HackManPosition.Row + 1)) + HackManPosition.Column].GridImage != "")
                        return false;
                    return true;
                case Direction.left:
                    if (HackManPosition.Column == 0)
                        return false;
                    if (GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column - 1].GridImage != "")
                        return false;
                    return true;
                case Direction.right:
                    if (HackManPosition.Column == NumberOfColumns - 1)
                        return false;
                    if (GameBoard[(NumberOfColumns * HackManPosition.Row) + HackManPosition.Column + 1].GridImage != "")
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
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.hacker);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "FW":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.firewall);
                            break;
                        case "EP":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.empty);
                            break;
                        case "UB":
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
                            GameBoard[listCounter].SetGridImage(FieldState.unbreakable);
                            break;
                        default:
                            GameBoard.Add(new GameField { Column = columnCounter, Row = rowCounter });
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
