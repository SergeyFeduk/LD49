using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [Range(0f,.99f)][SerializeField] private float intencity;
    [SerializeField] private Vector2 heights;
    [SerializeField] private Vector2 speedvary;
    [SerializeField] private List<GameObject> clouds;
    public bool dogenerate;

    void Update(){
        if (Random.Range(0,1-intencity)<0.01f && dogenerate){
            GameObject cloud = Instantiate(clouds[Random.Range(0,clouds.Count)],new Vector2(-10,Random.Range(heights.x,heights.y)), Quaternion.identity);
            cloud.GetComponent<CloudAI>().speedvary=speedvary;
        }
    }
}
