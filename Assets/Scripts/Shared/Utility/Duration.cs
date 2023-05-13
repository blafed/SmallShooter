using UnityEngine;


[System.Serializable]
public class Duration
{
    [Min(0)]
    [SerializeField]
    float value = 1;
    float startAtTime = float.MinValue;
    bool triggerBool;
    public float elabsed => Time.time - startAtTime;
    public float remaining => value - elabsed;
    public float length => value;
    public bool isTimeout => elabsed >= value;
    public bool isTimeoutTrigger
    {
        get
        {
            var b = triggerBool;
            triggerBool = false;
            return b;
        }
    }

    public Duration() { }
    public Duration(float dur)
    {
        this.value = dur;
    }
    public void Start()
    {
        startAtTime = Time.time;
    }
    public void StartBy(float length)
    {
        this.value = length;
        Start();
    }
}