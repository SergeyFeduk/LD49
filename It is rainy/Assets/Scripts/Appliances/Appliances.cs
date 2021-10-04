using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appliances : MonoBehaviour
{

    [SerializeField] private GameObject thermometerwindow;
    [SerializeField] private GameObject hydrometerwindow;
    [SerializeField] private GameObject barometerwindow;
    [SerializeField] private GameObject gaugewindow;

    public void Close(){
        thermometerwindow.SetActive(false);
        hydrometerwindow.SetActive(false);
        barometerwindow.SetActive(false);
        gaugewindow.SetActive(false);
    }

    public void OpenThermometer(){
        thermometerwindow.SetActive(true);
    }

    public void OpenHydrometer(){
        hydrometerwindow.SetActive(true);
    }

    public void OpenBarometer(){
        barometerwindow.SetActive(true);
    }
}
