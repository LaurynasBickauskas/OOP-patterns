namespace CosmosInvaders.Library
{
    public class MoveRightCommand : ICommand
    {
        IMovable _ship { get; set; }

        public MoveRightCommand(IMovable ship)
        {
            _ship = ship;
        }

        public void Execute()
        {
            _ship.MoveHorizontal(MoveTo.Right);
        }
    }
}
