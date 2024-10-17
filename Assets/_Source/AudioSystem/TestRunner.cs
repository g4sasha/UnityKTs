using UnityEngine;

namespace AudioSystem
{
    public class TestRunner : MonoBehaviour
    {
        private void Start()
        {
            AudioPlayerSingleton.Instance.PlaySound();
        }
    }
}
