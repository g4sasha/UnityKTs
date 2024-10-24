using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private void Awake()
        {
            Game.Instance.Start();
        }
    }
}
