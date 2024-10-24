using ResourceSystem.View;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
    [System.Serializable]
    public class TimerPanel
    {
        [field: SerializeField]
        public string Prefix { get; private set; }

        [field: SerializeField]
        public TMP_Text TimerField { get; private set; }

        [field: SerializeField]
        public ResourceButton Button { get; private set; }
    }
}
