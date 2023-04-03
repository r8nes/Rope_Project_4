using RopeMaster.Service;
using UnityEngine;

namespace RopeMaster.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(Vector2 initialPoint);
        GameObject CreateSpawnerDistributor();
    }
}