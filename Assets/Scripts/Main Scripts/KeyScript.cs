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
				Debug.Log("DESTORY Red KEy");
				Destroy(gameObject);
			} if (ThisCardsAccess == KeyAccess.SecondGreen) {
				MoveScriptVar.setGreenDoorToTrue();
				Debug.Log("DESTORY Green KEy");
				Destroy(gameObject);
			}
		}
	}
	
}

