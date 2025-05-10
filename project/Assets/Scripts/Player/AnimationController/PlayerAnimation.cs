using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] public Animator anim;
    [SerializeField] PlayerMovement move;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move.MoveIsPressed)
        {
            anim.SetBool("isRun", true);
        }
        else if(move.JumpIsPressed)
        {
            anim.SetBool("isFall", true);
        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isFall", false);
        }
    }
}
