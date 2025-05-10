using UnityEngine;
using UnityEngine.UI;

public class timerControl : MonoBehaviour
{
    public Text timerText; // Optional: assign a UI Text component in Inspector to display timer
    private float timer = 0f;
    private float maxTime = 120f; // 2 minutes

    [SerializeField] GravityPull gP;

    private void Start()
    {
        gP.enterPressed = false;
    }

    void Update()
    {
        
        if (AreArrowKeysPressed())
        {
            timer += Time.deltaTime;

            if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
            {
                print("Enter pressed");
                gP.enterPressed = true;
            }

            if (timer >= maxTime)
            {
                timer = maxTime; // Clamp to 2 minutes
                // You can add any event or trigger here
                Debug.Log("Timer reached 2 minutes!");
                gP.enterPressed = true;
            }
        }
        else
        {
            // Reset the timer if no arrow keys are pressed
            timer = 0f;
            gP.enterPressed = false;
        }

        // Update UI (if assigned)
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    bool AreArrowKeysPressed()
    {
        return Input.GetKey(KeyCode.UpArrow) ||
               Input.GetKey(KeyCode.DownArrow) ||
               Input.GetKey(KeyCode.LeftArrow) ||
               Input.GetKey(KeyCode.RightArrow);
    }
}
