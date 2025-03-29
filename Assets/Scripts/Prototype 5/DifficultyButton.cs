using UnityEngine;
using UnityEngine.UI;

namespace PrototypeFive
{
    public class DifficultyButton : MonoBehaviour
    {
        private Button button;
        private GameManager gameManager;
        public int difficulty;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(SetDifficuty);
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void SetDifficuty()
        {
            Debug.Log(gameObject.name + " was clicked");
            gameManager.StartGame(difficulty);
        }
    }
}