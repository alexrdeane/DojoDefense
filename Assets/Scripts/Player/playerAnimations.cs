using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    public Animator[] animator;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            animator[0].SetBool("isThrowing", true);
            animator[0].SetBool("isRunnng", false);
        }
        else if (!Input.GetKeyUp(KeyCode.E))
        {
            animator[0].SetBool("isThrowing", false);
        }
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            animator[0].SetBool("isRunning", true);
            if (Input.GetKey(KeyCode.E))
            {
                animator[0].SetBool("isThrowing", true);
            }
        }
        else if (!Input.GetKey(KeyCode.W) || (!Input.GetKey(KeyCode.A)) || (!Input.GetKey(KeyCode.S)) || (!Input.GetKey(KeyCode.D)))
        {
            animator[0].SetBool("isRunning", false);
        }
    }
}
