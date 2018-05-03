using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HackMan.Game;

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
        playerup,
        playerdown,
        playerleft,
        playerright,
        powerup,
        empty,
        hackable,
        unhackable,
        laptop,
        playeruplaptop,
        playerdownlaptop,
        playerleftlaptop,
        playerrightlaptop
    };

    public enum SimpleType
    {
        player,
        empty,
        thing
    }

    public class HackManModel : INotifyPropertyChanged
    {
        #region Variables

        private Position HackManPosition;
        private ObservableCollection<GameField> _gameBoard;
        private HackPlayer _hackPlayer;
        public static int NumberOfColumns = 14;
        public static int NumberOfRows = 14;

        #endregion

        #region Commands

        public HackManModel()
        {
            HackManPosition = new Position();
            GameBoard = new ObservableCollection<GameField>();
            HackPlayer = new HackPlayer();
            GenerateGameBoard();
        }

        public void MoveHacker(Direction dir)
        {
            GameField moveFrom = new GameField();
            GameField moveTo = new GameField();
            HackPlayer temp = new HackPlayer();
            SimpleType type = SimpleType.empty;
            switch (dir)
            {
                case Direction.up:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerup);
                    moveFrom.Position.Row--;
                    moveTo = GameBoard[HackManPosition.FieldAbove()];
                    if (moveTo.Type == FieldType.powerup)
                    {
                        temp = HackPlayer;
                        temp.Bitcoins++;
                        HackPlayer = temp;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }                    
                    moveTo.Position.Row++;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldAbove()] = moveFrom;
                    HackManPosition.Row--;
                    break;
                case Direction.down:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerdown);
                    moveFrom.Position.Row++;
                    moveTo = GameBoard[HackManPosition.FieldBelow()];
                    if (moveTo.Type == FieldType.powerup)
                    {
                        temp = HackPlayer;
                        temp.Bitcoins++;
                        HackPlayer = temp;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }            
                    moveTo.Position.Row--;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldBelow()] = moveFrom;
                    HackManPosition.Row++;
                    break;
                case Direction.left:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerleft);
                    moveFrom.Position.Column--;
                    moveTo = GameBoard[HackManPosition.FieldLeft()];
                    if (moveTo.Type == FieldType.powerup)
                    {
                        temp = HackPlayer;
                        temp.Bitcoins++;
                        HackPlayer = temp;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Column++;
                    GameBoard[HackManPosition.FieldIndex()] = moveTo;
                    GameBoard[HackManPosition.FieldLeft()] = moveFrom;
                    HackManPosition.Column--;
                    break;
                case Direction.right:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerright);
                    moveFrom.Position.Column++;
                    moveTo = GameBoard[HackManPosition.FieldRight()];
                    if (moveTo.Type == FieldType.powerup)
                    {
                        temp = HackPlayer;
                        temp.Bitcoins++;
                        HackPlayer = temp;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
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
            Debug.WriteLine("PlaceLaptop in HackManModel was called");
            GameField temp = new GameField();
            temp = GameBoard[HackManPosition.FieldIndex()];
            switch (temp.Type)
            {
                case FieldType.playerup:
                    temp.SetType(FieldType.playeruplaptop);
                    GameBoard[HackManPosition.FieldIndex()] = temp;
                    Debug.WriteLine("PlayerUp PlaceLaptop");
                    break;
                case FieldType.playerdown:
                    temp.SetType(FieldType.playerdownlaptop);
                    GameBoard[HackManPosition.FieldIndex()] = temp;
                    Debug.WriteLine("PlayerDown PlaceLaptop");
                    break;
                case FieldType.playerleft:
                    temp.SetType(FieldType.playerleftlaptop);
                    GameBoard[HackManPosition.FieldIndex()] = temp;
                    Debug.WriteLine("PlayerLeft PlaceLaptop");
                    break;
                case FieldType.playerright:
                    temp.SetType(FieldType.playerrightlaptop);
                    GameBoard[HackManPosition.FieldIndex()] = temp;
                    Debug.WriteLine("PlayerRight PlaceLaptop");
                    break;
            }
            HackPlayer.PlaceLaptop(HackManPosition);
        }

        public bool CanPlace()
        {
            if (HackPlayer.Laptops > HackPlayer.LaptopPlaced.Count())
            {
                Debug.WriteLine("CanPlace is returning true");
                return true;
            }
            Debug.Write("CanPlace is returning false");
            return false;
        }

        public void BuyPower(Powerup pow)
        {
            switch (pow)
            {
                case Powerup.power:
                    HackPlayer.Bitcoins = HackPlayer.Bitcoins - HackPlayer.HackPowerPrice();
                    HackPlayer.HackPower++;
                    break;
                case Powerup.laptop:
                    HackPlayer.Bitcoins = HackPlayer.Bitcoins - HackPlayer.LaptopPrice();
                    HackPlayer.Laptops++;
                    break;
                default:
                    break;
            }
        }

        public bool CanBuy(Powerup pow)
        {
            switch (pow)
            {
                case Powerup.power:
                    if (HackPlayer.Bitcoins >= HackPlayer.HackPowerPrice())
                        return true;
                    return false;
                case Powerup.laptop:
                    if (HackPlayer.Bitcoins >= HackPlayer.LaptopPrice())
                        return true;
                    return false;
                default:
                    return false;
            }
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
                            GameBoard[listCounter].SetType(FieldType.playerdown);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "HU":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.playerup);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "HL":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.playerleft);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "HR":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.playerright);
                            HackManPosition.Column = columnCounter;
                            HackManPosition.Row = rowCounter;
                            break;
                        case "UL":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.playeruplaptop);
                            break;
                        case "FW":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.hackable);
                            break;
                        case "EP":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.empty);
                            break;
                        case "UB":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.unhackable);
                            break;
                        case "BC":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.powerup);
                            break;
                        default:
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter}});
                            GameBoard[listCounter].SetType(FieldType.empty);
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

        public HackPlayer HackPlayer
        {
            get { return _hackPlayer; }
            set
            {
                if (value != _hackPlayer)
                {
                    _hackPlayer = value;
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
