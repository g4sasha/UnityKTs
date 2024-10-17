using AudioSystem;
using InputSystem;
using ScenreManagementSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private InputListener _inputListener;

        [SerializeField]
        private AudioPlayerSingleton _audioPlayerSingleton;

        [SerializeField]
        private SceneManagerSingleton _sceneManagerSingleton;

        private void Awake()
        {
            _audioPlayerSingleton.Construct();
            _sceneManagerSingleton.Construct();
            _inputListener.Construct();
        }
    }
}
