namespace CosmosInvaders.Library
{
    public class BikeFactory
    {
        public IBike GetBike(string type)
        {
            switch (type)
            {
                case "Bicycle":
                    return new Bicycle().GetBike();
                case "Motorbike":
                    return new Motorbike().GetBike();
                case "Quad":
                    return new Quad().GetBike();
                default:
                    return null;
            }
        }

    }
}