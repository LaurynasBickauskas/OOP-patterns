namespace Racing2D.Library
{
    public interface IMovable
    {
        void ChangeDirection(TurnTo directionToTurn);
        void ChangeSpeed(bool forward);
    }
}
