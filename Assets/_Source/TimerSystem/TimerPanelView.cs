using System;
using System.Collections.Generic;
using UnityEngine;

namespace TimerSystem
{
    public class TimerPanelView : MonoBehaviour
    {
        [SerializeField]
        private List<TimerPanel> _timerPanels;

        private void Update()
        {
            foreach (var res in _timerPanels)
            {
                // Модуль для форматирования таймера в виде MM:SS:MS
                var timeSpan = TimeSpan.FromSeconds(res.Button.DecayTimer.RemainingTime);
                res.TimerField.text =
                    $"{res.Prefix} {timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}:{timeSpan.Milliseconds / 10:D2}";
            }
        }
    }
}
