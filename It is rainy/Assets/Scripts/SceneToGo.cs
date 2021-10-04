using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneToGo : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private string scname;

    void Start(){
        StartCoroutine(Go());
    }
    IEnumerator Go(){
        yield return new WaitForSeconds(time);
        StartCoroutine(GetComponent<SceneChanger>().ChangeScene(scname,1,SceneChanger.Side.Left,true,true));
    }
}
