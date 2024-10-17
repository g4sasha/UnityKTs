using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem
{
    public class ResourcesControlView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _amountField;

        [SerializeField]
        private TMP_Dropdown _typeField;

        [SerializeField]
        private Button _addButton;

        [SerializeField]
        private Button _removeButton;

        private ResourceBank _bank;
        private int _currentAmount;
        private ResourceType _currentType;

        public void Construct()
        {
            _bank = ResourceBank.Instance;

            _addButton.onClick.AddListener(AddResource);
            _removeButton.onClick.AddListener(RemoveResource);
            _amountField.onEndEdit.AddListener(UpdateResourceAmout);
            _typeField.onValueChanged.AddListener(UpdateResourceType);
        }

        private void UpdateResourceType(int index)
        {
            _currentType = (ResourceType)index;
        }

        private void UpdateResourceAmout(string amount)
        {
            if (int.TryParse(amount, out int amountValue))
            {
                _currentAmount = Mathf.Max(0, amountValue);
                return;
            }

            _currentAmount = 0;
            _amountField.text = _currentAmount.ToString();
        }

        private void AddResource() => _bank.AddResource(_currentType, _currentAmount);

        private void RemoveResource() => _bank.AddResource(_currentType, -_currentAmount);
    }
}
