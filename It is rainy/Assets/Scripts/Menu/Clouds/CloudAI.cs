using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAI : MonoBehaviour
{
    private float speed;
    public Vector2 speedvary;
    void Start(){
        speed=Random.Range(speedvary.x,speedvary.y);
    }
    void FixedUpdate(){
        transform.position = transform.position + new Vector3(speed,0,0);
        if (transform.position.x>10){Destroy(gameObject);}
    }
}
