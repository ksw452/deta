using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GameObject.Find("PlayerDummy").transform.GetChild(0).GetComponent<Animator>();


    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Player"))
        {

            animator.SetBool("Hit", true);
            Player2D.hp -= 20;

        }

    }

}
