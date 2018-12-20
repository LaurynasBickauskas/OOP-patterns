using System.Collections.Generic;

namespace CosmosInvaders.Library
{
    public class ObstacleCache
    {
        private static Dictionary<string, Obstacle> _obstacleMap { get; set; } = new Dictionary<string, Obstacle>();

        public static Obstacle GetObstacle(string obstacleId)
        {
            Obstacle cachedObstacle = _obstacleMap[obstacleId];
            return cachedObstacle.Clone();
        }

        public static void LoadCache()
        {
            Debris debris = new Debris();
            _obstacleMap.Add("debris", debris);
            Rock rock = new Rock();
            _obstacleMap.Add("rock", rock);
        }


    }
}
