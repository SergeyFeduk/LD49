using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HWindowScript : MonoBehaviour
{
    [System.Serializable]
    public enum Window{
        Null,
        Computer,
        Board
    }
    [SerializeField] private GameObject computerwindow;
    [SerializeField] private GameObject computermenu;
    [SerializeField] private GameObject computersend;
    [SerializeField] private GameObject computerboard;
    [SerializeField] private GameObject computermaual;

    private Window selectedwindow = Window.Null;
    
    public void turnoff(){
        selectWindow(Window.Null);
        computermenu.SetActive(true);
        computersend.SetActive(false);
        computerboard.SetActive(false);
        computermaual.SetActive(false);
    }

    public void selectWindow(Window window){
        selectedwindow=window;
        switch (selectedwindow){
            case Window.Board:
                computerwindow.SetActive(false);
                break;
            case Window.Computer:
                computerwindow.SetActive(true);
                break;
            case Window.Null:
                computerwindow.SetActive(false);
                break;
        }
    }


}
