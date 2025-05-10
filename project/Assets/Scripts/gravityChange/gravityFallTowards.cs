using UnityEngine;

public class gravityFallTowards : MonoBehaviour
{
    Vector3 gravityDirection;
    //[SerializeField] Transform PlayerRot;
    string fallTowards;

    public Transform objectToRotate; // Object to rotate
    public Transform playerBody;     // Player's facing direction (not camera)

    [SerializeField] HoloAnimations hA;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fallTowards = hA.arrow;
        
    }

    public void directionOfGravity()
    {
        if (fallTowards == "FRONT")
        {
            RotateOnce(playerBody.right, -270); // Pitch forward
        }
        if (fallTowards == "BACK")
        {
            RotateOnce(-playerBody.right, 90); // Pitch backward
        }
        if (fallTowards == "LEFT")
        {
            RotateOnce(playerBody.forward, 90);
        }
        if (fallTowards == "RIGHT")
        {
            RotateOnce(-playerBody.forward, -90); // Roll right
        }
    }

    void RotateAroundAxis(Vector3 localAxis, float angle)
    {
        // Use world axis relative to the player's orientation
        Vector3 axis = playerBody.TransformDirection(localAxis.normalized);

        // Rotate around that axis, using the object's own pivot
        Quaternion rotation = Quaternion.AngleAxis(angle, axis);
        objectToRotate.rotation = rotation;
    }

    void RotateOnce(Vector3 localAxis, float angle)
    {
        // Transform the local axis to world space using the player's orientation
        Vector3 worldAxis = playerBody.TransformDirection(localAxis.normalized);

        // Create a rotation quaternion that rotates by the given angle around the calculated world axis
        Quaternion rotation = Quaternion.AngleAxis(angle, worldAxis);

        // Apply the rotation to the object (the object's current rotation is multiplied by the new rotation)
        objectToRotate.rotation = rotation * objectToRotate.rotation;
    }

}
