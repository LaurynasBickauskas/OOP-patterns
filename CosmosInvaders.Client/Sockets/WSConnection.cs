using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNet.SignalR.Client;
using CosmosInvaders.Library;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace CosmosInvaders.Client
{
    public class WSConnection
    {
        private static string URL = "http://localhost:54973";
        private static string HUB_ID = "ChatHub";

        private HubConnection connection;
        private IHubProxy hub;
        private Game game;
        private IDraw GameDraw { get; set; }
        private string PlayerName => GetUserName();
        private string PlayerFamily => GetUserFamily();
        private string PlayerShip => GetUserShip();

        public delegate string GetStringDelegate();

        public event GetStringDelegate GetUserName;

        public event GetStringDelegate GetUserFamily;

        public event GetStringDelegate GetUserShip;

        public delegate void SetStringDelegate(string text);

        public delegate void SetTupleDelegate(Tuple<string, string> text);

        public event SetStringDelegate SetSpeed;

        public event SetStringDelegate SetDirection;

        public event SetStringDelegate SetLog;

        public event SetStringDelegate SetPosLog;

        public event SetStringDelegate SetGameLog;

        public event SetTupleDelegate SetMessage;


        public WSConnection(Game game, IDraw gameDraw)
        {
            this.game = game;
            GameDraw = gameDraw;
            CreateConnection();
        }

        public void Start()
        {
            connection.Start().ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                    StartListeners();
                    //hub.Invoke<string>("GetPlayers");
                }
            }).Wait();
        }

        public void Stop()
        {
            connection.Stop();
        }

        public void Recive()
        {
        }

        public void Connect(string playerName, string family, string type)
        {
            hub.Invoke<string>("Connect", playerName, family, type);
        }

        public void Move(string playerName, char key)
        {
            hub.Invoke<string>("Move", playerName, key);
        }

        public void SendMessage(string playerName, string message)
        {
            hub.Invoke<string>("Message", playerName, message);
        }

        public void Disconnect()
        {
            hub.Invoke<string>("Disconnect", PlayerName);
        }


        public string GetName(int index)
        {
            try
            {
                return game.Ships[index].PlayerName;
            }
            catch { }
            return "";
            
        }

        public void Send(string methodName)
        {
            hub.Invoke<string>(methodName);
        }

        private void StartListeners()
        {
            ///StartMapListener();
            StartConnectedListener();
            StartItemListener();
            StartSingleCarListener();
            StartGotObstaclesListener();
            StartMovedListener();
            StartJoinedTheGameListener();
            LogListener();
            MessageListener();
            StartDisconnectedListener();
        }

        private void StartSingleCarListener()
        {
            hub.On("SingleCar", (ship) =>
            {
                string playerName = (ship as Ship).PlayerName;
                Ship localShip = game.Ships.Find(x => x.PlayerName == playerName);
                localShip = ship;
            });
        }

        private void StartConnectedListener()
        {
            hub.On("Connected", (ships) =>
            {
                game.Ships = new List<Ship>();
                List<Ship> serverShips = JsonConvert.DeserializeObject<List<Ship>>(ships);
                foreach (Ship v in serverShips)
                {
                    game.Ships.Add(v);
                }

                Ship localShip = serverShips.Find(x => x.PlayerName == PlayerName);
                localShip.CoordinateY = 200;
                localShip.CoordinateX = 200;

                GameDraw.DrawShips(serverShips);
                SetLog(JsonConvert.SerializeObject(serverShips.Select(x => x.PlayerName)));
            });
        }

        private void StartJoinedTheGameListener()
        {
            hub.On("JoinedTheGame", (message) =>
            {
            });
        }

        private void StartDisconnectedListener()
        {
            hub.On("Disconnected", (playerName) =>
            {
                Ship vehicteToDelete = game.Ships.FirstOrDefault(x => x.PlayerName == playerName);
                game.ObservableShips.Remove(vehicteToDelete);
                game.Ships.Remove(vehicteToDelete);
                GameDraw.DrawShips(game.Ships);
            });
        }

        private int saves = 0;

        private void StartMovedListener()
        {
            hub.On("Moved", (ship) =>
            {
                if (game.Ships.Count == 0)
                    return;

                Ship serverShip = JsonConvert.DeserializeObject<Ship>(ship);
                Ship playerShip = game.Ships.Find(x => x.PlayerName == serverShip.PlayerName);
                if (playerShip == null)
                {
                    game.Ships.Add(serverShip);
                    playerShip = game.Ships.Find(x => x.PlayerName == serverShip.PlayerName);
                    SetLog(JsonConvert.SerializeObject(game.Ships.Select(x => x.PlayerName)));
                }

                playerShip.CoordinateX = serverShip.CoordinateX;
                playerShip.CoordinateY = serverShip.CoordinateY;
                playerShip.FlyingDirection = serverShip.FlyingDirection;

                if (serverShip.PlayerName == PlayerName)
                {
                    SetSpeed(serverShip.Speed.ToString());
                    SetDirection(serverShip.FlyingDirection.ToString());
                }

                GameDraw.DrawShips(game.Ships);
            });
        }

        private void LogListener()
        {
            hub.On("Logged", (message) =>
            {
                string logMessage = JsonConvert.DeserializeObject<string>(message);
                SetGameLog(logMessage);
            });
        }

        private void MessageListener()
        {
            hub.On("Messaged", (message) =>
            {
                Tuple<string, string> playerMessage = JsonConvert.DeserializeObject<Tuple<string, string>>(message);
                SetMessage(playerMessage);
            });
        }

        private void StartGotObstaclesListener()
        {
            hub.On("GotObstacles", (obstacles) =>
            {
                //<Obstacle> obst = JsonConvert.DeserializeObject<Ship>(ship);
            });
        }

        private void StartItemListener()
        {
            hub.On("broadcastMessage", (message) =>
            {
            });
        }

        //private void StartMapListener()
        //{
        //    hub.On<Survivio.Models.Map>("mapMessage", (message) =>
        //    {
        //        game.SetMap(message);
        //    });
        //}

        private void CreateConnection()
        {
            connection = new HubConnection(URL);
            CreateHub();
        }

        private void CreateHub()
        {
            hub = connection.CreateHubProxy(HUB_ID);
        }
    }
}