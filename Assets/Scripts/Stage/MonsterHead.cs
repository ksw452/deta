using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHead : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Player"))
        {

            this.transform.parent.gameObject.SetActive(false);
            ObjectPool.Instance.get(ObjectFlag.MonsterBomb, this.transform.position);
        }

    }
}
