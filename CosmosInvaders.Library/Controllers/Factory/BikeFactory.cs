namespace CosmosInvaders.Library
{
    public class RangerFactory
    {
        public IRanger GetRanger(string type)
        {
            switch (type)
            {
                case "Small ship":
                    return new SmallShip().GetRanger();
                default:
                    return null;
            }
        }

    }
}