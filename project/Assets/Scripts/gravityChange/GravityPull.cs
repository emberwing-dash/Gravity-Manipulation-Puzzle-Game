using UnityEngine;

public class GravityPull : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    string arrowPressed;  //UP, DOWN, LEFT , RIGHT ARROW
    public bool enterPressed;

    [Header("Gravity Control")]
    [SerializeField] HoloAnimations hA;
    [SerializeField] gravityFallTowards gFT;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        arrowPressed = hA.arrow;
        Vector3 direction = gravityDirection();

        checkEnter();
        if (enterPressed)
        {
            Physics.gravity = direction;
            gFT.directionOfGravity();
            enterPressed = false;
        }
    }

    Vector3 gravityDirection()
    {
        if(arrowPressed == "FRONT")
        {
            return Vector3.forward;
        }
        if(arrowPressed == "BACK")
        {
            return Vector3.back;
        }
        if(arrowPressed == "LEF")
        {
            return Vector3.left;
        }
        if(arrowPressed == "RIGHT")
        {
            return Vector3.right;
        }
        return Vector3.zero;
    }

    void checkEnter()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            enterPressed = true;
    }
}
