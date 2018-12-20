namespace CosmosInvaders.Library
{
    public class MovementSwitcher
    {
        ICommand _moveLeft { get; set; }
        ICommand _moveRight { get; set; }
        ICommand _moveUp { get; set; }
        ICommand _moveDown { get; set; }

        public MovementSwitcher(ICommand moveLeft, ICommand moveRight, ICommand moveUp, ICommand moveDown)
        {
            _moveLeft = moveLeft;
            _moveRight = moveRight;
            _moveUp = moveUp;
            _moveDown = moveDown;
        }
        
        public void MoveLeft()
        {
            _moveLeft.Execute();
        }

        public void MoveRight()
        {
            _moveRight.Execute();
        }

        public void MoveUp()
        {
            _moveUp.Execute();
        }

        public void MoveDown()
        {
            _moveDown.Execute();
        }


    }
}
