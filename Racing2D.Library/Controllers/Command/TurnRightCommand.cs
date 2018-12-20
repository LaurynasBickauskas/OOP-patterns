namespace Racing2D.Library
{
    public class TurnRightCommand : ICommand
    {
        IMovable _vehicle { get; set; }

        public TurnRightCommand(IMovable vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.ChangeDirection(TurnTo.Right);
        }
    }
}
