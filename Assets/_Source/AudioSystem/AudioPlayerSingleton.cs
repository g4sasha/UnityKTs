using UnityEngine;

namespace AudioSystem
{
    public class AudioPlayerSingleton : MonoBehaviour
    {
        public static AudioPlayerSingleton Instance { get; private set; }

        [field: SerializeField]
        public AudioClip TestSound { get; private set; }

        [SerializeField]
        private AudioSource _audioSource;

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

        public void PlaySound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}
