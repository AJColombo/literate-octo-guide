using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	
	public bool redLocked = true;
	public bool greenLocked = true;
	public bool isOpen = false;
	public bool isVerticle;
	private float closedX;
	private float closedY;
	public GameObject player;
	public WhichDoor DoorColor;
	public enum WhichDoor {
		Red = 0,
		Green = 1
	}
	
    // Start is called before the first frame update
    void Start()
    {
        redLocked = true;
		greenLocked = true;
		closedX = transform.position.x;
	    closedY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		if (redLocked == false) {
			//Destroy(gameObject);
			//if door is closed and player is in proximity open the door
			if (player.CompareTag("Player")) {
				if (DoorColor == WhichDoor.Red && isOpen == false && (Vector3.Distance(new Vector3(closedX, closedY, 0f), player.transform.position) < 1.25f)) {
					Debug.Log("TET");
					isOpen = true;
					if(isVerticle == true) {
						transform.position = new Vector3(closedX, closedY + 2.5f, 0f);
					} else {
						transform.position = new Vector3(closedX - 1.8f, closedY, 0f);
					}
				}
			}
        }
		if (greenLocked == false) {
			//Destroy(gameObject);
			//if door is closed and player is in proximity open the door
			if (player.CompareTag("Player")) {
				if (DoorColor == WhichDoor.Green && isOpen == false && (Vector3.Distance(new Vector3(closedX, closedY, 0f), player.transform.position) < 1.25f)) {
					Debug.Log("TET");
					isOpen = true;
					if(isVerticle == true) {
						transform.position = new Vector3(closedX, closedY + 2.5f, 0f);
					} else {
						transform.position = new Vector3(closedX - 1.8f, closedY, 0f);
					}
				}
			}
        }
    }
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			MainMovement MoveScriptVar = collision.gameObject.GetComponent<MainMovement>();
			if (MoveScriptVar.getRedDoorAccess() == true) {
				redLocked = false;
			}
			if (MoveScriptVar.getGreenDoorAccess() == true) {
				greenLocked = false;
			}
		}
	}
}
