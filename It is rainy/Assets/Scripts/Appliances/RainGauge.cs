using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RainGauge : MonoBehaviour
{
    private float actualprecipationperminute;
    private float actualtime;
    [SerializeField] private float val;

    private GameObject globalcontroller;
    [SerializeField] private GameObject slider;
    [SerializeField] private GameObject clock;
    private float hour,minute;

    void Start(){
        globalcontroller = GameObject.Find("GlobalController");
    }

    void OnEnable(){
        globalcontroller = GameObject.Find("GlobalController");
    }

    void Update(){
        hour=globalcontroller.GetComponent<TimeController>().hour;
        minute=globalcontroller.GetComponent<TimeController>().minute;
        actualprecipationperminute=globalcontroller.GetComponent<HWeatherControl>().weather.precipationperminute;
        actualtime=hour*60+minute;
        
        val = actualprecipationperminute*actualtime;
        clock.GetComponent<TextMeshProUGUI>().SetText(string.Format("{0} : {1}",hour.ToString("00"),minute.ToString("00")));
        slider.GetComponent<Slider>().value=val/10;
    }
}
