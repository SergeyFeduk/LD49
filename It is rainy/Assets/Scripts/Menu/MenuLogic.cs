using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    public void Exit(){
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Play(){
        StartCoroutine(GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeScene("House",1,SceneChanger.Side.Left,true,true));
    }
}
