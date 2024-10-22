namespace TimerSystem
{
    public class Timer
    {
        public float Time { get; private set; }
        public bool IsDone { get; private set; }

        public Timer(float time)
        {
            Time = time;
        }
    }
}
