namespace CosmosInvaders.Library
{
    public class TurnRightCommand : ICommand
    {
        IMovable _ship { get; set; }

        public TurnRightCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.ChangeDirection(TurnTo.Right);
        }
    }
}
