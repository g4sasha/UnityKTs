using UnityEngine;

namespace AudioSystem
{
    public class AudioPlayerSingleton : MonoBehaviour
    {
        public static AudioPlayerSingleton Instance { get; private set; }

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void PlaySound()
        {
            Debug.Log("Playing sound");
        }
    }
}
