using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMissile : MonoBehaviour
{

    Animator animator;
    GameObject player;


    private void OnEnable()
    {
        this.transform.eulerAngles = Vector3.zero;
        StartCoroutine(GameManager.TimeOut(0.8f, this.gameObject, ObjectFlag.MonsterBombEffect));
    }



    private void Start()
    {
        animator = GameObject.Find("PlayerDummy").transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine(GameManager.TimeOut(0.8f, this.gameObject, ObjectFlag.MonsterBombEffect));
        player = GameObject.Find("PlayerDummy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 4 * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {

            animator.SetBool("Hit", true);
            Player2D.hp -= 10;
            player.GetComponent<Rigidbody>().AddForce(Vector3.right * 500);
            ObjectPool.Instance.Set(this.gameObject, ObjectFlag.MonsterBombEffect);
            ObjectPool.Instance.get(ObjectFlag.PlayerMissile, this.transform.position);
        }

       
    }
}
