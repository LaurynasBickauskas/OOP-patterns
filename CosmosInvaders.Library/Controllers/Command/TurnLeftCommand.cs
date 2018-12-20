namespace CosmosInvaders.Library
{
    public class TurnLeftCommand : ICommand
    {
        IMovable _ship { get; set; }

        public TurnLeftCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.ChangeDirection(TurnTo.Left);
        }
    }
}
