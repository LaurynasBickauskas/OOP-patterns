namespace CosmosInvaders.Library
{
    public class MoveUpCommand : ICommand
    {
        IMovable _ship { get; set; }

        public MoveUpCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.MoveVertical(true);
        }
    }
}
