using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerMenu : MonoBehaviour{
    
    [SerializeField] private GameObject computermenu;
    [SerializeField] private GameObject computersend;
    [SerializeField] private GameObject computerboard;

    [SerializeField] private GameObject tempinp;
    [SerializeField] private GameObject windinp;
    [SerializeField] private GameObject pressinp;
    [SerializeField] private GameObject wetninp;
    [SerializeField] private GameObject precipitationsinp;
    [SerializeField] private Information information;
    private GameObject controller;
    void Start(){
        controller=GameObject.Find("GlobalController");
    }

    public void SendDataMenu(){
        computermenu.SetActive(false);
        computersend.SetActive(true);
    }

    public void BoardMenu(){
        computermenu.SetActive(false);
        computerboard.SetActive(true);
    }

    public void SendData(){
        if (tempinp.GetComponent<TMP_InputField>().text!="" /*&& windinp.GetComponent<TMP_InputField>().text!=""*/ && pressinp.GetComponent<TMP_InputField>().text!=""
        && wetninp.GetComponent<TMP_InputField>().text!="" && precipitationsinp.GetComponent<TMP_InputField>().text!=""){
            //pass data
            information.temperature =         float.Parse(tempinp.GetComponent<TMP_InputField>().text);
            //information.windspeed =           float.Parse(windinp.GetComponent<TMP_InputField>().text);
            information.pressure =            float.Parse(pressinp.GetComponent<TMP_InputField>().text);
            information.wetness =             float.Parse(wetninp.GetComponent<TMP_InputField>().text);
            information.precipitationamount = float.Parse(precipitationsinp.GetComponent<TMP_InputField>().text);

            controller.GetComponent<HWeatherControl>().info = information;
            computermenu.SetActive(true);
            computersend.SetActive(false);
        }else{

        }
    }


}
