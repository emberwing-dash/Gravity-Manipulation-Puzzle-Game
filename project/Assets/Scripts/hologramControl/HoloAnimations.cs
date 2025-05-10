using UnityEngine;

public class HoloAnimations : MonoBehaviour
{
    public Transform objectToRotate; // Object to rotate
    public Transform playerBody;     // Player's facing direction (not camera)

    public string arrow;

    void Update()
    {
        if (objectToRotate == null || playerBody == null)
            return;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            RotateAroundAxis(-playerBody.right, 90); // Pitch backward
            arrow = "FRONT";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RotateAroundAxis(playerBody.right, -270); // Pitch forward
            arrow = "BACK";
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateAroundAxis(playerBody.forward, -90);
            arrow = "LEFT";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateAroundAxis(playerBody.forward, 90); // Roll right
            arrow = "RIGHT";
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
}
