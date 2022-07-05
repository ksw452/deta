using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerStage : MonoBehaviour
{

    [SerializeField]
    int lastNum;
    [SerializeField]
    GameObject canvusO;

    [SerializeField]
    GameObject canvusM;

    [SerializeField]
    GameObject mainPosition;


    [Header("BOXES")]
    [SerializeField]
    GameObject box;
    [SerializeField]
    GameObject cactus;
    [SerializeField]
    GameObject cactusDouble;
    [SerializeField]
    GameObject jump;
    [SerializeField]
    GameObject jelly1;
    [SerializeField]
    GameObject jelly1Double;
    [SerializeField]
    GameObject jelly2;
    [SerializeField]
    GameObject potal;


    private void Start()
    {
        CreateBox();
        Time.timeScale = 1;
        Player2D.hp = 100;

    }

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


    public void Restart()
    {

        Time.timeScale = 1;
   
        canvusO.SetActive(false);
 
        Mathf.Clamp(StartStage.speed++,4,15);
        canvusM.SetActive(true);
        SceneManager.LoadScene("Stage1");
     

    }
    public void Quit()
    {

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        

    }


    public void CreateBox()
    {
        

        Vector3 newPos = mainPosition.transform.position;

        float limit = newPos.y; 

       
        newPos.x -= Random.Range(2.0f, 4.0f);
        newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit-10f, limit+10f);
     
        for (int i = 0; i < lastNum; i++)
        {

            if (i == lastNum-1)
            {
                newPos.x -= 2f;
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 0.5f), limit - 10f, limit + 10f);
                GameObject newBox = GameObject.Instantiate(potal, newPos, Quaternion.identity, mainPosition.transform.parent);

                break;
            }


            int ranNum = Random.Range(1, 101);

            if (ranNum <= 20)
            {

                GameObject newBox = GameObject.Instantiate(box, newPos, Quaternion.identity, mainPosition.transform.parent);
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit - 10f, limit + 10f);
            }
            else if (ranNum > 20 && ranNum <= 40)
            {

                GameObject newBox = GameObject.Instantiate(cactus, newPos, Quaternion.identity, mainPosition.transform.parent);
                Vector3 monsterPos = newBox.transform.GetChild(0).GetChild(0).transform.localPosition;
                monsterPos.z = Random.Range(-0.3f, 0.3f);
                monsterPos.x = Random.Range(-0.3f, 0.3f);
                newBox.transform.GetChild(0).GetChild(0).transform.localPosition = monsterPos;
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit - 10f, limit + 10f);

            }
            else if (ranNum > 40 && ranNum <= 50)
            {

                GameObject newBox = GameObject.Instantiate(jump, newPos, Quaternion.identity, mainPosition.transform.parent);
                Vector3 monsterPos = newBox.transform.GetChild(0).GetChild(0).transform.localPosition;
                monsterPos.z = Random.Range(-0.3f, 0.3f);
                newBox.transform.GetChild(0).GetChild(0).transform.localPosition = monsterPos;
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(1f, 2f), limit - 10f, limit + 10f);

            }
            else if (ranNum > 50 && ranNum <= 60)
            {

                GameObject newBox = GameObject.Instantiate(jelly2, newPos, Quaternion.identity, mainPosition.transform.parent);
                Vector3 monsterPos = newBox.transform.GetChild(0).GetChild(0).transform.localPosition;
                monsterPos.z = Random.Range(-0.3f, 0.3f);
                newBox.transform.GetChild(0).GetChild(0).transform.localPosition = monsterPos;
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit - 10f, limit + 10f);

            }
            else if (ranNum > 60 && ranNum <= 70)
            {

                GameObject newBox = GameObject.Instantiate(jelly1Double, newPos, Quaternion.identity, mainPosition.transform.parent);
                Vector3 monsterPos = newBox.transform.GetChild(0).GetChild(0).transform.localPosition;
                monsterPos.z = -0.2f;
                monsterPos.x = Random.Range(-0.4f, 0.4f);
                newBox.transform.GetChild(0).GetChild(0).transform.localPosition = monsterPos;
                Vector3 monsterPos2 = newBox.transform.GetChild(0).GetChild(1).transform.localPosition;
                monsterPos2.z = 0.2f;
                monsterPos2.x = Random.Range(-0.4f, 0.4f);
                newBox.transform.GetChild(0).GetChild(1).transform.localPosition = monsterPos2;
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit - 10f, limit + 10f);

            }
            else if (ranNum > 70 && ranNum <= 80)
            {

                GameObject newBox = GameObject.Instantiate(cactusDouble, newPos, Quaternion.identity, mainPosition.transform.parent);
                Vector3 monsterPos = newBox.transform.GetChild(0).GetChild(0).transform.localPosition;
                monsterPos.z = Random.Range(-0.3f, 0.3f);
                monsterPos.x = Random.Range(-0.35f, 0.35f);
                newBox.transform.GetChild(0).GetChild(0).transform.localPosition = monsterPos;

                Vector3 monsterPos2 = newBox.transform.GetChild(0).GetChild(1).transform.localPosition;
                monsterPos2.z = Random.Range(-0.3f, 0.3f);
                monsterPos2.x = Random.Range(-0.35f, 0.35f);
                newBox.transform.GetChild(0).GetChild(1).transform.localPosition = monsterPos2;
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit - 10f, limit + 10f);

            }
            else
            {
                GameObject newBox = GameObject.Instantiate(jelly1, newPos, Quaternion.identity, mainPosition.transform.parent);
                Vector3 monsterPos = newBox.transform.GetChild(0).GetChild(0).transform.localPosition;
                monsterPos.z = Random.Range(-0.3f, 0.3f);
                monsterPos.x = Random.Range(-0.3f, 0.3f);
                newBox.transform.GetChild(0).GetChild(0).transform.localPosition = monsterPos;
                newPos.x -= Random.Range(2.0f, 3.9f);
                newPos.y = Mathf.Clamp(newPos.y + Random.Range(-1.5f, 1f), limit - 10f, limit + 10f);

            }

        }
    
    
    }

}
