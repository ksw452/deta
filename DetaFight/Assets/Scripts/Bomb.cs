using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GameObject.Find("PlayerDummy").transform.GetChild(0).GetComponent<Animator>();

        StartCoroutine(GameManager.TimeOut(3f, this.gameObject, ObjectFlag.PlayerMissile, ObjectFlag.MonsterBombEffect));
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.transform.CompareTag("Player"))
        {
            ObjectPool.Instance.Set(this.gameObject, ObjectFlag.MonsterBomb);
            ObjectPool.Instance.get(ObjectFlag.MonsterBombEffect, this.transform.position);
            animator.SetBool("Hit",true);
            Player.hp -= 20;
            Debug.Log(Player.hp);
        }


    }

}
