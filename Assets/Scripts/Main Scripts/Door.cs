using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	
	public bool doorLocked = true;
	public bool isOpen = false;
	private float closedX;
	private float closedY;
	public GameObject player;
	
    // Start is called before the first frame update
    void Start()
    {
        doorLocked = true;
		closedX = transform.position.x;
	    closedY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
		if (doorLocked == false) {
			//Destroy(gameObject);
			//if door is closed and player is in proximity open the door
			if (player.CompareTag("Player")) {
				if (isOpen == false && (Vector3.Distance(new Vector3(closedX, closedY/2f, 0f), player.transform.position) < 1.25f)) {
					Debug.Log("TET");
					isOpen = true;
					transform.position = transform.position + new Vector3(0f, 3.5f, 0f);
				}
			}
        }
    }
	
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			MainMovement MoveScriptVar = collision.gameObject.GetComponent<MainMovement>();
			if (MoveScriptVar.getRedDoorAccess() == true) {
				
				doorLocked = false;
			}
		}
	}
}
