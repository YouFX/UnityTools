
using TMPro;
using UnityEngine;

public class FPSDisplay: MonoBehaviour
{
    public TMP_Text tMP_Text;
    public float interval = 1;
    public int frameCount;
    public float deltaTime;
    public int fps;

    private void Awake()
    {
        tMP_Text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        frameCount++;
        deltaTime += Time.deltaTime;
        if (deltaTime > interval)
        {
            fps = Mathf.RoundToInt(frameCount / deltaTime);
            tMP_Text.text = fps + " FPS";
            frameCount = 0;
            deltaTime -= interval;
        }
    }
}