using UnityEngine;

namespace Lab4
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] enemyPrefabs;
        public GameObject powerupPrefab;

        private float spawnRangeX = 6;
        private float spawnZMin = 6; // set min spawn Z
        private float spawnZMax = 16; // set max spawn Z

        public int enemyCount;
        public int waveCount = 1;


        public GameObject player;

        void Update()
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 0)
            {
                SpawnEnemyWave(waveCount);
            }

        }

        // Generate random spawn position for powerups and enemy balls
        Vector3 GenerateSpawnPosition()
        {
            float xPos = Random.Range(-spawnRangeX, spawnRangeX);
            float zPos = Random.Range(spawnZMin, spawnZMax);
            return new Vector3(xPos, 0.5f, zPos);
        }


        void SpawnEnemyWave(int enemiesToSpawn)
        {
            Vector3 powerupSpawnOffset = new Vector3(0, 0, -4);

            // If no powerups remain, spawn a powerup
            if (GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) // check that there are zero powerups
            {
                Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
            }

            

            // Spawn number of enemy balls based on wave number
            for (int i = 0; i < waveCount; i++)
            {
                int enemyIndex = Random.Range(0, enemyPrefabs.Length);
                GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
            }

            waveCount++;
            ResetPlayerPosition();

        }

        // Move player back to position in front of own goal
        void ResetPlayerPosition()
        {
            player.transform.position = new Vector3(0, 0.5f, -4);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}