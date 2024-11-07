using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneratorSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        private const float SEGMENT_LENGTH = 28.0f;

        [SerializeField]
        private int _levelLength;

        [SerializeField]
        private List<GameObject> _levelSegments;

        private void Awake()
        {
            GenerateLevel(_levelLength);
        }

        public void GenerateLevel(int length)
        {
            for (int i = 1; i < length; i++)
            {
                Instantiate(
                    _levelSegments[Random.Range(0, _levelSegments.Count)],
                    new Vector3(SEGMENT_LENGTH * i, 0, 0),
                    Quaternion.identity
                );
            }
        }
    }
}
