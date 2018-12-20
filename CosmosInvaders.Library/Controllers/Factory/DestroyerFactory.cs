using System;

namespace CosmosInvaders.Library
{
    public class DestroyerFactory
    {
        public IDestroyer GetDestroyer(string type)
        {
            switch (type)
            {
                case "Medium ship":
                    return new MediumShip().GetDestroyer();
                case "Big ship":
                    return new BigShip().GetDestroyer();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

    }

}