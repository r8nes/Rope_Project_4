using System;
using UnityEngine;

namespace RopeMaster.Config
{
    [Serializable]
    [CreateAssetMenu(fileName = "Wave", menuName = "Config/Wave")]
    public class Wave : ScriptableObject
    {
        public float MinRandom = 0.5f;
        public float MaxRandom = 3f;
        public float TimeChangeWaves = 20f;

        public int EnemiesPerWave = 10;
        
        public GameObject[] Entities;
    }
}