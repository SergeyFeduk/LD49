using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hydrometer : MonoBehaviour
{
    private float actualwetness;
    private float actualtemperature;

    private GameObject globalcontroller;

    [SerializeField] private GameObject valueslider;
    [SerializeField] private GameObject display;

    [SerializeField] private GameObject tempinput;
    [SerializeField] private GameObject valinput;

    private float realval;
    private float displayval;
    [SerializeField] private float valfalloff;

    [SerializeField] private float accuracy;

    private float seed;

    void Start(){
        globalcontroller= GameObject.Find("GlobalController");
    }

    void OnEnable(){
        globalcontroller= GameObject.Find("GlobalController");
        if (globalcontroller!=null){
            actualwetness = globalcontroller.GetComponent<HWeatherControl>().weather.wetness;
            actualtemperature = globalcontroller.GetComponent<HWeatherControl>().weather.temperature;
        }
        realval=Random.Range(4,10f);
        displayval=realval;
        seed=Random.Range(0,100);
    }

    void Update(){
        displayval*=valfalloff;
        valueslider.GetComponent<Slider>().value = displayval/10;
        if (valinput.GetComponent<TMP_InputField>().text!="" && tempinput.GetComponent<TMP_InputField>().text!=""){
            float maxval = Mathf.Clamp(Mathf.Max(float.Parse(valinput.GetComponent<TMP_InputField>().text),realval),1,100);
            float minval = Mathf.Clamp(Mathf.Min(float.Parse(valinput.GetComponent<TMP_InputField>().text),realval),1,100);

            float maxtemp = Mathf.Clamp(Mathf.Max(float.Parse(tempinput.GetComponent<TMP_InputField>().text),actualtemperature),1,100);
            float mintemp = Mathf.Clamp(Mathf.Min(float.Parse(tempinput.GetComponent<TMP_InputField>().text),actualtemperature),1,100);
            accuracy=((minval/maxval) + (mintemp/maxtemp))/2f;
            display.GetComponent<TextMeshProUGUI>().SetText(string.Format("{0}%",Mathf.Lerp(seed,actualwetness,accuracy).ToString("F2")));
        }
    }

}
