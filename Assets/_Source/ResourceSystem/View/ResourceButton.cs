using ResourceSystem.Data;
using ResourceSystem.Services;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem.View
{
    public class ResourceButton : MonoBehaviour
    {
        [SerializeField]
        private ResourceType _resourceType;

        [SerializeField]
        private Image _icon;

        private void Awake()
        {
            ResourceViewService.Instance.SetEnabledIcon(_icon, _resourceType);
        }
    }
}
