using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    [SerializeField]
    GameObject canvusO;
    [SerializeField]
    GameObject canvusV;
    [SerializeField]
    GameObject canvusM;



    public static IEnumerator TimeOut(float time,GameObject gameObject, ObjectFlag objectFlag, ObjectFlag effect)
    {

        yield return new WaitForSeconds(time);
        ObjectPool.Instance.Set(gameObject, objectFlag);
        ObjectPool.Instance.get(effect, gameObject.transform.position);
    }

    public static IEnumerator TimeOut(float time, GameObject gameObject, ObjectFlag objectFlag)
    {

        yield return new WaitForSeconds(time);
        ObjectPool.Instance.Set(gameObject, objectFlag);
    
    }


    //public void Restart()
    //{

    //    Time.timeScale = 1;
    //    canvusO.SetActive(false);
    //    canvusV.SetActive(false);
    //    canvusM.SetActive(true);
    //    //SceneManager.LoadScene("SampleScene");
      
    //}
    public void Quit()
    {

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        

    }

}
