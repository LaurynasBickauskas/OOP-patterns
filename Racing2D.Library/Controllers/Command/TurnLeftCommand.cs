namespace Racing2D.Library
{
    public class TurnLeftCommand : ICommand
    {
        IMovable _vehicle { get; set; }

        public TurnLeftCommand(IMovable vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.ChangeDirection(TurnTo.Left);
        }
    }
}
