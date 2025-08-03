using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public Text timerText;
    public int winFontSize = 60;
    public Color winColor = Color.green;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            if (timerScript != null)
            {
                // Stop the timer
                var timerField = timerScript.GetType().GetField("isRunning", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (timerField != null)
                {
                    timerField.SetValue(timerScript, false);
                }
            }

            if (timerText != null)
            {
                // Change text appearance
                timerText.fontSize = winFontSize;
                timerText.color = winColor;
            }

            triggered = true;
        }
    }
}
