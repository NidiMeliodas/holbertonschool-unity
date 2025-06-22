using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float timer = 0f;

    // 🔧 Change this from private to public:
    public bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = timer % 60f;

        timerText.text = string.Format(CultureInfo.InvariantCulture, "{0:0}:{1:00.00}", minutes, seconds);
    }
}
