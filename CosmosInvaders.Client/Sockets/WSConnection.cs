using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNet.SignalR.Client;
using Racing2D.Library;
using Newtonsoft.Json;
using System.Windows.Forms;
using Racing2D.Library.Controllers.Memento;

namespace Racing2D.Client
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
        private string PlayerVehicle => GetUserVehicle();

        public delegate string GetStringDelegate();

        public event GetStringDelegate GetUserName;

        public event GetStringDelegate GetUserFamily;

        public event GetStringDelegate GetUserVehicle;

        public delegate void SetStringDelegate(string text);

        public delegate void SetTupleDelegate(Tuple<string, string> text);

        public event SetStringDelegate SetSpeed;

        public event SetStringDelegate SetDirection;

        public event SetStringDelegate SetLog;

        public event SetStringDelegate SetPosLog;

        public event SetStringDelegate SetGameLog;

        public event SetTupleDelegate SetMessage;

        public Originator originator = new Originator();
        public CareTaker careTaker = new CareTaker();

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

        public void MementoReposition(string playerName, int x, int y)
        {
            hub.Invoke<string>("MementoReposition", playerName, x, y);
        }

        public string GetName(int index)
        {
            try
            {
                return game.Vehicles[index].PlayerName;
            }
            catch { }
            return "";
            
        }

        public string Reset(string playerName)
        {
            if(playerName == "%default%")
            {
                hub.Invoke<string>("Disconnect", PlayerName);
                hub.Invoke<string>("Connect", PlayerName, PlayerFamily, PlayerVehicle);
            }
            else
            {
                hub.Invoke<string>("Disconnect", playerName);
                hub.Invoke<string>("Connect", playerName, PlayerFamily, PlayerVehicle);
            }
            
            return "reset success";
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
            hub.On("SingleCar", (vehicle) =>
            {
                string playerName = (vehicle as Vehicle).PlayerName;
                Vehicle localVehicle = game.Vehicles.Find(x => x.PlayerName == playerName);
                localVehicle = vehicle;
            });
        }

        private void StartConnectedListener()
        {
            hub.On("Connected", (vehicles) =>
            {
                game.Vehicles = new List<Vehicle>();
                List<Vehicle> serverVehicles = JsonConvert.DeserializeObject<List<Vehicle>>(vehicles);
                foreach (Vehicle v in serverVehicles)
                {
                    game.Vehicles.Add(v);
                }

                Vehicle localVehicle = serverVehicles.Find(x => x.PlayerName == PlayerName);
                localVehicle.CoordinateY = 200;
                localVehicle.CoordinateX = 200;

                GameDraw.DrawCars(serverVehicles);
                SetLog(JsonConvert.SerializeObject(serverVehicles.Select(x => x.PlayerName)));
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
                Vehicle vehicteToDelete = game.Vehicles.FirstOrDefault(x => x.PlayerName == playerName);
                game.ObservableVehicles.Remove(vehicteToDelete);
                game.Vehicles.Remove(vehicteToDelete);
                GameDraw.DrawCars(game.Vehicles);
            });
        }

        private int saves = 0;

        private void StartMovedListener()
        {
            hub.On("Moved", (vehicle) =>
            {
                if (game.Vehicles.Count == 0)
                    return;

                Vehicle serverVehicle = JsonConvert.DeserializeObject<Vehicle>(vehicle);
                Vehicle playerVehicle = game.Vehicles.Find(x => x.PlayerName == serverVehicle.PlayerName);
                if (playerVehicle == null)
                {
                    game.Vehicles.Add(serverVehicle);
                    playerVehicle = game.Vehicles.Find(x => x.PlayerName == serverVehicle.PlayerName);
                    SetLog(JsonConvert.SerializeObject(game.Vehicles.Select(x => x.PlayerName)));
                }

                playerVehicle.CoordinateX = serverVehicle.CoordinateX;
                playerVehicle.CoordinateY = serverVehicle.CoordinateY;
                playerVehicle.DrivingDirection = serverVehicle.DrivingDirection;

                if (serverVehicle.PlayerName == PlayerName)
                {
                    SetSpeed(serverVehicle.Speed.ToString());
                    SetDirection(serverVehicle.DrivingDirection.ToString());
                }
                //Memento
                //Save secret spot to memento
                if ((playerVehicle.CoordinateX % 50 == 0 && playerVehicle.CoordinateY % 50 == 0) && playerVehicle.PlayerName == PlayerName)
                {
                    originator.setState(new Coordinates(playerVehicle.CoordinateX, playerVehicle.CoordinateY));
                    careTaker.add(originator.saveStateToMemento());
                    SetPosLog("X = " + playerVehicle.CoordinateX + "\nY = " + playerVehicle.CoordinateY + "\nSpot saved " + saves++);
                }
                //
                GameDraw.DrawCars(game.Vehicles);
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
                //<Obstacle> obst = JsonConvert.DeserializeObject<Vehicle>(vehicle);
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