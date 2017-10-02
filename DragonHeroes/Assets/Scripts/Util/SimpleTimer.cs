
namespace Util
{
    public class SimpleTimer
    {
        public static SimpleTimer Create()
        { return new SimpleTimer(); }

        private float LastestTime = 0.0f;
        private bool IsPlaying = false;

        private SimpleTimer()
        {

        }
        public void Start()
        {
            IsPlaying = true;
        }
        public void Update()
        {
            if(IsPlaying)
            {
                LastestTime += UnityEngine.Time.deltaTime;
            }
        }
        public void Stop()
        {
            IsPlaying = false;
            LastestTime = 0.0f;
        }
        public bool Check(float time)
        {
            bool isComplete = LastestTime >= time;
            if(isComplete)
            {
                this.Stop();
            }
            return isComplete;
        }
    }
}
