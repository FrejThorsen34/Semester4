using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
        right
    };
    public enum Powerup
    {
        laptop,
        laptoplength
    };
    public enum FieldType
    {
        playerdown,
        playerup,
        playerleft,
        playerright,
        bitcoin,
        laptop,
        firewall,
        unbreakable,
        explosion,
        empty,
        playeruplaptop,
        playerdownlaptop,
        playerleftlaptop,
        playerrightlaptop
    }
    public enum SimpleType
    {
        player,
        empty,
        thing
    }

    public class HackManModel
    {
        #region Variables

        private Position HackManPosition;
        private ObservableCollection<GameField> _gameBoard;
        private ObservableCollection<SidePanelItem> _powerUps;
        //Laptop additions
        private System.Timers.Timer _timer;
        private List<Laptop> _laptops;
        public event EventHandler TimeChanged;
        private Player _player;
        public static int NumberOfColumns = 14;
        public static int NumberOfRows = 14;
        private Client _client;
        private int _tempId;

        #endregion

        #region Commands

        public HackManModel(Client client)
        {
            Random ran = new Random();
            _tempId = ran.Next(5000);
            _client = client;
            HackManPosition = new Position();
            GameBoard = new ObservableCollection<GameField>();
            PowerUps = new ObservableCollection<SidePanelItem>();
            _player = new Player();
            //Laptop additions
            _laptops = new List<Laptop>();
            _timer = new System.Timers.Timer();
            _timer.Interval = 100;
            _timer.Elapsed += TimerTick;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            //
            JoinGame();
            GenerateGameBoard();
            GenerateSidePanelItems();
        }

        private void JoinGame()
        {
            Debug.WriteLine($"Sending join and {_tempId}");
            _client.Send("join" + ";" + _tempId);
            Debug.WriteLine($"Waiting for join-reply");
            string response = _client.Receive();
            Debug.WriteLine($"Join reply received" + response);
        }
        private void TimerTick(object sender, EventArgs e)
        {
            var toBeRemoved = new List<Laptop>();

            lock (_laptops)
            {
                foreach (var laptop in _laptops)
                {
                    laptop.CheckState(this, null);
                    if (laptop.Remove == true)
                    {
                        toBeRemoved.Add(laptop);
                    }
                }
            }

            for (int i = 0; i < toBeRemoved.Count; i++)
            {
                lock (_laptops)
                {
                    _laptops.Remove(toBeRemoved[i]);
                }
            }
        }

        public void MoveHacker(Direction dir)
        {
            GameField moveFrom = new GameField();
            GameField moveTo = new GameField();
            SimpleType type;
            switch (dir)
            {
                case Direction.up:
                    moveFrom = GameBoard[HackManPosition.FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerup);
                    moveFrom.Position.Row--;
                    moveTo = GameBoard[HackManPosition.FieldAbove()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                        var tempBitcoin = PowerUps[0];
                        tempBitcoin.Value++;
                        PowerUps[0] = tempBitcoin;
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
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                        var tempBitcoin = PowerUps[0];
                        tempBitcoin.Value++;
                        PowerUps[0] = tempBitcoin;
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
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                        var tempBitcoin = PowerUps[0];
                        tempBitcoin.Value++;
                        PowerUps[0] = tempBitcoin;
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
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                        var tempBitcoin = PowerUps[0];
                        tempBitcoin.Value++;
                        PowerUps[0] = tempBitcoin;
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

        public bool CanStep(string command)
        {
            _client.Send(command + ";" + _tempId);
            string returnMessage = _client.Receive();
            switch (returnMessage)
            {
                case "moveup":
                    if (HackManPosition.Row == 0)
                        return false;
                    if (GameBoard[HackManPosition.FieldAbove()].Type != FieldType.empty && GameBoard[HackManPosition.FieldAbove()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case "movedown":
                    if (HackManPosition.Row == NumberOfRows - 1)
                        return false;
                    if (GameBoard[HackManPosition.FieldBelow()].Type != FieldType.empty && GameBoard[HackManPosition.FieldBelow()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case "moveleft":
                    if (HackManPosition.Column == 0)
                        return false;
                    if (GameBoard[HackManPosition.FieldLeft()].Type != FieldType.empty && GameBoard[HackManPosition.FieldLeft()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case "moveright":
                    if (HackManPosition.Column == NumberOfColumns - 1)
                        return false;
                    if (GameBoard[HackManPosition.FieldRight()].Type != FieldType.empty && GameBoard[HackManPosition.FieldRight()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case "no":
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

            _laptops.Add(new Laptop(this, _player, HackManPosition, _player.LaptopLength));
            _player.Laptops--;
        }

        public bool CanPlaceLaptop()
        {
            _client.Send("placelaptop" + ";" + _tempId);
            string returnMessage = _client.Receive();
            if (returnMessage == "no")
                return false;
            return true;
        }

        public void BuyLaptop()
        {
            var tempBitcoin = PowerUps[0];
            var tempLaptop = PowerUps[1];
            Player.Bitcoins -= (Player.MaxLaptops + 1);
            Player.MaxLaptops++;
            tempBitcoin.Value -= Player.MaxLaptops;
            tempLaptop.Value++;
            PowerUps[0] = tempBitcoin;
            PowerUps[1] = tempLaptop;
        }

        public void BuyLaptopLength()
        {
            var tempBitcoin = PowerUps[0];
            var tempLaptopLength = PowerUps[2];
            Player.Bitcoins -= (Player.LaptopLength + 1);
            Player.LaptopLength++;
            tempBitcoin.Value -= Player.LaptopLength;
            tempLaptopLength.Value++;
            PowerUps[0] = tempBitcoin;
            PowerUps[2] = tempLaptopLength;
        }

        public bool CanBuy(Powerup power)
        {
            switch (power)
            {
                case Powerup.laptop:
                    if (_player.Bitcoins > _player.MaxLaptops + 1)
                        return true;
                    return false;
                case Powerup.laptoplength:
                    if (_player.Bitcoins > _player.LaptopLength + 1)
                        return true;
                    return false;
                default: return false;
            }
        }

        public void GenerateGameBoard()
        {
            Debug.WriteLine("Generate GameBoard called");
            Debug.WriteLine("Sending start to server");
            string status = "started";
            int listCounter = 0;
            while (status != "end")
            {
                _client.Send("start");
                status = _client.Receive();
                switch (status)
                {
                    case "empty":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.empty);
                        break;
                    case "firewall":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.firewall);
                        break;
                    case "explosion":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.explosion);
                        break;
                    case "unbreakable":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.unbreakable);
                        break;
                    case "laptop":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.laptop);
                        break;
                    case "bitcoin":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.bitcoin);
                        break;
                    case "playerup":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerup);
                        break;
                    case "playeruplaptop":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playeruplaptop);
                        break;
                    case "playerdown":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerdown);
                        break;
                    case "playerdownlaptop":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerdownlaptop);
                        break;
                    case "playerleft":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerleft);
                        break;
                    case "playerleftlaptop":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerleftlaptop);
                        break;
                    case "playerright":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerright);
                        break;
                    case "playerrightlaptop":
                        GameBoard.Add(new GameField { Position = new Position { Column = listCounter % NumberOfColumns, Row = listCounter / NumberOfColumns } });
                        GameBoard[listCounter].SetType(FieldType.playerrightlaptop);
                        break;
                }

                listCounter++;
            }            
        }

        public void GenerateSidePanelItems()
        {
            var bitcoins = new SidePanelItem {Type = "Bitcoin", Value = Player.Bitcoins};
            var laptops = new SidePanelItem { Type = "Laptops", Value = Player.MaxLaptops };
            var laptoplength = new SidePanelItem { Type = "LaptopLength", Value = Player.LaptopLength };
            PowerUps.Add(bitcoins);
            PowerUps.Add(laptops);
            PowerUps.Add(laptoplength);
        }

        #endregion

        #region Properties
        public Player Player
        {
            get { return _player; }
            set
            {
                if (_player != value)
                    _player = value;
            }
        }

        public ObservableCollection<SidePanelItem> PowerUps
        {
            get { return _powerUps; }
            set
            {
                if (value != _powerUps)
                    _powerUps = value;
            }
        }
        public ObservableCollection<GameField> GameBoard
        {
            get { return _gameBoard; }
            set
            {
                if (value != _gameBoard)
                {
                    _gameBoard = value;
                }
            }
        }

        #endregion
    }
}
