using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1move : MonoBehaviour
{
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim=GetComponent<Animator>();
         
    }

    // Update is called once per frame
    void Update()
    {
        //walking forward and backward
        if(Input.GetAxis("Horizontal") >0)
        {
            Anim.SetBool("forward", true);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            Anim.SetBool("backward", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            Anim.SetBool("forward", false);
            Anim.SetBool("backward", false);
        }

        //jumping and crouching
        if (Input.GetAxis("Vertical") > 0)
        {
            Anim.SetTrigger("jump");
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
}
