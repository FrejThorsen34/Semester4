using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Server.GameLogic.Helper;
using Server.GameLogic.Model;
using Server.GameLogic.Resources;

namespace Server
{
    public class UdpServer
    {
        #region Variables
        private List<Position> PlayerPositions;
        private List<GameField> _gameBoard;
        //Laptop additions
        private List<Laptop> _laptops;
        private Player _player;
        public static int NumberOfColumns = 14;
        public static int NumberOfRows = 14;
        #endregion

        const int PORT = 9000;
        UdpClient UdpServerClient;
        IPEndPoint localIpEndPoint;
        IPEndPoint clientEndPoint;

        public List<string> Players;
        //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //Ctor creates server
        public UdpServer()
        {
            PlayerPositions = new List<Position>();
            GameBoard = new List<GameField>();
            _player = new Player();
            //Laptop additions
            _laptops = new List<Laptop>();
            Players = new List<string>();
            //Assign port number
            UdpServerClient = new UdpClient(PORT);

            //Allows the server to read data sent from any source on PORT
            localIpEndPoint = new IPEndPoint(IPAddress.Any, PORT);
        }

        public void Send()
        {

        }

        public void Receive()
        {

        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    //blocks until message received & get IP
                    Byte[] receiveBytes = UdpServerClient.Receive(ref localIpEndPoint); //listen on port 9000
                    string returnData = Encoding.ASCII.GetString(receiveBytes);
                    clientEndPoint = new IPEndPoint(localIpEndPoint.Address, PORT);

                    Console.WriteLine("Received input: " + returnData);

                    string[] collection = returnData.Split(';');
                    switch (collection[0])
                    {                       
                        case "start":
                            StartGame();
                            string message = "gamestarted";
                            byte[] sendStart = Encoding.ASCII.GetBytes(message);
                            UdpServerClient.Send(sendStart, sendStart.Length, clientEndPoint);
                            break;
                        case "moveup":
                            if (CanStep(Direction.up))
                            {
                                MoveHacker(Direction.up);
                                string command = "moveup";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "movedown":
                            if (CanStep(Direction.down))
                            {
                                MoveHacker(Direction.down);
                                string command = "movedown";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "moveleft":
                            if (CanStep(Direction.left))
                            {
                                MoveHacker(Direction.left);
                                string command = "moveleft";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "moveright":
                            if (CanStep(Direction.right))
                            {
                                MoveHacker(Direction.right);
                                string command = "moveright";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "placelaptop":
                            if (CanPlaceLaptop())
                            {
                                PlaceLaptop();
                                string command = "laptopplaced";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        #region GameLogic
        public void StartGame()
        {
            PlayerPositions.Add(new Position());
            GenerateGameBoard();
        }


        public void GenerateGameBoard()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"GameLogic\Resources\Level.txt");
            String level = File.ReadAllText(path);
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
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.playerdown);
                            PlayerPositions[0].Column = columnCounter;
                            PlayerPositions[0].Row = rowCounter;
                            break;
                        case "FW":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.firewall);
                            break;
                        case "EP":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.empty);
                            break;
                        case "UB":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.unbreakable);
                            break;
                        case "BC":
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.bitcoin);
                            break;
                        default:
                            GameBoard.Add(new GameField { Position = new Position { Column = columnCounter, Row = rowCounter } });
                            GameBoard[listCounter].SetType(FieldType.empty);
                            break;
                    }
                    listCounter++;
                }
                rowCounter++;
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
                    moveFrom = GameBoard[PlayerPositions[0].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerup);
                    moveFrom.Position.Row--;
                    moveTo = GameBoard[PlayerPositions[0].FieldAbove()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Row++;
                    GameBoard[PlayerPositions[0].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[0].FieldAbove()] = moveFrom;
                    PlayerPositions[0].Row--;
                    break;
                case Direction.down:
                    moveFrom = GameBoard[PlayerPositions[0].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerdown);
                    moveFrom.Position.Row++;
                    moveTo = GameBoard[PlayerPositions[0].FieldBelow()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Row--;
                    GameBoard[PlayerPositions[0].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[0].FieldBelow()] = moveFrom;
                    PlayerPositions[0].Row++;
                    break;
                case Direction.left:
                    moveFrom = GameBoard[PlayerPositions[0].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerleft);
                    moveFrom.Position.Column--;
                    moveTo = GameBoard[PlayerPositions[0].FieldLeft()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Column++;
                    GameBoard[PlayerPositions[0].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[0].FieldLeft()] = moveFrom;
                    PlayerPositions[0].Column--;
                    break;
                case Direction.right:
                    moveFrom = GameBoard[PlayerPositions[0].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerright);
                    moveFrom.Position.Column++;
                    moveTo = GameBoard[PlayerPositions[0].FieldRight()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        Player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Column--;
                    GameBoard[PlayerPositions[0].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[0].FieldRight()] = moveFrom;
                    PlayerPositions[0].Column++;
                    break;
                default: break;
            }
        }

        public bool CanStep(Direction dir)
        {
            switch (dir)
            {
                case Direction.up:
                    if (PlayerPositions[0].Row == 0)
                        return false;
                    if (GameBoard[PlayerPositions[0].FieldAbove()].Type != FieldType.empty && GameBoard[PlayerPositions[0].FieldAbove()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case Direction.down:
                    if (PlayerPositions[0].Row == NumberOfRows - 1)
                        return false;
                    if (GameBoard[PlayerPositions[0].FieldBelow()].Type != FieldType.empty && GameBoard[PlayerPositions[0].FieldBelow()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case Direction.left:
                    if (PlayerPositions[0].Column == 0)
                        return false;
                    if (GameBoard[PlayerPositions[0].FieldLeft()].Type != FieldType.empty && GameBoard[PlayerPositions[0].FieldLeft()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case Direction.right:
                    if (PlayerPositions[0].Column == NumberOfColumns - 1)
                        return false;
                    if (GameBoard[PlayerPositions[0].FieldRight()].Type != FieldType.empty && GameBoard[PlayerPositions[0].FieldRight()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                default:
                    return false;
            }
        }

        public void PlaceLaptop()
        {
            Debug.WriteLine("PlaceLaptop in HackManModel was called");
            GameField temp = new GameField();
            temp = GameBoard[PlayerPositions[0].FieldIndex()];
            switch (temp.Type)
            {
                case FieldType.playerup:
                    temp.SetType(FieldType.playeruplaptop);
                    GameBoard[PlayerPositions[0].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerUp PlaceLaptop");
                    break;
                case FieldType.playerdown:
                    temp.SetType(FieldType.playerdownlaptop);
                    GameBoard[PlayerPositions[0].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerDown PlaceLaptop");
                    break;
                case FieldType.playerleft:
                    temp.SetType(FieldType.playerleftlaptop);
                    GameBoard[PlayerPositions[0].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerLeft PlaceLaptop");
                    break;
                case FieldType.playerright:
                    temp.SetType(FieldType.playerrightlaptop);
                    GameBoard[PlayerPositions[0].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerRight PlaceLaptop");
                    break;
            }

            _laptops.Add(new Laptop(this, _player, PlayerPositions[0], _player.LaptopLength));
            _player.Laptops--;
        }


        public bool CanPlaceLaptop()
        {
            if (_player.Laptops == 0)
                return false;
            //Her burde der også være et check på, om spilleren allerede har placeret en bombe på dette felt.
            if (GameBoard[PlayerPositions[0].FieldIndex()].SimpleType == SimpleType.thing)
                return false;
            return true;
        }

        #endregion
        #region Properties
        public List<GameField> GameBoard
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

        public Player Player
        {
            get { return _player; }
            set
            {
                if (_player != value)
                    _player = value;
            }
        }
        #endregion
    }
}
