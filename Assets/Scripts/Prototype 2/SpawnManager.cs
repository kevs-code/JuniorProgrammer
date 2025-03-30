using UnityEngine;

namespace PrototypeTwo
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] animalPrefabs;
        // public GameObject objectPool;
        // public int numberOfEachAnimal = 5;
        private float spawnRangeX = 10;
        private float spawnPosZ = 20;
        private float startDelay = 2;
        private int spawnInterval = 1;

        private void Start()
        {
            /*
            int animalIndex = 0;
            for (int i = 0; i < animalPrefabs.Length * numberOfEachAnimal; i++)
            {
                GameObject animal = Instantiate(animalPrefabs[animalIndex], objectPool.transform.position, animalPrefabs[animalIndex].transform.rotation);
                animal.SetActive(false);
                animal.transform.parent = objectPool.transform;
                // then move spawnPosition to OnEnable / if transform.parent = objectPool
                if (i % numberOfEachAnimal == 0 && i > 0)
                {
                    animalIndex++;       
                }
            }
            */

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