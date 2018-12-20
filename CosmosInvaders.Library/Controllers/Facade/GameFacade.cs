﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosInvaders.Library
{
    public class GameFacade
    {
        /// <summary>
        /// Zaidimo instance kuriame saugomi visi zaidimo duomenys
        /// </summary>
        private Game _instance { get; set; }

        public List<Ship> Ships => _instance.Ships;

        public string message { get; set; } = "";


        public GameFacade()
        {
            _instance = Game.Instance;
        }

        /// <summary>
        /// Zaidejas prisijungia, taigi pagal jo varda sukuriama transporto priemone
        /// </summary>
        /// <param name="playerName">Zaidejo vardas</param>
        /// <param name="shipFamily">Zaidejo pasirinkta transporto priemones seima (pvz. Bike)</param>
        /// <param name="shipType">Zaidejo pasirinktas transporto priemones tipas pagal seima (pvz. Motorbike)</param>
        /// <returns></returns>
        public Ship Connected(string playerName, string shipFamily, string shipType)
        {
            _instance.AddShip(playerName, shipFamily, shipType);
            return GetShipByPlayerName(playerName);
        }

        public void Disconnect(string playerName)
        {
            Ship vehicteToDelete = GetShipByPlayerName(playerName);
            _instance.ObservableShips.Remove(vehicteToDelete);
            _instance.Ships.Remove(vehicteToDelete);
        }

        /// <summary>
        /// Zaidejas pereina is "loby" i zaidima, taigi jis prisubscribinamas prie observerio kuris pranes kitiems apie jo judesius
        /// </summary>
        /// <param name="playerName"></param>
        public void PlayerJoinedTheGame(string playerName)
        {
            Ship ship = GetShipByPlayerName(playerName);
            _instance.ObservableShips.Add(ship);
        }

        /// <summary>
        /// Masinos judejimas
        /// Kreipiasi client, kai jo masina nori judeti (judama pagal paspausta mygtuka)
        /// </summary>
        /// <param name="playerName">Zaidejo kurio masina judinama vardas</param>
        /// <param name="key">Paspaustas mygtukas</param>
        /// <returns>Transporto priemone su visa savo informacija</returns>
        public Ship Move(string playerName, char key)
        {
            Ship ship = GetShipByPlayerName(playerName);
            ICommand turnLeft = new TurnLeftCommand(ship);
            ICommand turnRight = new TurnRightCommand(ship);
            ICommand speedUp = new SpeedUpCommand(ship);
            ICommand slowDown = new SlowDownCommand(ship);

            MovementSwitcher movementSwitcher = new MovementSwitcher(turnLeft, turnRight, speedUp, slowDown);
            switch (key.ToString().ToLower())
            {
                case "w":
                    movementSwitcher.SpeedUp();
                    break;
                case "s":
                    movementSwitcher.SlowDown();
                    break;
                case "a":
                    movementSwitcher.TurnLeft();
                    break;
                case "d":
                    movementSwitcher.TurnRight();
                    break;
            }

            return ship;
        }

        /// <summary>
        /// Statiniu kliuciu zemelapyje gavimas
        /// </summary>
        /// <returns>kliutys zemelapyje</returns>
        public List<Obstacle> GetObstacles()
        {
            List<Obstacle> mapObstacles = new List<Obstacle>();

            ObstacleCache.LoadCache();

            Debris debris = (Debris)ObstacleCache.GetObstacle("debris");
            debris.UpperLeftCoordinateX = 1;
            debris.UpperLeftCoordinateY = 1;
            mapObstacles.Add(debris);

            Rock rock = (Rock)ObstacleCache.GetObstacle("rock");
            rock.UpperLeftCoordinateX = 2;
            rock.UpperLeftCoordinateY = 2;
            mapObstacles.Add(rock);

            Debris debris2 = (Debris)ObstacleCache.GetObstacle("debris");
            debris2.UpperLeftCoordinateX = 3;
            debris2.UpperLeftCoordinateY = 3;
            mapObstacles.Add(debris2);

            Rock rock2 = (Rock)ObstacleCache.GetObstacle("rock");
            rock2.UpperLeftCoordinateX = 4;
            rock2.UpperLeftCoordinateY = 4;
            mapObstacles.Add(rock2);

            return mapObstacles;
        }

        public async Task<List<Ship>> CheckForMovements(string playerName)
        {
            Ship playerShip = GetShipByPlayerName(playerName);
            await Task.Run(() => playerShip.IsUpdated());
            playerShip.SomeoneChangedState = false;
            return _instance.Ships;
        }

        /// <summary>
        /// Gaunama transporto priemone pagal zaidejo varda
        /// </summary>
        /// <param name="playerName">Zaidejo vardas</param>
        /// <returns>Zaidejo transporto priemones objektas</returns>
        private Ship GetShipByPlayerName(string playerName)
        {
            return _instance.Ships.Select(x => x).Where(x => x.PlayerName == playerName).FirstOrDefault();
        }


        public System.Tuple<string, string> PlayerSentMessage(string playerName, string message)
        {
            Ship ship = GetShipByPlayerName(playerName);
            return ship.SendMessage(message);
        }
    }
}
