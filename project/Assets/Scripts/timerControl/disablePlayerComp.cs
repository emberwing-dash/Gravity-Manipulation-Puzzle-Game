using UnityEngine;

public class disablePlayerComp : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerMovement move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disablePlayer()
    {
        controller.enabled = false;
        move.enabled = false;   
    }

    public void enablePlayer()
    {
        controller.enabled = true;
        move.enabled = true;
    }
}
