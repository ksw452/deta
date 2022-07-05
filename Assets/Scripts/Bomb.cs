using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator animator;

    private void OnEnable()
    {
        StartCoroutine(GameManager.TimeOut(3f, this.gameObject, ObjectFlag.MonsterBomb, ObjectFlag.MonsterBombEffect));

    }

    private void Start()
    {
        animator = GameObject.Find("PlayerDummy").transform.GetChild(0).GetComponent<Animator>();

       
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.CompareTag("Player"))
        {
            ObjectPool.Instance.Set(this.gameObject, ObjectFlag.MonsterBomb);
            ObjectPool.Instance.get(ObjectFlag.MonsterBombEffect, this.transform.position);
            animator.SetBool("Hit",true);
            Player.hp -= 20;
         
        }


    }

}
