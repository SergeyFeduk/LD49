using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barometer : MonoBehaviour
{
    private int clicks=0;
    private float cps = 0;
    private float timer = 0;
    private bool enable = true;
    public float actualvalue;
    [SerializeField] private float bestcps = 12f;
    [SerializeField] private float maxpressure = 800f;
    [SerializeField] private float minpressure = 700f;

    [SerializeField] private GameObject displayer;
    [SerializeField] private GameObject leftslider;
    [SerializeField] private GameObject rightslider;

    private GameObject globalcontroller;

    void Start(){
        globalcontroller= GameObject.Find("GlobalController");
    }

    public void Click(){
        clicks++;
    }
    public void Reset(){
        clicks=0;
        timer=0;
        cps=0;
        enable=false;
    }

    void OnEnable(){
        globalcontroller= GameObject.Find("GlobalController");
        if (globalcontroller!=null){actualvalue = globalcontroller.GetComponent<HWeatherControl>().weather.pressure;}
    }
    void Update(){
        if (enable){
            timer+=Time.deltaTime;
            if (timer>=1f){cps=clicks/timer;}
            displayer.GetComponent<TextMeshProUGUI>().SetText(string.Format("Cps: {0}\n {1} s",cps.ToString("F2"),(5-(timer-1)).ToString("F2")));
            if (timer>=6f){
                timer=1;
                clicks=0;
                
            }
            float leftval = Mathf.Clamp(Mathf.Lerp(550f,((actualvalue-minpressure)/(maxpressure-minpressure))*470,Mathf.Clamp(cps/bestcps,0f,1f)),80f,550f);
            float rightval = Mathf.Clamp(Mathf.Lerp(550f,470-((actualvalue-minpressure)/(maxpressure-minpressure))*470,Mathf.Clamp(cps/bestcps,0f,1f)),80f,550f);
            leftslider.GetComponent<RectTransform>().SetBottom(leftval);
            rightslider.GetComponent<RectTransform>().SetTop(rightval);

        }else{
            displayer.GetComponent<TextMeshProUGUI>().SetText(string.Format("I'm locked in basement"));
        }
        
    }
}
