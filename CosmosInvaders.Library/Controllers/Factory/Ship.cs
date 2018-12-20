using System;
using System.Threading;
using System.Threading.Tasks;

namespace CosmosInvaders.Library
{
    public class Ship : IObserver, IMovable
    {
        public string PlayerName { get; set; }
        public int MaxSpeed { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHealthPoints { get; set; }
        public int Speed { get; set; }
        public FlyingDirection FlyingDirection { get; set; } = FlyingDirection.Up;
        private FlyAlgorithm _currentFlyingAlorithm { get; set; } = new FlyRegular();

        public bool SomeoneChangedState { get; set; }

        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }

        public Ship()
        {

        }

        public void SetCoordinates(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }

        public void Fly(FlyingDirection direction)
        {
            FlyingDirection = direction; //TODO: pakeist kad susiestu su skraidymu krc nzn
            Fly(_currentFlyingAlorithm);
        }

        private void Fly(FlyAlgorithm algoritm)
        {
            (CoordinateX, CoordinateY) = algoritm.Move(CoordinateX, CoordinateY, FlyingDirection, Speed);
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

        public FlyingDirection Display()
        {
            return FlyingDirection;
        }

        public void ChangeDirection(TurnTo directionToTurn)
        {
            int directionResult = (int)FlyingDirection + (int)directionToTurn;
            if (directionResult < 0)
            {
                FlyingDirection = (FlyingDirection)3;
                return;
            }
            if (directionResult > 3)
            {
                FlyingDirection = (FlyingDirection)0;
                return;
            }
            FlyingDirection = (FlyingDirection)directionResult;
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
            Fly(_currentFlyingAlorithm);
        }

        public Tuple<string, string> SendMessage(string message)
        {
            return ChatRoom.ShowMessage(this,message);
        }
    }
}
