using Cysharp.Threading.Tasks;
using GameOverSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class Game
    {
        public static Game Instance
        {
            get
            {
                _instance ??= new Game();
                return _instance;
            }
        }

        private static Game _instance;

        public void Start()
        {
            Debug.Log("Start game");
        }

        public void Finish()
        {
            Debug.Log("Finish game");
            // Time.timeScale = 0f;
            GameOverPanel.Instance.Show();
            RestartSceneAfterDelay(2000).Forget();
        }

        private async UniTaskVoid RestartSceneAfterDelay(int delayMs)
        {
            await UniTask.Delay(delayMs);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
