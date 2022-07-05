using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Nav : MonoBehaviour
{

    public enum MonsterState
    { 
        Idle,
        Attack,
        Magic
    }
    // 위치 안맞는 스프라이트 조정
    IEnumerator StopMonster() {


        yield return new WaitForSeconds(0.5f);
        monPosTemp = monsterPosAni.localPosition;
        monPosTemp.y = 4.5f;
        monsterPosAni.localPosition = monPosTemp;


    }
    public Transform playerPos;
    public Transform monsterPosAni;

    public static MonsterState collisionP = MonsterState.Idle;
    private bool attackP = true;
    // 코루틴이 update로 매 프레임 마다 돌지 않고 한번씩만 시작하게 함
    private bool switchT = true;
    //대기 중일 시
    public static bool waitTime = true;
    // 플레이어 탐지 시
    public static bool detectPlayer = false;
    //몬스터를 움직이게 하는 nav
    NavMeshAgent nav;
    // 플레이어 위치
    private Vector3 PLPos;
    // 몬스터의 애니메이션
    public Animator animatorMosnter;
    // 플레이어의 애니메이션
    [SerializeField]
     Animator animatorPlayer;

    [SerializeField]
    GameObject lasers;

    private bool magicAttack;
    Vector3 monPosTemp;


    IEnumerator Laser()
    {
        for (int i = 0; i < 3; i++)
        {
            lasers.transform.GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            lasers.transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
        }

        lasers.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        lasers.transform.GetChild(1).gameObject.SetActive(false);
    }

    //대기 시간
    IEnumerator WaitTimer(bool timer,float time)
    {
     
        yield return new WaitForSeconds(time);
        attackP = true;
        waitTime = timer;
        Monster.OnceAttack = false;
        magicAttack = false;

    }
 
    // Start is called before the first frame update
    void Start()
    {

        nav = this.transform.GetComponent<NavMeshAgent>();
        PLPos = playerPos.position;


        //nav.SetDestination(PLPos); // 시작 몬스터 이동 목적지 지정


    }

    void Update()
    {

        if (waitTime)
            {
            switch (collisionP)
            {
                case MonsterState.Idle:
                    {
                        
                        animatorMosnter.SetBool("Move", false); // idle 애니메이션 시작
                        animatorMosnter.SetBool("Attack", false);
                        animatorMosnter.SetBool("Magic", false); 
                        if (detectPlayer && !magicAttack)
                        {
                            collisionP = MonsterState.Magic;
                            magicAttack = true;
                        }
                    }
                    break;
                case MonsterState.Magic:
                    {

                        animatorMosnter.SetBool("Move", false); // idle 애니메이션 시작
                            animatorMosnter.SetBool("Attack", false);
                            animatorMosnter.SetBool("Magic", true); //Magic 애니메이션 시작

                 
                        if (animatorMosnter.GetBool("Magic") && animatorMosnter.GetCurrentAnimatorStateInfo(0).IsName("MonsterMagic"))
                            {
                                if (Monster.hp > 250)
                                {

                                    Vector3 tempPos = playerPos.position;
                                    tempPos.y = 5f;
                                    ObjectPool.Instance.get(ObjectFlag.MonsterBomb, tempPos);
                                    tempPos.x = playerPos.position.x + 2f;
                                    ObjectPool.Instance.get(ObjectFlag.MonsterBomb, tempPos);
                                    tempPos.x = playerPos.position.x - 2f;
                                    ObjectPool.Instance.get(ObjectFlag.MonsterBomb, tempPos);
                                    tempPos.x = playerPos.position.x;
                                    tempPos.z = playerPos.position.z + 2f;
                                    ObjectPool.Instance.get(ObjectFlag.MonsterBomb, tempPos);
                                    tempPos.z = playerPos.position.z - 2f;
                                    ObjectPool.Instance.get(ObjectFlag.MonsterBomb, tempPos);
                                  
                                }
                                else
                                {
                                    
                                    Vector3 tempPos = playerPos.position;
                                    tempPos.y = 5f;

                                    for (int i = 0; i <= 360; i+=30)
                                    {
                                        tempPos.x = playerPos.position.x + Mathf.Cos(i) * 2f;
                                        tempPos.z = playerPos.position.z + Mathf.Sin(i) * 2f;
                                        ObjectPool.Instance.get(ObjectFlag.MonsterBomb, tempPos);

                                }                                                          
                                    lasers.transform.position = playerPos.position;
                                    StartCoroutine(Laser());
                               

                                }
                            collisionP = MonsterState.Idle;
                        }
                        
                    }             
                    break;
                case MonsterState.Attack:
                    {
                        if (attackP)
                        {
                            animatorMosnter.SetBool("Move", false); // idle 애니메이션 시작
                            animatorMosnter.SetBool("Attack", true); // Attack 애니메이션 시작
                        }

                        if (animatorMosnter.GetBool("Attack") && animatorMosnter.GetCurrentAnimatorStateInfo(0).IsName("MonsterAttack")&& !Monster.OnceAttack)
                        {
                            attackP = false;
                            Player.hp -= 10;
                            animatorPlayer.SetBool("Hit", true);
                            Debug.Log(Player.hp);
                            Monster.OnceAttack = true;

                        }
                        collisionP = MonsterState.Idle;
                    }
                    break;
              

            }

                if (switchT) // 코루틴이 update로 매 프레임 마다 돌지 않고 한번씩만 시작하게 함
                {
                    StartCoroutine(StopMonster()); // 스프라이트 내리기

                    StartCoroutine(WaitTimer(false, 5f)); //5초 대기 후 전환
                    switchT = false;
                }
        }
            else
            {
                //플레이어 탐지 시
                if (detectPlayer)
                {
                monPosTemp = monsterPosAni.localPosition;
                monPosTemp.y = 5.22f;
                monsterPosAni.localPosition = monPosTemp;
                animatorMosnter.SetBool("Move", true); // 스프라이트 올리고 이동 애니메이션 시작


                PLPos = playerPos.position;
                nav.destination = PLPos; //플레이어 위치로 목적지 지정
                if (!switchT)
                {
                    StartCoroutine(WaitTimer(true,5f)); //5초 대기 후 전환
                    switchT = true;
                }

                } 
        
            }
        
    }


    private void OnDrawGizmos()
    {

     
        Gizmos.DrawWireSphere(transform.position, 2f);

    


    }
}
