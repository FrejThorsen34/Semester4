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
        private List<Player> _players;
        //Laptop additions
        private List<Laptop> _laptops;
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
            _players = new List<Player>();
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
                        case "join":
                            if (JoinGame(collection[1]))
                            {
                                string join = "gamejoined";
                                Console.WriteLine($"Sending back {join}");
                                byte[] sendJoin = Encoding.ASCII.GetBytes(join);
                                UdpServerClient.Send(sendJoin, sendJoin.Length, clientEndPoint);
                            }
                            else
                            {
                                string join = "no";
                                Console.WriteLine($"Sending back {join}");
                                byte[] sendJoin = Encoding.ASCII.GetBytes(join);
                                UdpServerClient.Send(sendJoin, sendJoin.Length, clientEndPoint);
                            }
                            break;
                        case "start":
                            GenerateGameBoard();
                            string message = "gamestarted";
                            Console.WriteLine($"Sending back {message}");
                            byte[] sendStart = Encoding.ASCII.GetBytes(message);
                            UdpServerClient.Send(sendStart, sendStart.Length, clientEndPoint);
                            break;
                        case "moveup":
                            if (CanStep(Direction.up, collection[1]))
                            {
                                MoveHacker(Direction.up, collection[1]);
                                string command = "moveup";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "movedown":
                            if (CanStep(Direction.down, collection[1]))
                            {
                                MoveHacker(Direction.down, collection[1]);
                                string command = "movedown";
                                Console.WriteLine($"Sending back {command}");
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
                            if (CanStep(Direction.left, collection[1]))
                            {
                                MoveHacker(Direction.left, collection[1]);
                                string command = "moveleft";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "moveright":
                            if (CanStep(Direction.right, collection[1]))
                            {
                                MoveHacker(Direction.right, collection[1]);
                                string command = "moveright";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            break;
                        case "placelaptop":
                            if (CanPlaceLaptop(collection[1]))
                            {
                                PlaceLaptop(collection[1]);
                                string command = "laptopplaced";
                                Console.WriteLine($"Sending back {command}");
                                byte[] sendCommand = Encoding.ASCII.GetBytes(command);
                                UdpServerClient.Send(sendCommand, sendCommand.Length, clientEndPoint);
                            }
                            else
                            {
                                string command = "no";
                                Console.WriteLine($"Sending back {command}");
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

        public bool JoinGame(string id)
        {
            if (PlayerPositions.Count > 2)
                return false;
            else
            {
                PlayerPositions.Add(new Position());
            }

            int index = PlayerPositions.Count - 1;
            Player player = new Player(id, index);
            _players.Add(player);
            PlayerPositions.Add(new Position());
            return true;
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
                            if (!PlayerPositions[0].Set)
                            {
                                PlayerPositions[0].Column = columnCounter;
                                PlayerPositions[0].Row = rowCounter;
                                PlayerPositions[0].Set = true;
                            }
                            else
                            {
                                PlayerPositions[1].Column = columnCounter;
                                PlayerPositions[1].Row = rowCounter;
                                PlayerPositions[1].Set = true;
                            }
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

        public void MoveHacker(Direction dir, string id)
        {
            GameField moveFrom = new GameField();
            GameField moveTo = new GameField();
            SimpleType type;
            Player player = _players.FirstOrDefault(p => p.Id == id);
            int playerToMove = player.PositionIndex;
            switch (dir)
            {
                case Direction.up:
                    moveFrom = GameBoard[PlayerPositions[playerToMove].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerup);
                    moveFrom.Position.Row--;
                    moveTo = GameBoard[PlayerPositions[playerToMove].FieldAbove()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Row++;
                    GameBoard[PlayerPositions[playerToMove].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[playerToMove].FieldAbove()] = moveFrom;
                    PlayerPositions[playerToMove].Row--;
                    break;
                case Direction.down:
                    moveFrom = GameBoard[PlayerPositions[playerToMove].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerdown);
                    moveFrom.Position.Row++;
                    moveTo = GameBoard[PlayerPositions[playerToMove].FieldBelow()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Row--;
                    GameBoard[PlayerPositions[playerToMove].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[playerToMove].FieldBelow()] = moveFrom;
                    PlayerPositions[playerToMove].Row++;
                    break;
                case Direction.left:
                    moveFrom = GameBoard[PlayerPositions[playerToMove].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerleft);
                    moveFrom.Position.Column--;
                    moveTo = GameBoard[PlayerPositions[playerToMove].FieldLeft()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Column++;
                    GameBoard[PlayerPositions[playerToMove].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[playerToMove].FieldLeft()] = moveFrom;
                    PlayerPositions[playerToMove].Column--;
                    break;
                case Direction.right:
                    moveFrom = GameBoard[PlayerPositions[playerToMove].FieldIndex()];
                    type = moveFrom.SimpleType;
                    moveFrom.SetType(FieldType.playerright);
                    moveFrom.Position.Column++;
                    moveTo = GameBoard[PlayerPositions[playerToMove].FieldRight()];
                    if (moveTo.Type == FieldType.bitcoin)
                    {
                        player.Bitcoins++;
                    }
                    if (type == SimpleType.thing)
                        moveTo.SetType(FieldType.laptop);
                    else
                    {
                        moveTo.SetType(FieldType.empty);
                    }
                    moveTo.Position.Column--;
                    GameBoard[PlayerPositions[playerToMove].FieldIndex()] = moveTo;
                    GameBoard[PlayerPositions[playerToMove].FieldRight()] = moveFrom;
                    PlayerPositions[playerToMove].Column++;
                    break;
                default: break;
            }
        }

        public bool CanStep(Direction dir, string id)
        {
            int playerToCheck = _players.FirstOrDefault(p => p.Id == id).PositionIndex;
            switch (dir)
            {
                case Direction.up:
                    if (PlayerPositions[playerToCheck].Row == 0)
                        return false;
                    if (GameBoard[PlayerPositions[playerToCheck].FieldAbove()].Type != FieldType.empty && GameBoard[PlayerPositions[playerToCheck].FieldAbove()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case Direction.down:
                    if (PlayerPositions[playerToCheck].Row == NumberOfRows - 1)
                        return false;
                    if (GameBoard[PlayerPositions[playerToCheck].FieldBelow()].Type != FieldType.empty && GameBoard[PlayerPositions[playerToCheck].FieldBelow()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case Direction.left:
                    if (PlayerPositions[playerToCheck].Column == 0)
                        return false;
                    if (GameBoard[PlayerPositions[playerToCheck].FieldLeft()].Type != FieldType.empty && GameBoard[PlayerPositions[playerToCheck].FieldLeft()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                case Direction.right:
                    if (PlayerPositions[playerToCheck].Column == NumberOfColumns - 1)
                        return false;
                    if (GameBoard[PlayerPositions[playerToCheck].FieldRight()].Type != FieldType.empty && GameBoard[PlayerPositions[playerToCheck].FieldRight()].Type != FieldType.bitcoin)
                        return false;
                    return true;
                default:
                    return false;
            }
        }

        public void PlaceLaptop(string id)
        {
            Debug.WriteLine("PlaceLaptop in HackManModel was called");
            Player player = _players.FirstOrDefault(p => p.Id == id);
            int playerToPlaceLaptop = player.PositionIndex;
            GameField temp = new GameField();
            temp = GameBoard[PlayerPositions[playerToPlaceLaptop].FieldIndex()];
            switch (temp.Type)
            {
                case FieldType.playerup:
                    temp.SetType(FieldType.playeruplaptop);
                    GameBoard[PlayerPositions[playerToPlaceLaptop].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerUp PlaceLaptop");
                    break;
                case FieldType.playerdown:
                    temp.SetType(FieldType.playerdownlaptop);
                    GameBoard[PlayerPositions[playerToPlaceLaptop].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerDown PlaceLaptop");
                    break;
                case FieldType.playerleft:
                    temp.SetType(FieldType.playerleftlaptop);
                    GameBoard[PlayerPositions[playerToPlaceLaptop].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerLeft PlaceLaptop");
                    break;
                case FieldType.playerright:
                    temp.SetType(FieldType.playerrightlaptop);
                    GameBoard[PlayerPositions[playerToPlaceLaptop].FieldIndex()] = temp;
                    Debug.WriteLine("PlayerRight PlaceLaptop");
                    break;
            }

            _laptops.Add(new Laptop(this, player, PlayerPositions[playerToPlaceLaptop], player.LaptopLength));
            player.Laptops--;
        }


        public bool CanPlaceLaptop(string id)
        {
            Player player = _players.FirstOrDefault(p => p.Id == id);
            int playerToCheck = player.PositionIndex;
            if (player.Laptops == 0)
                return false;
            //Her burde der også være et check på, om spilleren allerede har placeret en bombe på dette felt.
            if (GameBoard[PlayerPositions[playerToCheck].FieldIndex()].SimpleType == SimpleType.thing)
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
        #endregion
    }
}
