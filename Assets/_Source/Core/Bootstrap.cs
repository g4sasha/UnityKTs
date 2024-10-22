using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game();
            _game.Start();
        }
    }
}
