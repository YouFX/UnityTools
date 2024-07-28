
using System;
using Sirenix.OdinInspector;

[Serializable]
public class Timer
{
    [HorizontalGroup]
    public float length;
    [HorizontalGroup]
    public float timer;
    public event Action timeout;
    public Timer()
    {

    }
    public Timer(float length)
    {
        this.length = length;
        this.timer = length;
    }
    public void Enable(float length)
    {
        if (length >= 0)
        {
            this.length = length;
        }
        else if (this.length < 0)
        {
            this.length = 0;
        }
        timer = this.length;
    }
    public void Enable()
    {
        if (this.length < 0)
        {
            this.length = 0;
        }
        timer = this.length;
    }

    public void Update(float delta)
    {
        if (timer <= 0) return;
        timer -= delta;
        if (timer <= 0)
        {
            timeout?.Invoke();
        }
    }
}