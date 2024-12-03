using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        private PhysicsCalculator _physicsCalculator;

        private void Start()
        {
            _physicsCalculator = new PhysicsCalculator();
        }
    }
}
