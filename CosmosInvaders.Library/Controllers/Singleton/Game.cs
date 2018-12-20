using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosInvaders.Library
{
    public class Game
    {
        private static Game _instance = null;

        public static Game Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Game();

                return _instance;
            }
        }

        public List<Ship> Ships { get; set; }

        private AbstractShipFactory _abstractShipFactory { get; set; }

        public IObservable ObservableShips { get; set; }

        private Game()
        {
            Ships = new List<Ship>();
            _abstractShipFactory = new ShipFactory();
            ObservableShips = new ObservableShips(this);
        }

        public void AddShip(string playerName, string family, string type)
        {
            Ships.Add(_abstractShipFactory.GetShip(playerName, family, type));
        }

        public void UpdateShip()
        {
            // TODO: update instance ( pagal dabar tai kad atnaujintu visus ship)
        }
        
    }
}
