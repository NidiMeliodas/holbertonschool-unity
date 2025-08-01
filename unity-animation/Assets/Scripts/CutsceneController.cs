using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;

    private Animator animator;
    private bool hasCutscenePlayed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if animation finished and hasn't already transitioned
        if (!hasCutscenePlayed && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !animator.IsInTransition(0))
        {
            hasCutscenePlayed = true;
            EndCutscene();
        }
    }

    void EndCutscene()
    {
        // Enable Main Camera
        mainCamera.SetActive(true);

        // Enable PlayerController
        player.GetComponent<PlayerController>().enabled = true;

        // Enable TimerCanvas
        timerCanvas.SetActive(true);

        // Disable CutsceneCamera and this script
        gameObject.SetActive(false);
    }
}
