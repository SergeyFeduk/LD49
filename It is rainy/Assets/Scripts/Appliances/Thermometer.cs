using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Thermometer : MonoBehaviour
{
    [SerializeField] private GameObject display;
    [SerializeField] private float fallamount;
    [SerializeField] private GameObject sliderleft;
    [SerializeField] private GameObject sliderright;
    [Header("Needers")]
    [SerializeField] private GameObject neederleft;
    [SerializeField] private GameObject neederright;
    
    [SerializeField] private float accuracy;
    public float actualvalue;
    private Vector2 neededvalues;

    private bool leftenabled = false;
    private bool rightenabled = false;

    private GameObject globalcontroller;

    public void EnableLeftSlider(){
        leftenabled=true;
    }
    public void DisableLeftSlider(){
        leftenabled=false;
    }
    public void EnableRightSlider(){
        rightenabled=true;
    }
    public void DisableRightSlider(){
        rightenabled=false;
    }

    void Start(){
        globalcontroller= GameObject.Find("GlobalController");
    }

    void OnEnable(){
        globalcontroller= GameObject.Find("GlobalController");
        if (globalcontroller!=null){actualvalue = globalcontroller.GetComponent<HWeatherControl>().weather.temperature;}
        Open();
    }

    public void Open(){
        neededvalues.x = Random.Range(-.5f,.5f);
        neededvalues.y = Random.Range(-.5f,.5f);
        neederleft.GetComponent<RectTransform>().localPosition = new Vector2(0,neededvalues.x*400f);
        neederright.GetComponent<RectTransform>().localPosition = new Vector2(0,neededvalues.y*400f);
        
    }

    void Update(){
        float leftval = sliderleft.GetComponent<Slider>().value;
        float rightval = sliderright.GetComponent<Slider>().value;
        if (leftenabled) {sliderleft.GetComponent<Slider>().value = leftval * fallamount;}
        if (rightenabled){sliderright.GetComponent<Slider>().value = rightval * fallamount;}
        accuracy = Vector2.Distance(new Vector2(leftval,rightval), new Vector2(neededvalues.x+0.5f,neededvalues.y+0.5f));
        display.GetComponent<TextMeshProUGUI>().SetText(string.Format("{0}'C",(actualvalue*(0.99f-accuracy)+0.5f).ToString("F1")));
    }
}
