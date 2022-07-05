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
    // ��ġ �ȸ´� ��������Ʈ ����
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
    // �ڷ�ƾ�� update�� �� ������ ���� ���� �ʰ� �ѹ����� �����ϰ� ��
    private bool switchT = true;
    //��� ���� ��
    public static bool waitTime = true;
    // �÷��̾� Ž�� ��
    public static bool detectPlayer = false;
    //���͸� �����̰� �ϴ� nav
    NavMeshAgent nav;
    // �÷��̾� ��ġ
    private Vector3 PLPos;
    // ������ �ִϸ��̼�
    public Animator animatorMosnter;
    // �÷��̾��� �ִϸ��̼�
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

    //��� �ð�
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


        //nav.SetDestination(PLPos); // ���� ���� �̵� ������ ����


    }

    void Update()
    {

        if (waitTime)
            {
            switch (collisionP)
            {
                case MonsterState.Idle:
                    {
                        
                        animatorMosnter.SetBool("Move", false); // idle �ִϸ��̼� ����
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

                        animatorMosnter.SetBool("Move", false); // idle �ִϸ��̼� ����
                            animatorMosnter.SetBool("Attack", false);
                            animatorMosnter.SetBool("Magic", true); //Magic �ִϸ��̼� ����

                 
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
                            animatorMosnter.SetBool("Move", false); // idle �ִϸ��̼� ����
                            animatorMosnter.SetBool("Attack", true); // Attack �ִϸ��̼� ����
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

                if (switchT) // �ڷ�ƾ�� update�� �� ������ ���� ���� �ʰ� �ѹ����� �����ϰ� ��
                {
                    StartCoroutine(StopMonster()); // ��������Ʈ ������

                    StartCoroutine(WaitTimer(false, 5f)); //5�� ��� �� ��ȯ
                    switchT = false;
                }
        }
            else
            {
                //�÷��̾� Ž�� ��
                if (detectPlayer)
                {
                monPosTemp = monsterPosAni.localPosition;
                monPosTemp.y = 5.22f;
                monsterPosAni.localPosition = monPosTemp;
                animatorMosnter.SetBool("Move", true); // ��������Ʈ �ø��� �̵� �ִϸ��̼� ����


                PLPos = playerPos.position;
                nav.destination = PLPos; //�÷��̾� ��ġ�� ������ ����
                if (!switchT)
                {
                    StartCoroutine(WaitTimer(true,5f)); //5�� ��� �� ��ȯ
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
