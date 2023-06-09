using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1move : MonoBehaviour
{
    private Animator Anim;
    public float WalkSpeed = 0.001f;
    public float JumpSpeed = 1.0f;
    private bool IsJumping = false;
    private AnimatorStateInfo Player1Layer0;
    private bool CanWalkLeft = true;
    private bool CanWalkRight = true;


    // Start is called before the first frame update
    void Start()
    {
        Anim=GetComponentInChildren<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
        //Litsen to the animator

        Player1Layer0 = Anim.GetCurrentAnimatorStateInfo(0);

        Vector3 ScreenBounds = Camera.main.WorldToScreenPoint(this.transform.position);

        if(ScreenBounds.x > Screen.width -200)
        {
            CanWalkRight = false;
        }
        if (ScreenBounds.x < 200)
        {
            CanWalkLeft = false;
        }
        else if (ScreenBounds.x >200 && ScreenBounds.x <Screen.width - 200)
        {
            CanWalkRight = true;
            CanWalkLeft = true;

        }
        //walking forward and backward
        if (Player1Layer0.IsTag("Motion"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                if (CanWalkRight == true)
                {
                    Anim.SetBool("forward", true);
                    transform.Translate(WalkSpeed, 0, 0);
                }
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                if (CanWalkLeft == true)
                {
                    Anim.SetBool("backward", true);
                    transform.Translate(-WalkSpeed, 0, 0);
                }
            }
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("forward", false);
            Anim.SetBool("backward", false);
        }

        //jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            if (IsJumping == false)
            {
                IsJumping = true;
                Anim.SetTrigger("jump");
                StartCoroutine(JumpPause());
            }

        }
        if (Input.GetAxis("Vertical") < 0)
        {
            Anim.SetBool("crouch",true);
        }
        if (Input.GetAxis("Vertical") == 0)
        {
            Anim.SetBool("crouch", false);
        }

    }

    IEnumerator JumpPause()
    {
        yield return new WaitForSeconds(1.0f);
        IsJumping = false;
    }
}
