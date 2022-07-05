using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //�÷��̾� ����
    enum PlayerEnum
    {
        PlayerMove,
        PlayerJump,
        PlayerShoot

    }
    //�÷��̾ �ٴڿ� ��Ҵ���
    public static bool planeState = true;
    // �÷��̾��� �ִϸ��̼�
    [SerializeField]
    Animator animatorPlayer;
    public static int hp;
    //�÷��̾� ���µ� ����
    Act[] playerAct = new Act[2];
    //���� ���� â
    [SerializeField]
    GameObject gameover;
    [SerializeField]
    Slider playerHp;

    bool die;

    [SerializeField]
    GameObject monster;
    [SerializeField]
    GameObject canvus;


    AudioSource playerAudioSource;
    [Header("Audio")]
    [SerializeField]
    AudioClip hitPlayerAudio;
    [SerializeField]
    AudioClip jumpPlayerAudio;

 
    // Start is called before the first frame update

    private void Start()
    {
        hp = Player2D.hp;
        playerAudioSource = gameObject.AddComponent<AudioSource>();
        playerAudioSource.clip = jumpPlayerAudio;
        // �÷��̾� ���� �ν��Ͻ� ����
        playerAct[(int)PlayerEnum.PlayerMove] = new PlayerMove();
        playerAct[(int)PlayerEnum.PlayerJump] = new PlayerJump();
       

        //�ʱ�ȭ �Է�
        for (int i = 0; i < playerAct.Length; i++)
        {
            playerAct[i].P_transform = this.transform;
        }
        
     
        playerAct[(int)PlayerEnum.PlayerJump].P_rigidbody = this.transform.GetComponent<Rigidbody>();
        playerAct[(int)PlayerEnum.PlayerJump].audioSource =  this.gameObject.GetComponent<AudioSource>();
        playerAct[(int)PlayerEnum.PlayerJump].jumpAudio = jumpPlayerAudio;
    }
    // Update is called once per frame
    void Update()
    {
       
        playerHp.value = hp;

        // �÷��̾ ���� ���� ���� �÷��̾��� �ִϸ��̼� ��ȯ
        if (animatorPlayer.GetBool("Hit") && animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("PlayerHit"))
        {
          
            playerAudioSource.clip = hitPlayerAudio;
            playerAudioSource.Play();
           
            animatorPlayer.SetBool("Hit", false);
        }

        //�÷��̾� Ȱ�� �ݺ�
        for (int i = 0; i < playerAct.Length; i++)
        {

            playerAct[i].PlayAct();

        }

        // �÷��̾� ����
        if (hp <= 0&&!die)
        {
         
            animatorPlayer.SetBool("Die", true); // Die �ִϸ��̼� ����
            Time.timeScale = 0;
            gameover.SetActive(true);
            canvus.SetActive(false);
            die = true;
        }

    }

    //�÷��̾� �ٴڰ� ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {

            planeState = true;


        }
     
        

    }

}
