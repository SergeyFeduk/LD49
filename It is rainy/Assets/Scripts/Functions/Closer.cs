using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closer : MonoBehaviour
{
    public SceneChanger.Side type;
    public bool close;
    
    void Update(){
        if (close){
            switch (type){
                case SceneChanger.Side.Left:
                    transform.localScale = new Vector3(Ease.EaseInOutQuad(transform.localScale.x,30*1.25f,0.3f),10,1);
                    break;
                case SceneChanger.Side.Right:
                    transform.localScale = new Vector3(Ease.EaseInOutQuad(transform.localScale.x,30*1.25f,0.3f),10,1);
                    break;
                case SceneChanger.Side.Top:
                    transform.localScale = new Vector3(20,Ease.EaseInOutQuad(transform.localScale.y,20*1.25f,0.3f),1);
                    break;
                case SceneChanger.Side.Down:
                    transform.localScale = new Vector3(20,Ease.EaseInOutQuad(transform.localScale.y,20*1.25f,0.3f),1);
                    break;
            }
            
        }else{
            switch (type){
                case SceneChanger.Side.Left:
                    transform.localScale = new Vector3(Ease.EaseInOutQuad(transform.localScale.x,0,0.2f),10,1);
                    break;
                case SceneChanger.Side.Right:
                    transform.localScale = new Vector3(Ease.EaseInOutQuad(transform.localScale.x,0,0.2f),10,1);
                    break;
                case SceneChanger.Side.Top:
                    transform.localScale = new Vector3(20,Ease.EaseInOutQuad(transform.localScale.y,0,0.2f),1);
                    break;
                case SceneChanger.Side.Down:
                    transform.localScale = new Vector3(20,Ease.EaseInOutQuad(transform.localScale.y,0,0.2f),1);
                    break;
            }
            if (transform.localScale.x<=0.01f || transform.localScale.y<=0.01f){Destroy(gameObject);}
        }
    }
}
