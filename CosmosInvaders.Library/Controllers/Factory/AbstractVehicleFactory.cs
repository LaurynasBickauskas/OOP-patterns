namespace CosmosInvaders.Library
{
    /// <summary>
    /// Abstract factory
    /// </summary>
	public abstract class AbstractVehicleFactory
	{
        public abstract Vehicle GetVehicle(string playerName, string family, string type);		
	}
	
}
