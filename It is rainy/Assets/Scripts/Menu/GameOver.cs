using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject blackout;

    public void Shoot(){
        blackout.SetActive(true);
        StartCoroutine(shot());
        
    }
    IEnumerator shot(){
        yield return new WaitForSeconds(3f);
        StartCoroutine(GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeScene("Mainmenu",1,SceneChanger.Side.Left,true,true));
    }
}
