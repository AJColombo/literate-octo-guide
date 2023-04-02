using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownToFromObject : MonoBehaviour
{

    //public MovmenentScript MoveScript; 
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
		//Debug.Log(col.gameObject.toString());
        GameObject PlayerObject = col.gameObject;
        if (PlayerObject.name == "MainPlayer") {
            PlayerObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            MainMovement MoveScriptVar = PlayerObject.GetComponent<MainMovement>();
            MoveScriptVar.SwapPlayerPerspective();
            //PlayerObject.GetComponent(Movement3_29_23).PlayerControlStyle = 1;
        }
    }
}
