using System.Collections.Generic;
using LevelGeneratorSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _levelSegments;

        private LevelGenerator _generator;

        private void Awake()
        {
            _generator = new LevelGenerator(_levelSegments);
        }

        private void Start()
        {
            _generator.GenerateLevel(10);
        }
    }
}
