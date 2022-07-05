using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GreenJellyM : MonoBehaviour
{


    Animator animator;
    private void Start()
    {
        animator = GameObject.Find("PlayerDummy").transform.GetChild(0).GetComponent<Animator>();
     

    }
    bool flips = false;

    private void Update()
    {
      
        float flip = Time.deltaTime/2;
        Vector3 jellyPos = this.transform.parent.localPosition;
      
 

      
        if (!flips)
        {
     
           jellyPos.x = Mathf.Clamp(jellyPos.x - flip, -0.3f, 0.3f);
            if (jellyPos.x <= -0.3f)
            {
                flips = true;
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else
        {
            jellyPos.x = Mathf.Clamp(jellyPos.x + flip, -0.3f, 0.3f);
            if (jellyPos.x >= 0.3f)
            {
             
                flips = false;
                transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
            }
           
        }

        this.transform.parent.localPosition = jellyPos;
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
