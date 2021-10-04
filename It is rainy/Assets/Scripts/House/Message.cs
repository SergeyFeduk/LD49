using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    [Multiline(20)][SerializeField] private string text;
    [SerializeField] private GameObject maintext;
    private HWeatherControl globalcontroller;
    private string congratline;
    private int salary;

    void Awake(){
        globalcontroller=GameObject.Find("GlobalController").GetComponent<HWeatherControl>();
    }

    void OnEnable(){
        if (globalcontroller.firstday){salary=0;}else{salary=50-(int)globalcontroller.deltainfo.CalculateError();}
        if (!globalcontroller.firstday){
            if (globalcontroller.deltainfo.CalculateError()<10){
                congratline="really good!\nResults are pretty perfect!";
            }else if (globalcontroller.deltainfo.CalculateError()<25){
                congratline=" as good as you do in average.";
            }else{
                congratline="not as good as we want,\nif this will happen once more, then you will be replaced.\nGood luck.";
                globalcontroller.gameObject.GetComponent<MoneyController>().Warn();
            }

            maintext.GetComponent<TextMeshProUGUI>().SetText(string.Format(text,congratline, globalcontroller.deltainfo.temperature/*, globalcontroller.deltainfo.windspeed*/,
            globalcontroller.deltainfo.pressure,globalcontroller.deltainfo.wetness,globalcontroller.deltainfo.precipitationamount,salary));
        }
    } 

    public void Agree(){
        globalcontroller.gameObject.GetComponent<MoneyController>().GiveMoney(salary);
        gameObject.SetActive(false);
    }
}
