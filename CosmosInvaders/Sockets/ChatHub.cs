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


        public void GetObstacles()
        {
            List<Obstacle> obstacles = _gameFacade.GetObstacles();
            Clients.Caller.GotObstacles(
                JsonConvert.SerializeObject(obstacles)
                );
        }

        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }


    }
}