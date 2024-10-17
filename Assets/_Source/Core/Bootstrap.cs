using AudioSystem;
using InputSystem;
using ResourceSystem;
using ScenreManagementSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [Header("Systems")]
        [SerializeField]
        private InputListener _inputListener;

        [Header("Views")]
        [SerializeField]
        private ResourcesView _resourcesView;

        [SerializeField]
        private ResourcesControlView _resourcesControlView;

        private void Awake()
        {
            // Singletons
            var audioPlayerSingleton = FindObjectOfType<AudioPlayerSingleton>();
            var sceneManagerSingleton = FindObjectOfType<SceneManagerSingleton>();

            audioPlayerSingleton.Construct();
            sceneManagerSingleton.Construct();

            // Views
            _resourcesView.Construct();
            _resourcesControlView.Construct();

            // Systems
            _inputListener.Construct();
        }
    }
}
