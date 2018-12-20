using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Racing2D.Library
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

        public List<Vehicle> Vehicles { get; set; }

        private AbstractVehicleFactory _abstractVehicleFactory { get; set; }

        public IObservable ObservableVehicles { get; set; }

        private Game()
        {
            Vehicles = new List<Vehicle>();
            _abstractVehicleFactory = new VehicleFactory();
            ObservableVehicles = new ObservableVehicles(this);
        }

        public void AddVehicle(string playerName, string family, string type)
        {
            Vehicles.Add(_abstractVehicleFactory.GetVehicle(playerName, family, type));
        }

        public void UpdateVehicle()
        {
            // TODO: update instance ( pagal dabar tai kad atnaujintu visus vehicle)
        }
        
    }
}
