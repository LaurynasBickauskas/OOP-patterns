using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using CosmosInvaders.Library;

namespace CosmosInvaders
{
    public class ChatHub : Hub
    {
        private GameFacade _gameFacade { get; set; } = new GameFacade();

        public void Connect(string playerName, string vehicleFamily, string vehicleType)
        {
            Vehicle playerVehicle = _gameFacade.Connected(playerName, vehicleFamily, vehicleType);

            Clients.Caller.Connected(
                JsonConvert.SerializeObject(_gameFacade.Vehicles)
                );

            Clients.All.Moved(
                JsonConvert.SerializeObject(playerVehicle)
                );
        }

        public void JoinTheGame(string playerName)
        {
            _gameFacade.PlayerJoinedTheGame(playerName);
            Clients.Caller.JoinedTheGame("OK");
        }

        public void Move(string playerName, char key)
        {
            Vehicle vehicle = _gameFacade.Move(playerName, key);
            Clients.All.Moved(
                JsonConvert.SerializeObject(vehicle)
                );
            string message = _gameFacade.Log(vehicle);
            if (message != "")
            {
                Clients.All.Logged(
                    JsonConvert.SerializeObject(message)
                    );
            }
        }

        public void Message(string playerName, string message)
        {
            Tuple<string, string> tempMessage = _gameFacade.PlayerSentMessage(playerName, message);
            Clients.All.Messaged(
                JsonConvert.SerializeObject(tempMessage)
                );
        }

        public void Disconnect(string playerName)
        {
            _gameFacade.Disconnect(playerName);
            Clients.All.Disconnected(playerName);
        }

        public void MementoReposition(string playerName, int x, int y)
        {
            Vehicle vehicle = _gameFacade.Vehicles.FirstOrDefault(xx => xx.PlayerName == playerName);
            vehicle.CoordinateX = x;
            vehicle.CoordinateY = y;
            Clients.All.Moved(
                JsonConvert.SerializeObject(vehicle)
                );
        }

        //public List<Vehicle> GetMovedVehicleInfo(string playerName)
        //{
        //    return await _gameFacade.CheckForMovements(playerName);
        //}

        public void GetObstacles()
        {
            List<Obstacle> obstacles = _gameFacade.GetObstacles();
            Clients.Caller.GotObstacles(
                JsonConvert.SerializeObject(obstacles)
                );
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        //public void GetPlayers()
        //{
        //    List<Player> players = Game.GetInstance().Players;
        //    Clients.All.broadcastMessage(players);
        //}

        //public void GetMap()
        //{
        //    Map map = Game.GetInstance().GetMap();
        //    Clients.Caller.mapMessage(map);
        //}
    }
}