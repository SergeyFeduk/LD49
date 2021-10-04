using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [System.Serializable]
    public enum Side{
        Left,
        Right,
        Top,
        Down
    }

    public Side side;
    [SerializeField] private GameObject slider;
    private Camera cam;

    void Awake(){
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        StartCoroutine(ChangeScene("",0,Side.Left,false,false));
    }
    
    

    public IEnumerator ChangeScene(string scenename,float time, Side side, bool close,bool doloadscene){
        GameObject slid;
        /*switch(side){
            case Side.Left:
                slid = Instantiate(slider,new Vector3(cam.ScreenToWorldPoint(new Vector3(-(cam.orthographicSize*cam.aspect*1.25f),0,0)).x,0,10), Quaternion.identity);
                Debug.Log(-(cam.orthographicSize*cam.aspect*1.25f));
                if (!close){
                    slid.transform.localScale = new Vector3(37.5f,11,1);
                }
                slid.GetComponent<Closer>().type=side;
                slid.GetComponent<Closer>().close=close;
                break;
            case Side.Right:
                slid = Instantiate(slider,new Vector3(cam.ScreenToWorldPoint(new Vector3(cam.orthographicSize*cam.aspect*1.25f,0,10)).x,0,10), Quaternion.identity);
                Debug.Log(cam.orthographicSize*cam.aspect*1.25f);
                if (!close){
                    slid.transform.localScale = new Vector3(37.5f,11,1);
                }
                slid.GetComponent<Closer>().type=side;
                slid.GetComponent<Closer>().close=close;
                break;
            case Side.Top:
                slid = Instantiate(slider,new Vector3(0,cam.ScreenToWorldPoint(new Vector3(0,-cam.orthographicSize*1.25f,10)).y,0), Quaternion.identity);
                slid.GetComponent<Closer>().type=side;
                slid.GetComponent<Closer>().close=close;
                break;
            case Side.Down:
                slid = Instantiate(slider,new Vector3(0,cam.ScreenToWorldPoint(new Vector3(0,cam.orthographicSize*1.25f,10)).y,0), Quaternion.identity);
                slid.GetComponent<Closer>().type=side;
                slid.GetComponent<Closer>().close=close;
                break;
        }*/
        slid = Instantiate(slider,new Vector3(cam.ScreenToWorldPoint(new Vector3(-(cam.orthographicSize*cam.aspect*1.25f),0,0)).x,0,10), Quaternion.identity);
        if (!close){
            slid.transform.localScale = new Vector3(37.5f,11,1);
        }
        slid.GetComponent<Closer>().type=side;
        slid.GetComponent<Closer>().close=close;
        
        if (doloadscene){
            yield return new WaitForSeconds(time);
            SceneManager.LoadScene(scenename, LoadSceneMode.Single);
        }
    }
}
