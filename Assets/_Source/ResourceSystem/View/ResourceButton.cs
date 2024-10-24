using Core;
using ResourceSystem.Data;
using ResourceSystem.Services;
using TimerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem.View
{
    public class ResourceButton : MonoBehaviour
    {
        public Timer EnrichmentTimer { get; private set; }
        public Timer DecayTimer { get; private set; }

        [SerializeField]
        private ResourceType _resourceType;

        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Button _button;

        private ResourceViewService _resourcesView;
        private ResourceDataService _resourceData;

        private void Awake()
        {
            _resourcesView = ResourceViewService.Instance;
            _resourceData = ResourceDataService.Instance;

            if (_resourceData.TryGetDecayTime(_resourceType, out var decayTime))
            {
                DecayTimer = new Timer(decayTime);
            }
        }

        private void Start()
        {
            Activate();
        }

        private void OnEnable()
        {
            DecayTimer.OnTimerCompleted += Game.Instance.Finish;
            _button.onClick.AddListener(Activate);
        }

        private void OnDisable()
        {
            DecayTimer.OnTimerCompleted -= Game.Instance.Finish;

            if (EnrichmentTimer != null) // TODO: Исправить всю логику таймера, завязанную на Null
            {
                EnrichmentTimer.OnTimerStarted -= Activate;
                EnrichmentTimer.OnTimerCompleted -= Deactivate;
            }
        }

        public void Activate()
        {
            _button.interactable = false;
            _resourcesView.SetEnabledIcon(_icon, _resourceType);

            if (_resourceData.TryGetEnrichmentTime(_resourceType, out var enrichmentTime))
            {
                EnrichmentTimer = new Timer(enrichmentTime);
                EnrichmentTimer.OnTimerStarted += Activate;
                EnrichmentTimer.OnTimerCompleted += Deactivate;
            }

            DecayTimer.Pause();
        }

        public void Deactivate()
        {
            _button.interactable = true;
            _resourcesView.SetDisabledIcon(_icon, _resourceType);
            DecayTimer.Resume();
        }
    }
}
