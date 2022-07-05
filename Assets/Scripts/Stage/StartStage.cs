using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour
{
    public static int speed = 4;
    public static bool playerMoveB;
   
    bool oneTimeAni2;
    [SerializeField]
    Animator playerAni;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject boss;
    [SerializeField]
    GameObject duck;
    // Start is called before the first frame update
    void Start()
    { 
        boss.transform.up = boss.transform.position - duck.transform.position;
        playerMoveB = false;
    }

    bool run;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(boss.transform.position, duck.transform.position) <1)
        {
            boss.transform.up = Vector3.up;
            duck.transform.SetParent(boss.transform);

            Vector3 duckPos = duck.transform.localPosition;
            duckPos.y += 1;
            duckPos.x -= 1;
            duck.transform.localPosition = duckPos;
            run = true;
            
        }
        else
        {
            if(!run)
            boss.transform.Translate(Vector3.down*speed* Time.deltaTime);
        }

        if (run)
        {
        
           
            if (boss.transform.position.x < 0)
            {
                boss.gameObject.SetActive(false);
                duck.gameObject.SetActive(false);
                playerMoveB = true;
               
           


            }
            else
            {
                if (!oneTimeAni2)
                    playerAni.SetBool("Hit", true);

                oneTimeAni2 = true;
                boss.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }

    }
}
