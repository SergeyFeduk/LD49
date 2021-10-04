using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Information
{
    public float windspeed;
    public float temperature;
    public float pressure;
    public float wetness;
    public float precipitationamount;

    public Information(float iwindspeed, float itemperature, float ipressure,float iwetness, float iprecipitationamount){
        windspeed           = iwindspeed;
        temperature         = itemperature;
        pressure            = ipressure;
        wetness             = iwetness;
        precipitationamount = iprecipitationamount;
    }
    public float CalculateError(){
        float erwindspeed           = Mathf.Abs(windspeed);
        float ertemperature         = Mathf.Abs(temperature);
        float erpressure            = Mathf.Abs(pressure);
        float erwetness             = Mathf.Abs(wetness);
        float erprecipitationamount = Mathf.Abs(precipitationamount);
        
        float error = /*erwindspeed*0.25f*/+ertemperature*2f+erpressure*0.125f+erwetness*0.05f+erprecipitationamount;
        return error;
    }
}
