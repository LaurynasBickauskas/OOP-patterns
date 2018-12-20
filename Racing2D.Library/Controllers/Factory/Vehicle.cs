using System;
using System.Threading;
using System.Threading.Tasks;

namespace Racing2D.Library
{
    public class Vehicle : IObserver, IMovable
    {
        public string PlayerName { get; set; }
        public int MaxSpeed { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public int Speed { get; set; }
        public DrivingDirection DrivingDirection { get; set; } = DrivingDirection.Up;
        private DriveAlgorithm _currentDrivingAlorithm { get; set; } = new DriveRegular();

        public bool SomeoneChangedState { get; set; }

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public Vehicle()
        {

        }

        public void SetCoordinates(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }

        public void Drive(DrivingDirection direction)
        {
            DrivingDirection = direction; //TODO: pakeist kad susiestu su vairavimu krc nzn
            Drive(_currentDrivingAlorithm);
        }

        private void Drive(DriveAlgorithm algoritm)
        {
            (CoordinateX, CoordinateY) = algoritm.Move(CoordinateX, CoordinateY, DrivingDirection, Speed);
        }

        public void Update()
        {
            SomeoneChangedState = true;
        }

        public void IsUpdated()
        {
            while (!SomeoneChangedState)
            {
                Thread.Sleep(100);
            }
        }

        public DrivingDirection Display()
        {
            return DrivingDirection;
        }

        public void ChangeDirection(TurnTo directionToTurn)
        {
            int directionResult = (int)DrivingDirection + (int)directionToTurn;
            if (directionResult < 0)
            {
                DrivingDirection = (DrivingDirection)3;
                return;
            }
            if (directionResult > 3)
            {
                DrivingDirection = (DrivingDirection)0;
                return;
            }
            DrivingDirection = (DrivingDirection)directionResult;
        }

        public void ChangeSpeed(bool foward)
        {
            if (foward)
                Speed = (Speed + 1) <= MaxSpeed ? Speed + 1 : Speed;
            else
            {
                if (Speed > 0)
                    Speed -= Math.Abs(Speed - 1) <= MaxSpeed ? Speed - 1 : Speed;
                else
                    Speed = 0;

            }
            Drive(_currentDrivingAlorithm);
        }

        public Tuple<string, string> SendMessage(string message)
        {
            return ChatRoom.ShowMessage(this,message);
        }
    }
}
