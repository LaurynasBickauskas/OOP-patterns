using System.Collections.Generic;
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
        /// Zaidejas prisijungia, taigi pagal jo varda sukuriamas laivas
        /// </summary>
        /// <param name="playerName">Zaidejo vardas</param>
        /// <param name="shipFamily">Zaidejo pasirinkta laivass seima (pvz. Destroyer)</param>
        /// <param name="shipType">Zaidejo pasirinktas laivass tipas pagal seima (pvz. Big ship)</param>
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
        /// Zaidejas pereina is "lobby" i zaidima, taigi jis prisubscribinamas prie observerio kuris pranes kitiems apie jo judesius
        /// </summary>
        /// <param name="playerName"></param>
        public void PlayerJoinedTheGame(string playerName)
        {
            Ship ship = GetShipByPlayerName(playerName);
            _instance.ObservableShips.Add(ship);
        }

        /// <summary>
        /// Masinos judejimas
        /// Kreipiasi client, kai jo laivas nori judeti (judama pagal paspausta mygtuka)
        /// </summary>
        /// <param name="playerName">Zaidejo kurio laivas judinama vardas</param>
        /// <param name="key">Paspaustas mygtukas</param>
        /// <returns>Laivas su visa savo informacija</returns>
        public Ship Move(string playerName, char key)
        {
            Ship ship = GetShipByPlayerName(playerName);
            ICommand moveLeft = new MoveLeftCommand(ship);
            ICommand moveRight = new MoveRightCommand(ship);
            ICommand moveUp = new MoveUpCommand(ship);
            ICommand moveDown = new MoveDownCommand(ship);

            MovementSwitcher movementSwitcher = new MovementSwitcher(moveLeft, moveRight, moveUp, moveDown);
            switch (key.ToString().ToLower())
            {
                case "w":
                    movementSwitcher.MoveUp();
                    break;
                case "s":
                    movementSwitcher.MoveDown();
                    break;
                case "a":
                    movementSwitcher.MoveLeft();
                    break;
                case "d":
                    movementSwitcher.MoveRight();
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
        /// Gaunama laivas pagal zaidejo varda
        /// </summary>
        /// <param name="playerName">Zaidejo vardas</param>
        /// <returns>Zaidejo laivo objektas</returns>
        private Ship GetShipByPlayerName(string playerName)
        {
            return _instance.Ships.Select(x => x).FirstOrDefault(x => x.PlayerName == playerName);
        }


        public System.Tuple<string, string> PlayerSentMessage(string playerName, string message)
        {
            Ship ship = GetShipByPlayerName(playerName);
            return ship.SendMessage(message);
        }
    }
}
