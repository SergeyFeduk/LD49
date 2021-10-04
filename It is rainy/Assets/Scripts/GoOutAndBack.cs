using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoOutAndBack : MonoBehaviour
{
    private GameObject gamecontroller;

    public void GoOut(){
        gamecontroller=GameObject.Find("GlobalController");
        gamecontroller.GetComponent<TimeController>().secpermin=0.5f;
        StartCoroutine(GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeScene("Outside",1,SceneChanger.Side.Right,true,true));
    }

    public void GoHome(){
        StartCoroutine(GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeScene("House",1,SceneChanger.Side.Left,true,true));
    }
}
