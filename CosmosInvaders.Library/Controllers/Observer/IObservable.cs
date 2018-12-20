namespace CosmosInvaders.Library
{
    public interface IObservable
    {
        void Add(IObserver o);

        void Remove(IObserver o);

        void Notify();

        void NotifyAll();
    }
}
