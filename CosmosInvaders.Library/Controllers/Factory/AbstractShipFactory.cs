namespace CosmosInvaders.Library
{
    /// <summary>
    /// Abstract factory
    /// </summary>
	public abstract class AbstractShipFactory
    {
        public abstract Ship GetShip(string playerName, string family, string type);		
	}
	
}
