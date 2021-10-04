using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Weather
{
    [System.Serializable]
    public enum Type{
        Clear,
        Precipitation,
        Cloudy
    }
    
    [System.Serializable]
    public enum PrecType{
        Rain,
        Snow,
        Hail,
        Storm //aka thunder
    }

    public Type type;
    public PrecType precipationtype;
    public ParticleSystem particles;

    public Information prevdayinfo;
    public Information todayinfo;

    public float windspeed; // may be positive or negative
    public float intencity;
    public float temperature;
    public float pressure;
    public float wetness;
    public float precipationperminute;
    public float precipitationamount;

    public void UpdateADay(){
        prevdayinfo=todayinfo;
        //select next type
        float rand = 0;
        switch (type){
            case Type.Clear:
                rand = Random.Range(0,4);
                if (rand<=2) {type=Type.Clear;}
                if (rand==3) {type=Type.Cloudy;}
                if (rand==4) {type=Type.Precipitation;}
                break;
            case Type.Cloudy:
                rand = Random.Range(0,5);
                if (rand<=2) {type=Type.Cloudy;}
                if (rand==3) {type=Type.Clear;}
                if (rand>=4) {type=Type.Precipitation;}
                break;
            case Type.Precipitation:
                rand = Random.Range(0,5);
                if (rand==0) {type=Type.Cloudy;}
                if (rand==1) {type=Type.Clear;}
                if (rand>=2) {type=Type.Precipitation;}
                break;
        }
        //if it's precipitation
        if (type == Type.Precipitation){
            rand = Random.Range(0,4);
            if (rand<=2){precipationtype=PrecType.Rain;}
            if (rand==3){precipationtype=PrecType.Hail;}
            if (rand==4){precipationtype=PrecType.Storm;}
        }
        //depending on previous day weather select todays
        float valrand = 0;
        //temperature
        if (prevdayinfo.temperature<0){
            //it was cold, should get worser
            if ((prevdayinfo.temperature>-25f)){
                valrand = Random.Range(0,4);
                if (valrand<=2){temperature=prevdayinfo.temperature-2f;} //get colder by 2
                if (valrand==3){temperature=prevdayinfo.temperature+Random.Range(3,8);} //increase
                //in other case do not change
            }else{
                temperature=prevdayinfo.temperature+Random.Range(2,4); // increase, too cold
            }
        }else{
            temperature=prevdayinfo.temperature+Random.Range(-5,4);
        }

        //windspeed
        if (prevdayinfo.windspeed>45f){
            windspeed-=3f;
        }else{
            windspeed+=Random.Range(-5,4);
        }
        windspeed=Mathf.Clamp(windspeed,0,50);

        //pressure
        if (type==Type.Clear){
            pressure=760+Random.Range(-10,10);
        }
        if (type==Type.Cloudy){
            pressure=770+Random.Range(-5,10);
        }
        if (type==Type.Precipitation){
            switch (precipationtype){
                case PrecType.Rain:
                    pressure=740+Random.Range(-5,20);
                    break;
                case PrecType.Snow:
                    pressure=760+Random.Range(-5,10);
                    break;
                case PrecType.Hail:
                    pressure=760+Random.Range(-5,10);
                    break;
                case PrecType.Storm:
                    pressure=770+Random.Range(-15,5);
                    break;
            }
        }
        //wetness
        wetness=Mathf.Clamp(prevdayinfo.wetness+Random.Range(-40,40),0,100);
        //precipitationamount
        if (type==Type.Precipitation){
            switch(precipationtype){
                case PrecType.Rain:
                    precipationperminute=Random.Range(0.001f,0.003f);
                    break;
                case PrecType.Hail:
                    precipationperminute=Random.Range(0.002f,0.004f);
                    break;
                case PrecType.Snow:
                    precipationperminute=Random.Range(0.001f,0.003f);
                    break;
                case PrecType.Storm:
                    precipationperminute=Random.Range(0.004f,0.006f);
                    break;
            }
        }
        precipitationamount=precipationperminute*24*60;
        

        todayinfo.pressure=pressure;
        todayinfo.windspeed=windspeed;
        todayinfo.wetness=wetness;
        todayinfo.temperature=temperature;
        todayinfo.precipitationamount=precipitationamount;
        GameObject.Find("GlobalController").GetComponent<HWeatherControl>().realinfo = todayinfo;
        GameObject.Find("OutsideBg").GetComponent<OutsideColor>().ChangeColor();
        GameObject.Find("GlobalController").GetComponent<HWeatherControl>().Compare();
        WeatherEffectsUpdate();
    }

    public void WeatherEffectsUpdate(){
        //global controller vfx
        if (type==Type.Precipitation || type == Type.Cloudy){
            GameObject.Find("GlobalController").GetComponent<CloudGenerator>().dogenerate=true;
        }else{
            GameObject.Find("GlobalController").GetComponent<CloudGenerator>().dogenerate=false;
        }
        if (type==Type.Precipitation){
            HWeatherControl.FindInActiveObjectByName("RainHouse").SetActive(false);
            HWeatherControl.FindInActiveObjectByName("SnowHouse").SetActive(false);
            HWeatherControl.FindInActiveObjectByName("RainOutside").SetActive(false);
            HWeatherControl.FindInActiveObjectByName("SnowOutside").SetActive(false);
            if (SceneManager.GetActiveScene().name=="House"){
                switch(precipationtype){
                    case PrecType.Rain:
                        HWeatherControl.FindInActiveObjectByName("RainHouse").SetActive(true);
                        break;
                    case PrecType.Snow:
                        HWeatherControl.FindInActiveObjectByName("SnowHouse").SetActive(true);
                        break;
                    case PrecType.Hail:
                        HWeatherControl.FindInActiveObjectByName("RainHouse").SetActive(true);
                        break;
                    case PrecType.Storm:
                        HWeatherControl.FindInActiveObjectByName("RainHouse").SetActive(true);
                        break;
                }
            }else{
                switch(precipationtype){
                    case PrecType.Rain:
                        HWeatherControl.FindInActiveObjectByName("RainOutside").SetActive(true);
                        break;
                    case PrecType.Snow:
                        HWeatherControl.FindInActiveObjectByName("SnowOutside").SetActive(true);
                        break;
                    case PrecType.Hail:
                        HWeatherControl.FindInActiveObjectByName("RainOutside").SetActive(true);
                        break;
                    case PrecType.Storm:
                        HWeatherControl.FindInActiveObjectByName("RainOutside").SetActive(true);
                        break;
                }
            }
            
        }else{
            HWeatherControl.FindInActiveObjectByName("RainHouse").SetActive(false);
            HWeatherControl.FindInActiveObjectByName("SnowHouse").SetActive(false);
            HWeatherControl.FindInActiveObjectByName("RainOutside").SetActive(false);
            HWeatherControl.FindInActiveObjectByName("SnowOutside").SetActive(false);
        }
    }

    

    //use ONLY for first time
    public void Randomize(){
        // set random type
        switch(Random.Range(0,2)){
            case 0:
                type=Type.Clear;
                windspeed = Random.Range(-5f,5f);
                intencity = 0;
                temperature = Random.Range(-10f,30f);
                pressure = Random.Range(740,770);
                wetness = Random.Range(20,40);
                break;
            case 1:
                type=Type.Cloudy;
                windspeed = Random.Range(-15f,15f);
                intencity = Random.Range(0f,1f);
                temperature = Random.Range(-10f,20f);
                pressure = Random.Range(745,780);
                wetness = Random.Range(50,90);
                break;
            case 2:
                type=Type.Precipitation;
                switch(Random.Range(0,3)){
                    case 0:
                        precipationtype=PrecType.Hail;
                        windspeed = Random.Range(-25f,25f);
                        intencity = Random.Range(0f,1f);
                        temperature = Random.Range(-25f,10f);
                        pressure = Random.Range(720,750);
                        wetness = Random.Range(10,60);
                        break;
                    case 1:
                        precipationtype=PrecType.Rain;
                        windspeed = Random.Range(-25f,25f);
                        intencity = Random.Range(0f,1f);
                        temperature = Random.Range(-5f,20f);
                        pressure = Random.Range(720,760);
                        wetness = Random.Range(80,100);
                        break;
                    case 2:
                        precipationtype=PrecType.Snow;
                        windspeed = Random.Range(-25f,25f);
                        intencity = Random.Range(0f,1f);
                        temperature = Random.Range(-45f,-5f);
                        pressure = Random.Range(720,760);
                        wetness = Random.Range(80,100);
                        break;
                    case 3:
                        precipationtype=PrecType.Storm;
                        windspeed = Random.Range(-50f,50f);
                        intencity = Random.Range(0.5f,1f);
                        temperature = Random.Range(-30f,5f);
                        pressure = Random.Range(760,775);
                        wetness = Random.Range(95,100);
                        break;
                }
                break;
        }
    }
}
