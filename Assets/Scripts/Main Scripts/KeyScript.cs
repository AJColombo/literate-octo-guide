using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
	public KeyAccess ThisCardsAccess; 
	public enum KeyAccess {
		FirstRed = 0,
		SecondGreen = 1
	}
	
	
    private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
			MainMovement MoveScriptVar = collision.gameObject.GetComponent<MainMovement>();
			if (ThisCardsAccess == KeyAccess.FirstRed) {
				MoveScriptVar.setRedDoorToTrue();
			} else if (ThisCardsAccess == KeyAccess.SecondGreen) {
				Debug.Log("ADD GREEN DOOR");
			}
		}
	}
	
}