using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using CosmosInvaders.Library;

namespace CosmosInvaders
{
    public class ConcreteHub : Hub
    {
        private GameFacade _gameFacade { get; set; } = new GameFacade();

        public void Connect(string playerName, string shipFamily, string shipType)
        {
            Ship playerShip = _gameFacade.Connected(playerName, shipFamily, shipType);

            Clients.Caller.Connected(
                JsonConvert.SerializeObject(_gameFacade.Ships)
                );

            Clients.All.Moved(
                JsonConvert.SerializeObject(playerShip)
                );
        }

        public void JoinTheGame(string playerName)
        {
            _gameFacade.PlayerJoinedTheGame(playerName);
            Clients.Caller.JoinedTheGame("OK");
        }

        public void Move(string playerName, char key)
        {
            Ship ship = _gameFacade.Move(playerName, key);
            Clients.All.Moved(JsonConvert.SerializeObject(ship));

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