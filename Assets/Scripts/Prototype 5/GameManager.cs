using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace PrototypeFive
{
    public class GameManager : MonoBehaviour
    {
        private int score;
        public float spawnRate = 1f;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI gameOverText;
        public Button restartButton;
        public GameObject titleScreen;
        public List<GameObject> targets;
        public bool isGameActive;

        private IEnumerator SpawnTarget()
        {
            while (isGameActive)
            {
                yield return new WaitForSeconds(spawnRate);
                int index = Random.Range(0, targets.Count);
                Instantiate(targets[index]);
            }
        }

        public void StartGame(int difficulty)
        {
            spawnRate /= difficulty;
            UpdateScore(0);
            isGameActive = true;
            StartCoroutine(SpawnTarget());
            titleScreen.gameObject.SetActive(false);
        }

        public void UpdateScore(int scoreToAdd)
        {
            score += scoreToAdd;
            // scoreText.text = "Score: " + score;
            scoreText.text = $"Score: {score}";
        }

        public void GameOver()
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}