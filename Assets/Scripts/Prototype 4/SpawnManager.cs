using UnityEngine;

namespace PrototypeFour
{
    public class SpawnManager : MonoBehaviour
    {
        private float spawnRange = 9f;
        public GameObject enemyPrefab;
        public GameObject powerUpPrefab;
        public int enemyCount;
        public int waveNumber = 1;

        private void Start()
        {
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(),
                powerUpPrefab.transform.rotation);
        }

        private void Update()
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
                SpawnEnemyWave(waveNumber);
            }
        }

        private void SpawnEnemyWave(int enemiesToSpawn)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }

        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);
            Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
            return randomPos;
        }
    }
}