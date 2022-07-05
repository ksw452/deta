using System.Collections;
using System.Collections.Generic;
using UnityEngine;





//캐릭터의 기초 활동 클래스
public class Act 
{

    public LayerMask playerlm;
    public AudioSource audioSource;
    public AudioClip jumpAudio;
    // Start is called before the first frame update
    public bool collisionP = false;
    public bool flips = false;
    public Transform P_transform;
    public Transform M_transform;
    public Rigidbody P_rigidbody;




    virtual public void PlaySound()
    {
        // 캐릭터 오디오 시작
        audioSource.Play();

    }

    virtual public void PlayAct()
    {


    }
}
