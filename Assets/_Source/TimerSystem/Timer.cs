using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TimerSystem
{
    public class Timer
    {
        public event Action OnTimerStarted;
        public event Action OnTimerCompleted;
        public event Action OnTimerResumed;
        public event Action OnTimerPaused;

        public TimerState State { get; private set; }
        public float RemainingTime { get; private set; }

        public Timer(float time)
        {
            RemainingTime = time;
            State = TimerState.Running;
            TimerLoop().Forget();
        }

        public void Resume()
        {
            if (State == TimerState.Paused)
            {
                State = TimerState.Running;
            }

            OnTimerResumed?.Invoke();
        }

        public void Pause()
        {
            if (State == TimerState.Running)
            {
                State = TimerState.Paused;
            }

            OnTimerPaused?.Invoke();
        }

        private async UniTaskVoid TimerLoop()
        {
            OnTimerStarted?.Invoke();

            while (RemainingTime > 0)
            {
                if (State == TimerState.Running)
                {
                    RemainingTime -= Time.deltaTime;
                }

                await UniTask.DelayFrame(1);
            }

            State = TimerState.Completed;
            OnTimerCompleted?.Invoke();
        }
    }
}
