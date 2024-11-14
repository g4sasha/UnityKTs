using System.Collections.Generic;
using UnityEngine;

namespace LevelGeneratorSystem
{
    public class LevelGenerator
    {
        private List<GameObject> _levelSegments;
        private GameObject _finishSegment;

        public LevelGenerator(List<GameObject> levelSegments, GameObject finishSegment)
        {
            _levelSegments = levelSegments;
            _finishSegment = finishSegment;
        }

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

            GameObject.Instantiate(
                _finishSegment,
                new Vector3(_finishSegment.transform.GetChild(0).localScale.x * length, 0, 0),
                Quaternion.identity
            );
        }
    }
}
