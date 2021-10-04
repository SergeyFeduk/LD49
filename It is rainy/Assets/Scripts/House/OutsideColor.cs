using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideColor : MonoBehaviour
{
    private Color color;
    [SerializeField] private Color basecolor;
    [SerializeField] private GameObject controller;
    void Start(){
        controller=GameObject.Find("GlobalController");
    }

    public void ChangeColor(){
        controller=GameObject.Find("GlobalController");
        float hue = 0, sat, val;
        Color.RGBToHSV(basecolor, out hue, out sat, out val);
        val=controller.GetComponent<TimeController>().brightness/1.25f;
        switch (controller.GetComponent<HWeatherControl>().weather.type){
            case Weather.Type.Clear:
                break;
            case Weather.Type.Cloudy:
                val*=0.9f;
                break;
            case Weather.Type.Precipitation:
                val*=0.9f;
                sat*=0.9f;
                break;
        }
        color=Color.HSVToRGB(hue,sat,val);
        GetComponent<SpriteRenderer>().color = color;
    }
}
