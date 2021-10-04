using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWeatherControl : MonoBehaviour{

    public Information info;
    public Information realinfo;
    public Information deltainfo;
    private static HWeatherControl me;
    public bool firstday = true;

    [SerializeField] private GameObject message;

    public static GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    void Awake(){
        
        if (me == null) {
            me = this;
            DontDestroyOnLoad(gameObject);
        }else if(me != this){
            Destroy(gameObject);
            return;
        }
        message=FindInActiveObjectByName("Message Icon");
        message.SetActive(true);
        weather.UpdateADay();
        if (firstday){
            weather.type=Weather.Type.Precipitation;
            weather.precipationtype=Weather.PrecType.Rain;
            weather.precipationperminute=0.001f;
            weather.precipitationamount=weather.precipationperminute*24*60;
        }
    }

    public void Compare(){
        //weather changed to new, compare info with real info and write it into deltainfo
        if (!firstday){
            deltainfo = new Information(info.windspeed-realinfo.windspeed, info.temperature-realinfo.temperature,info.pressure-realinfo.pressure,
            info.wetness-realinfo.wetness,info.precipitationamount-realinfo.precipitationamount);
            //normal error is between 10 and 25
            // 25 and more results in less money
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            StartCoroutine(GameObject.Find("SceneChanger").GetComponent<SceneChanger>().ChangeScene("Mainmenu",1,SceneChanger.Side.Left,true,true));
        }
    }

    public Weather weather;
}
