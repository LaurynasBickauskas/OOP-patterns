namespace CosmosInvaders.Library
{
    public class SpeedUpCommand : ICommand
    {
        IMovable _ship { get; set; }

        public SpeedUpCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.ChangeSpeed(true);
        }
    }
}
