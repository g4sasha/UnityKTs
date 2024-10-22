using Core;
using ResourceSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem.Services
{
    public class ResourceViewService
    {
        public static ResourceViewService Instance
        {
            get
            {
                _instance ??= new ResourceViewService();
                return _instance;
            }
        }

        private static ResourceViewService _instance;

        private ResourcesViewDataSO ViewData
        {
            get
            {
                if (_viewData == null)
                {
                    _viewData =
                        Resources.Load(PathData.RESOURCE_VIEW_DATA_PATH) as ResourcesViewDataSO;
                }

                return _viewData;
            }
        }

        private ResourcesViewDataSO _viewData;

        public void SetEnabledIcon(Image icon, ResourceType type)
        {
            if (ViewData.TryGetEnabledIcon(type, out var newIcon))
            {
                icon.sprite = newIcon;
            }
        }

        public void SetDisabledIcon(Image icon, ResourceType type)
        {
            if (ViewData.TryGetDisabledIcon(type, out var newIcon))
            {
                icon.sprite = newIcon;
            }
        }
    }
}
