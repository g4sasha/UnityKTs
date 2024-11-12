using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneratorSystem
{
    public class LevelGenerator
    {
        private List<GameObject> _levelSegments;

        public LevelGenerator(List<GameObject> levelSegments) => _levelSegments = levelSegments;

        public void GenerateLevel(int length)
        {
            for (int i = 1; i < length; i++)
            {
                var randomSegment = _levelSegments[Random.Range(0, _levelSegments.Count)];
                GameObject.Instantiate(
                    randomSegment,
                    new Vector3(randomSegment.transform.GetChild(0).localScale.x * i, 0, 0),
                    Quaternion.identity
                );
            }
        }
    }
}
