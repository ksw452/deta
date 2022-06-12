using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Missile : MonoBehaviour
{
    Animator animator;
    private void onEnable()
    {
        this.transform.eulerAngles = Vector3.zero;
    }



    private void Start()
    {
        animator = GameObject.Find("MonsterDummy").transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine(GameManager.TimeOut(1f,this.gameObject,ObjectFlag.PlayerMissile));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 4 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Monster"))
        {
            Debug.Log(Monster.hp);
            animator.SetBool("Hit", true);
            Monster.hp -= 10;
            ObjectPool.Instance.Set(this.gameObject, ObjectFlag.PlayerMissile);
            ObjectPool.Instance.get(ObjectFlag.PlayerMissileEffect, this.transform.position);
        }


    }
}
