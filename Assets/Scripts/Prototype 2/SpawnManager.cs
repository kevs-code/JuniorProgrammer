using UnityEngine;

namespace PrototypeTwo
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] animalPrefabs;
        private float spawnRangeX = 10;
        private float spawnPosZ = 20;
        private float startDelay = 2;
        private int spawnInterval = 1;

        private void Start()
        {
            InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        }

        private void Update()
        {

        }

        private void SpawnRandomAnimal()
        {
            spawnInterval = Random.Range(3, 5); // check whether int or float inclusive
            int animalIndex = Random.Range(0, animalPrefabs.Length);

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
        }
    }
}