using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour
{
	
	public bool doorLocked = true;
	
	
    // Start is called before the first frame update
    void Start()
    {
        doorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
		//if (doorLocked == false) {
		//	Destroy(gameObject);
        //}
    }
	
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			MainMovement MoveScriptVar = collision.gameObject.GetComponent<MainMovement>();
			if (MoveScriptVar.getRedDoorAccess() == true) {
				Debug.Log(collision + "DEBUG2");
				doorLocked = false;
			}
			// Debug.Log(collision);
		}
	}
	
}
