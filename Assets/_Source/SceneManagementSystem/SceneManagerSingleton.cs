using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScenreManagementSystem
{
    public class SceneManagerSingleton : MonoBehaviour
    {
        public static SceneManagerSingleton Instance { get; private set; }

        public void Construct()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void Restart()
        {
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
