using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{
    [Header("audio")]
    [SerializeField]
    AudioClip hitMonsterAudio;
    AudioSource audioSource;

    enum MonsterEnum
    {
        MonsterMove

    }

  
    Act[] monsterAct = new Act[1];
    [Header("other")]
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
        animatorMosnter.SetBool("Move",false);
        animatorMosnter.SetBool("Attack", false);
        animatorMosnter.SetBool("Magic", false);
        animatorMosnter.SetBool("Die", false);
        hp = 500;
        audioSource = gameObject.AddComponent<AudioSource>();
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
            
            audioSource.clip = hitMonsterAudio;
            audioSource.Play();
            animatorMosnter.SetBool("Hit", false);
        }


        if (hp <= 0&&!die)
        {
            Nav.collisionP = Nav.MonsterState.Idle;
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


        if (playerDetectForAttack.Length > 0&& !OnceAttack&& Player.hp>0&&hp>0) 
        {
            monsterAct[0].collisionP = true;
      
        }
        else
        {
            monsterAct[0].collisionP = false;
           
        }

    }

  

}
