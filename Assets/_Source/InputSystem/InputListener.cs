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

        public void Construct()
        {
            _audioPlayer = AudioPlayerSingleton.Instance;
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
                SceneManagerSingleton.Instance.Restart();
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
