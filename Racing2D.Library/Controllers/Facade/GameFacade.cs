using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing2D.Library
{
    public class GameFacade
    {
        /// <summary>
        /// Zaidimo instance kuriame saugomi visi zaidimo duomenys
        /// </summary>
        private Game _instance { get; set; }

        public List<Vehicle> Vehicles => _instance.Vehicles;

        public string message { get; set; } = "";


        public GameFacade()
        {
            _instance = Game.Instance;
        }

        /// <summary>
        /// Zaidejas prisijungia, taigi pagal jo varda sukuriama transporto priemone
        /// </summary>
        /// <param name="playerName">Zaidejo vardas</param>
        /// <param name="vehicleFamily">Zaidejo pasirinkta transporto priemones seima (pvz. Bike)</param>
        /// <param name="vehicleType">Zaidejo pasirinktas transporto priemones tipas pagal seima (pvz. Motorbike)</param>
        /// <returns></returns>
        public Vehicle Connected(string playerName, string vehicleFamily, string vehicleType)
        {
            _instance.AddVehicle(playerName, vehicleFamily, vehicleType);
            return GetVehicleByPlayerName(playerName);
        }

        public void Disconnect(string playerName)
        {
            Vehicle vehicteToDelete = GetVehicleByPlayerName(playerName);
            _instance.ObservableVehicles.Remove(vehicteToDelete);
            _instance.Vehicles.Remove(vehicteToDelete);
        }

        /// <summary>
        /// Zaidejas pereina is "loby" i zaidima, taigi jis prisubscribinamas prie observerio kuris pranes kitiems apie jo judesius
        /// </summary>
        /// <param name="playerName"></param>
        public void PlayerJoinedTheGame(string playerName)
        {
            Vehicle vehicle = GetVehicleByPlayerName(playerName);
            _instance.ObservableVehicles.Add(vehicle);
        }

        /// <summary>
        /// Masinos judejimas
        /// Kreipiasi client, kai jo masina nori judeti (judama pagal paspausta mygtuka)
        /// </summary>
        /// <param name="playerName">Zaidejo kurio masina judinama vardas</param>
        /// <param name="key">Paspaustas mygtukas</param>
        /// <returns>Transporto priemone su visa savo informacija</returns>
        public Vehicle Move(string playerName, char key)
        {
            Vehicle vehicle = GetVehicleByPlayerName(playerName);
            ICommand turnLeft = new TurnLeftCommand(vehicle);
            ICommand turnRight = new TurnRightCommand(vehicle);
            ICommand speedUp = new SpeedUpCommand(vehicle);
            ICommand slowDown = new SlowDownCommand(vehicle);

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

            return vehicle;
        }

        /// <summary>
        /// Statiniu kliuciu zemelapyje gavimas
        /// </summary>
        /// <returns>kliutys zemelapyje</returns>
        public List<Obstacle> GetObstacles()
        {
            List<Obstacle> mapObstacles = new List<Obstacle>();

            ObstacleCache.LoadCache();

            Tree tree = (Tree)ObstacleCache.GetObstacle("tree");
            tree.UpperLeftCoordinateX = 1;
            tree.UpperLeftCoordinateY = 1;
            mapObstacles.Add(tree);

            Rock rock = (Rock)ObstacleCache.GetObstacle("rock");
            rock.UpperLeftCoordinateX = 2;
            rock.UpperLeftCoordinateY = 2;
            mapObstacles.Add(rock);

            Tree tree2 = (Tree)ObstacleCache.GetObstacle("tree");
            tree2.UpperLeftCoordinateX = 3;
            tree2.UpperLeftCoordinateY = 3;
            mapObstacles.Add(tree2);

            Rock rock2 = (Rock)ObstacleCache.GetObstacle("rock");
            rock2.UpperLeftCoordinateX = 4;
            rock2.UpperLeftCoordinateY = 4;
            mapObstacles.Add(rock2);

            return mapObstacles;
        }

        public async Task<List<Vehicle>> CheckForMovements(string playerName)
        {
            Vehicle playerVehicle = GetVehicleByPlayerName(playerName);
            await Task.Run(() => playerVehicle.IsUpdated());
            playerVehicle.SomeoneChangedState = false;
            return _instance.Vehicles;
        }

        /// <summary>
        /// Gaunama transporto priemone pagal zaidejo varda
        /// </summary>
        /// <param name="playerName">Zaidejo vardas</param>
        /// <returns>Zaidejo transporto priemones objektas</returns>
        private Vehicle GetVehicleByPlayerName(string playerName)
        {
            return _instance.Vehicles.Select(x => x).Where(x => x.PlayerName == playerName).FirstOrDefault();
        }

        private static AbstractLogger GetChainOfLoggers()
        {
            AbstractLogger zeroSpeedLogger = new ZeroSpeedLogger(AbstractLogger.ZERO_SPEED);
            AbstractLogger speedLimitLogger = new SpeedLimitLogger(AbstractLogger.SPEED_LIMIT);
            AbstractLogger maxSpeedLogger = new MaxSpeedLogger(AbstractLogger.MAX_SPEED);

            maxSpeedLogger.SetNextLogger(speedLimitLogger);
            speedLimitLogger.SetNextLogger(zeroSpeedLogger);

            return maxSpeedLogger;
        }

        public string Log(Vehicle vehicle)
        {
            AbstractLogger loggerChain = GetChainOfLoggers();
            string message = "";
            if (vehicle.Speed == 1)
            {
                loggerChain.LogMessage(AbstractLogger.ZERO_SPEED, vehicle, this);
            }
            else if (vehicle.Speed == 25)
            {
                loggerChain.LogMessage(AbstractLogger.SPEED_LIMIT, vehicle, this);
            }
            else if (vehicle.Speed == vehicle.MaxSpeed - 1)
            {
                loggerChain.LogMessage(AbstractLogger.MAX_SPEED, vehicle, this);
            }
            message = this.message;
            return message;
        }

        public System.Tuple<string, string> PlayerSentMessage(string playerName, string message)
        {
            Vehicle vehicle = GetVehicleByPlayerName(playerName);
            return vehicle.SendMessage(message);
        }
    }
}
