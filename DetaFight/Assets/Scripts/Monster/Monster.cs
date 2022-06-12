using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{

    enum MonsterEnum
    {
        MonsterMove

    }


    Act[] monsterAct = new Act[1];
    public Transform playerPos;
    public static bool OnceAttack= false;
    [SerializeField]
    private LayerMask lm;
    //���丮 â
    [SerializeField]
    GameObject victory;
    // ������ �ִϸ��̼�
    public Animator animatorMosnter;
    [SerializeField]
    Slider monsterHP;
    //�÷��̾� ������Ʈ
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject canvus;
    bool die;
    public static int hp = 500;

    // Start is called before the first frame update
    void Start()
    {
        monsterAct[0] = new MonsterMove(); //���� �̵� Ŭ����
        monsterAct[0].P_transform = playerPos; //�÷��̾� ����
        monsterAct[0].M_transform = this.transform; //���� ����
        monsterAct[0].playerlm = lm;

        
    }

    // Update is called once per frame
    void Update()
    {
        monsterHP.value = hp;
        monsterAct[0].P_transform = playerPos;
        monsterAct[0].PlayAct();
  
        if (animatorMosnter.GetBool("Hit") && animatorMosnter.GetCurrentAnimatorStateInfo(0).IsName("MonsterHit"))
        {
            animatorMosnter.SetBool("Hit", false);
        }


        if (hp <= 0&&!die)
        {
            this.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            player.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            Time.timeScale = 0;
            animatorMosnter.SetBool("Die", true); // Die �ִϸ��̼� ����
            victory.SetActive(true);
            canvus.SetActive(false);
            die = true;
        }


        //�÷��̾ ���� ���� ���� ��� ���� ����
        Collider[] playerDetectForAttack = Physics.OverlapSphere(this.transform.position, 0.8f, lm);


        if (playerDetectForAttack.Length > 0&& !OnceAttack) 
        {
            monsterAct[0].collisionP = true;
      
        }
        else
        {
            monsterAct[0].collisionP = false;
           
        }

    }

  

}
