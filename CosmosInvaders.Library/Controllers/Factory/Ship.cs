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
        public FlyingDirection CurrentDirection { get; set; } = FlyingDirection.Up;
        private FlyAlgorithm _currentFlyingAlorithm { get; set; } = new FlyMagic();

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
            Fly(_currentFlyingAlorithm, direction);
            CurrentDirection = direction;
        }

        private void Fly(FlyAlgorithm algorithm, FlyingDirection newDirection)
        {
            int X = CoordinateX;
            int Y = CoordinateY;
            int S = Speed;
            algorithm.Move(ref X,ref  Y,CurrentDirection, newDirection,ref S);
            CoordinateX = X;
            CoordinateY = Y;
            Speed = S;
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
            return CurrentDirection;
        }

        public void MoveHorizontal(MoveTo sideToMove)
        {
            if(sideToMove == MoveTo.Left)
            {
                Fly(FlyingDirection.Left);
            }
            else if (sideToMove == MoveTo.Right)
            {
                Fly(FlyingDirection.Right);
            }
        }

        public void MoveVertical(bool up)
        {
            if (up == true)
            {
                Fly(FlyingDirection.Up);
                CurrentDirection = FlyingDirection.Up;
            }
            else 
            {
                Fly(FlyingDirection.Down);
                CurrentDirection = FlyingDirection.Down;
            }
            
        }

        public Tuple<string, string> SendMessage(string message)
        {
            return ChatRoom.ShowMessage(this,message);
        }
    }
}
