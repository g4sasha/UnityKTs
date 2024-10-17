using AudioSystem;
using InputSystem;
using ResourceSystem;
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

        [SerializeField]
        private ResourcesView _resourcesView;

        [SerializeField]
        private ResourcesControlView _resourcesControlView;

        private void Awake()
        {
            // Singletons
            _audioPlayerSingleton.Construct();
            _sceneManagerSingleton.Construct();

            // Views
            _resourcesView.Construct();
            _resourcesControlView.Construct();

            // Systems
            _inputListener.Construct();
        }
    }
}
