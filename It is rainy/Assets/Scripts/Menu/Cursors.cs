using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursors : MonoBehaviour
{
    public Texture2D mouseCursor;
    
    Vector2 hotSpot = new Vector2(0,0);
    CursorMode cursorMode = CursorMode.Auto;
    private Cursors me;
 
    void Awake(){
        if (me == null) {
            me = this;
            DontDestroyOnLoad(gameObject);
        }else if(me != this){
            Destroy(gameObject);
            return;
        }
    }
    
    private void OnEnable(){
        hotSpot.x = mouseCursor.width/2;
        hotSpot.y = mouseCursor.height/2;
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }
}
