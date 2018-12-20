namespace CosmosInvaders.Library
{
    public class MoveDownCommand : ICommand
    {
        IMovable _ship { get; set; }

        public MoveDownCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.MoveVertical(false);
        }
    }
}
