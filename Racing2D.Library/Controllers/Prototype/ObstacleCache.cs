using System.Collections.Generic;

namespace Racing2D.Library
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
            Tree tree = new Tree();
            _obstacleMap.Add("tree", tree);
            Rock rock = new Rock();
            _obstacleMap.Add("rock", rock);
        }


    }
}
