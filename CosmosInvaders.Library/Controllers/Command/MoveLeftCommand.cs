namespace CosmosInvaders.Library
{
    public class MoveLeftCommand : ICommand
    {
        IMovable _ship { get; set; }

        public MoveLeftCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.MoveHorizontal(MoveTo.Left);
        }
    }
}
