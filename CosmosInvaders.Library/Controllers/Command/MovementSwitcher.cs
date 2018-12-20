namespace Racing2D.Library
{
    public class MovementSwitcher
    {
        ICommand _turnLeft { get; set; }
        ICommand _turnRight { get; set; }
        ICommand _speedUp { get; set; }
        ICommand _slowDown { get; set; }

        public MovementSwitcher(ICommand turnLeft, ICommand turnRight, ICommand speedUp, ICommand slowDown)
        {
            _turnLeft = turnLeft;
            _turnRight = turnRight;
            _speedUp = speedUp;
            _slowDown = slowDown;
        }
        
        public void TurnLeft()
        {
            _turnLeft.Execute();
        }

        public void TurnRight()
        {
            _turnRight.Execute();
        }

        public void SpeedUp()
        {
            _speedUp.Execute();
        }

        public void SlowDown()
        {
            _slowDown.Execute();
        }


    }
}
