using AudioSystem;
using ScenreManagementSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField]
        private KeyCode _restartSceneKey;

        [SerializeField]
        private KeyCode _playTestSoundKey;

        private AudioPlayerSingleton _audioPlayer;
        private SceneManagerSingleton _sceneManager;

        public void Construct()
        {
            _audioPlayer = AudioPlayerSingleton.Instance;
            _sceneManager = SceneManagerSingleton.Instance;
        }

        private void Update()
        {
            HandleRestartScene();
            HandlePlayTestSound();
        }

        private void HandleRestartScene()
        {
            if (Input.GetKeyDown(_restartSceneKey))
            {
                _sceneManager.Restart();
            }
        }

        private void HandlePlayTestSound()
        {
            if (Input.GetKeyDown(_playTestSoundKey))
            {
                _audioPlayer.PlaySound(_audioPlayer.TestSound);
            }
        }
    }
}
