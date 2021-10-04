using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Experimental.Rendering.Universal;

public class TimeController : MonoBehaviour
{
    private int day;
    public int hour;
    public int minute;
    [SerializeField] private AnimationCurve outsidebrightness;
    [HideInInspector] public float brightness;
    [SerializeField] private GameObject clock;
    [SerializeField] private GameObject message;

    [Header("Light")]
    [SerializeField] private GameObject outlight;
    [SerializeField] private GameObject globallight;
    [SerializeField] private GameObject outside;
    [SerializeField] private GameObject outsidelight;
    private GameObject globalcontroller;
    [SerializeField] private bool gotmessage=false;

    public float secpermin;

    void Start(){
        Invoke("Minute",secpermin); // every second passes 2 minutes
    }

    void OnEnable() {
      SceneManager.sceneLoaded += OnSceneLoad;
    }
    
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode){
        globalcontroller = GameObject.Find("GlobalController");
        GetComponent<MoneyController>().SetMoneyText();
        outside=GameObject.Find("OutsideBg");
        outlight=GameObject.Find("OutLight");
        globallight=GameObject.Find("MainLight");
        clock=GameObject.Find("ClockText");
        outsidelight=GameObject.Find("OutsideLight");
        message=HWeatherControl.FindInActiveObjectByName("Message Icon");
        UpdateLight();
        GetComponent<HWeatherControl>().weather.WeatherEffectsUpdate();
        if (message!=null && !globalcontroller.GetComponent<HWeatherControl>().firstday) {
            if (hour*60+minute<1200){
                message.SetActive(false);
            }else{
                if (!gotmessage){
                    gotmessage=true;
                    message.SetActive(true);
                }
            }
        }
    }

    public void UpdateLight(){
        brightness = outsidebrightness.Evaluate((hour*60+minute)/1440f);
        if(outlight!=null){
            if(SceneManager.GetActiveScene().name=="House"){
                outlight.GetComponent<Light2D>().intensity=brightness*2;
            }else{
                outlight.GetComponent<Light2D>().intensity=brightness;
            }
        }
        if(globallight!=null){globallight.GetComponent<Light2D>().intensity=brightness/2.5f;}
        if (outsidelight!=null){outsidelight.GetComponent<Light2D>().intensity=brightness/2f;}
        if(outside!=null){outside.GetComponent<OutsideColor>().ChangeColor();}
    }

    public void Minute(){
        if (minute/59!=1){
            minute++;
        }else{
            minute=0;
            hour++;
        }
        if (message!=null){
            if (hour*60+minute==1200 && !globalcontroller.GetComponent<HWeatherControl>().firstday && !gotmessage){
                gotmessage=true;
                message.SetActive(true);
            }
        }
        if (hour>=24){
            hour=0;day++;
            gotmessage=false;
            GetComponent<HWeatherControl>().firstday=false;
            GetComponent<HWeatherControl>().weather.UpdateADay();
        }

        

        if(clock!=null){clock.GetComponent<TextMeshPro>().SetText(string.Format("{0} : {1}",hour.ToString("00"),minute.ToString("00")));}
        UpdateLight();
        Invoke("Minute",secpermin);
    }
}
