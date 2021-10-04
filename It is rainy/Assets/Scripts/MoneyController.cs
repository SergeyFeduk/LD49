using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private GameObject moneytext;
    [SerializeField] private GameObject gameover;
    private int warning;

    void OnEnable(){
        gameover=HWeatherControl.FindInActiveObjectByName("GameOver");
        SetMoneyText();
        GiveMoney(0);
    }

    public void SetMoneyText(){
        moneytext=GameObject.Find("Balance");
    }

    public void Warn(){
        warning++;
        if (warning>=2){
            GameOver();
        }
    }

    public void GiveMoney(int income){
        money+=income;
        moneytext.GetComponent<TextMeshProUGUI>().SetText(string.Format("Balance: {0}R",money));
        if (money<=0){
            GameOver();
        }
    }

    void GameOver(){
        gameover=HWeatherControl.FindInActiveObjectByName("GameOver");
        gameover.SetActive(true);
    }
}
