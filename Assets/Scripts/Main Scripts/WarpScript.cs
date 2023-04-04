using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpScript : MonoBehaviour
{
	public string NameOfLevel;
	
	
    //private string[] LevelsStringNames = {"MainMenu", "MainLevel_4_2 1", "storageRoomSideScroll", "Credits"};
	//public Levels SelectedLevel; 
	//private string Final = LevelsStringNames[0];
	// void Start() {
		// //SceneLoader = SelectedLevel;
	// }
	
	
	
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("Player")) {
		SceneManager.LoadScene(NameOfLevel);
			Debug.Log("PLAYER PASSED");
		}
	}
}
