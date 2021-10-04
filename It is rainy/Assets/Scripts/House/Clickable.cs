using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [System.Serializable]
    enum Type{
        Null,
        Computer,
        Switch,
        Message,
        Bed
    }
    [SerializeField] private Type type;
    [SerializeField] private GameObject linkable;
    [SerializeField] private GameObject blackout;
    [SerializeField] private AudioSource source;

    private GameObject gamecontroller;

    public void Buttonlink(){
        if (linkable.activeSelf){
            linkable.SetActive(false);
        }else{
            linkable.SetActive(true);
        }
    }

    void Start(){
        gamecontroller=GameObject.Find("GlobalController");
    }

    void OnMouseDown(){
        blackout=HWeatherControl.FindInActiveObjectByName("SleepPanel");
        switch (type){
            case Type.Computer:
                if (blackout!=null){blackout.SetActive(false);}
                linkable.SetActive(true);
                if (gamecontroller!=null)gamecontroller.GetComponent<TimeController>().secpermin=0.5f;
                if (source!=null){source.Play();}
                break;
            case Type.Switch:
                if (blackout!=null){blackout.SetActive(false);}
                if (linkable.activeSelf){
                    linkable.SetActive(false);
                    if (gamecontroller!=null)gamecontroller.GetComponent<TimeController>().secpermin=0.5f;
                }else{
                    linkable.SetActive(true);
                    if (gamecontroller!=null)gamecontroller.GetComponent<TimeController>().secpermin=0.5f;
                }
                source.Play();
                break;
            case Type.Message:
                if (blackout!=null){blackout.SetActive(false);}
                linkable.SetActive(true);
                gameObject.SetActive(false);
                if (gamecontroller!=null)gamecontroller.GetComponent<TimeController>().secpermin=0.5f;
                break;
            case Type.Bed:
                if (gamecontroller.GetComponent<TimeController>().secpermin==0.5f){
                    gamecontroller.GetComponent<TimeController>().secpermin=0.05f;
                }else{
                    gamecontroller.GetComponent<TimeController>().secpermin=0.5f;
                }
                if (blackout.activeSelf){
                    blackout.SetActive(false);
                }else{
                    blackout.SetActive(true);
                }
                break;
        }
    }
}
