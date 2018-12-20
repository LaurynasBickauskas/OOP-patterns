namespace CosmosInvaders.Library
{
    public class SlowDownCommand : ICommand
    {
        IMovable _vehicle { get; set; }

        public SlowDownCommand(IMovable vehicle)
        {
            _vehicle = vehicle;
        }

        public void Execute()
        {
            _vehicle.ChangeSpeed(false);
        }
    }
}
