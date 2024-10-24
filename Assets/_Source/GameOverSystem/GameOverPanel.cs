using UnityEngine;

namespace GameOverSystem
{
    public class GameOverPanel : MonoBehaviour
    {
        public static GameOverPanel Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Hide();
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}
