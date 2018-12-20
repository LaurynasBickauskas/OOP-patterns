namespace CosmosInvaders.Library
{
    public interface IMovable
    {
        void MoveHorizontal(MoveTo directionToTurn);
        void MoveVertical(bool forward);
    }
}
