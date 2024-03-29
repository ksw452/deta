using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //플레이어 상태
    enum PlayerEnum
    {
        PlayerMove,
        PlayerJump,
        PlayerShoot

    }
    //플레이어가 바닥에 닿았는지
    public static bool planeState = true;
    // 플레이어의 애니메이션
    [SerializeField]
    Animator animatorPlayer;
    public static int hp;
    //플레이어 상태들 모음
    Act[] playerAct = new Act[2];
    //게임 오버 창
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
        // 플레이어 상태 인스턴스 생성
        playerAct[(int)PlayerEnum.PlayerMove] = new PlayerMove();
        playerAct[(int)PlayerEnum.PlayerJump] = new PlayerJump();
       

        //초기화 입력
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

        // 플레이어가 공격 받은 이후 플레이어의 애니메이션 전환
        if (animatorPlayer.GetBool("Hit") && animatorPlayer.GetCurrentAnimatorStateInfo(0).IsName("PlayerHit"))
        {
          
            playerAudioSource.clip = hitPlayerAudio;
            playerAudioSource.Play();
           
            animatorPlayer.SetBool("Hit", false);
        }

        //플레이어 활동 반복
        for (int i = 0; i < playerAct.Length; i++)
        {

            playerAct[i].PlayAct();

        }

        // 플레이어 죽음
        if (hp <= 0&&!die)
        {
         
            animatorPlayer.SetBool("Die", true); // Die 애니메이션 시작
            Time.timeScale = 0;
            gameover.SetActive(true);
            canvus.SetActive(false);
            die = true;
        }

    }

    //플레이어 바닥과 접촉
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {

            planeState = true;


        }
     
        

    }

}
