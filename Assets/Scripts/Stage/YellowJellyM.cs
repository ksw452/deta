using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowJellyM : MonoBehaviour
{
    Animator animator;

    IEnumerator missileShoot()
    {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                GameObject missile = ObjectPool.Instance.get(ObjectFlag.MonsterBombEffect, this.transform.position);
            }
     }

    private void Start()
    {
        animator = GameObject.Find("PlayerDummy").transform.GetChild(0).GetComponent<Animator>();
      
       
    }


    private void OnEnable()
    {
        StartCoroutine(missileShoot());
       
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
