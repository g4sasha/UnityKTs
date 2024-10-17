using TMPro;
using UnityEngine;

namespace ResourceSystem
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _goldField;

        [SerializeField]
        private TMP_Text _woodField;

        [SerializeField]
        private TMP_Text _stoneField;

        private ResourceBank _bank;

        public void Construct()
        {
            _bank = ResourceBank.Instance;
            _bank.OnResourcesChanged += DrawResource;
        }

        private void OnDestroy()
        {
            _bank.OnResourcesChanged -= DrawResource;
        }

        public void DrawResource(ResourceType type, int amount)
        {
            switch (type)
            {
                case ResourceType.Gold:
                    _goldField.text = $"Gold: {amount}";
                    break;
                case ResourceType.Wood:
                    _woodField.text = $"Wood: {amount}";
                    break;
                case ResourceType.Stone:
                    _stoneField.text = $"Stone: {amount}";
                    break;
            }
        }
    }
}
