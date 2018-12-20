namespace CosmosInvaders.Library
{
    public class SlowDownCommand : ICommand
    {
        IMovable _ship { get; set; }

        public SlowDownCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.ChangeSpeed(false);
        }
    }
}
