namespace Racing2D.Library
{
    public class SpeedUpCommand : ICommand
    {
        IMovable _vehicle { get; set; }

        public SpeedUpCommand(IMovable vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.ChangeSpeed(true);
        }
    }
}
