using System;
using System.Collections;
using System.Collections.Generic;
using RopeMaster.Config;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RopeMaster.Logic
{
    public class SpawnPoint : MonoBehaviour
    {
        public string Id { get; set; }

        public List<Wave> Config;

        public float SpawnInterval = 1.5f;

   //     public event Action<int> OnSpawnEnemiesAppeared;
   //     public event Action<int> OnWaveChanged;
        
        private Coroutine _spawnCoroutine;

        private List<SpawnerTransform> _points = new List<SpawnerTransform>();

        private Transform _target;

        public int CurrentWave { get; private set; } = 0;

        public void Construct(Transform target)
        {
            _target = target;
        }

        private void Start() => _spawnCoroutine = StartCoroutine(SpawnWave(CurrentWave));

        public void AddSpawnMarker(SpawnerTransform marker) => _points.Add(marker);

        private IEnumerator SpawnWave(int waveIndex)
        {
            if (waveIndex >= Config.Count) yield break;
            
            for (int i = 0; i < Config[waveIndex].EnemiesPerWave; i++)
            {
                SpawnRandom(waveIndex);
          //      OnSpawnEnemiesAppeared?.Invoke(i);

                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(SpawnInterval);

            CurrentWave++;
          //  OnWaveChanged?.Invoke(CurrentWave);

            if (CurrentWave < Config.Count)
            {
                _spawnCoroutine = StartCoroutine(SpawnWave(CurrentWave));
            }
        }

        private void SpawnRandom(int i)
        {
            int spawnMonster = Random.Range(0, Config[i].Entities.Length);
            var enemy = Instantiate(Config[i].Entities[spawnMonster], transform.position, Quaternion.identity);

            enemy.GetComponent<EntityMovement>().Construct(_target.gameObject);
            enemy.GetComponent<EntityDamage>().Construct(_target.gameObject);
        }
    }
}