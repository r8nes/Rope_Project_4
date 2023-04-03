using System.Collections.Generic;
using RopeMaster.Assets;
using RopeMaster.Logic;
using RopeMaster.Utility;
using UnityEngine;

namespace RopeMaster.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assets;

        private GameObject PlayerGameObject { get; set; }

        public GameFactory(IAssetsProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer(Vector2 initialPoint)
        {
            PlayerGameObject = AddGameObject(AssetsPath.PLAYER_PATH, initialPoint);

            return PlayerGameObject;
        }

        public GameObject CreateSpawnerDistributor()
        {
            var circle = AddGameObject(AssetsPath.CIRCLE_PATH);
            var spawner = CreateSpawners();

            circle.GetComponent<CircleObjectDistributor>().Construct(spawner);

            return circle;
        }

        private List<GameObject> CreateSpawners()
        {
            int iterations = 6;
            List<GameObject> spawners = new List<GameObject>(iterations);
            for (int i = 0; i < iterations; i++)
            {
                var spawner = AddGameObject(AssetsPath.SPAWNER_PATH);
                spawner.GetComponent<SpawnPoint>().Construct(PlayerGameObject.transform);
                spawners.Add(spawner);
            }

            return spawners;
        }

        #region Instantiate Methods

        private GameObject AddGameObject(string prefabPath, Vector2 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);

            return gameObject;
        }

        private GameObject AddGameObject(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);

            return gameObject;
        }

        #endregion
    }
}