	using UnityEngine;
	using System.Collections;

	public class GameOver : MonoBehaviour {

	Button[][] buttons;
	
	int i = 0;
	int j = 0;
		
	void Start() {

		buttons = new Button[3][];
		buttons [0] = GetComponentsInChildren<RestartLevelButton> ();
		buttons [1] = GetComponentsInChildren<ReturnTOHangar> ();
		buttons [2] = GetComponentsInChildren<MainMenuButton> ();
		foreach (Button[] b in buttons) {
			foreach (Button bs in b) {
				bs.menuRoot = transform;
			}
		}
		
		buttons [0] [0].Entered ();

		if (GameMaster.scores [GameMaster.currentLevel] < GameMaster.currentScore) {
			GameMaster.scores [GameMaster.currentLevel] = GameMaster.currentScore;
		}


	}
	
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {			
			buttons [i] [j].Exited ();
			i = (i - 1 + buttons.Length) % buttons.Length;
			j = 0;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {			
			buttons [i] [j].Exited ();
			i = (i + 1) % buttons.Length;
			j = 0;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {			
			buttons [i] [j].Exited ();
			j = (j + 1) % buttons [i].Length;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {			
			buttons [i] [j].Exited ();
			j = (j - 1 + buttons [i].Length) % buttons [i].Length;
			buttons [i] [j].Entered ();
		} else if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Return)) {
			buttons[i][j].Clicked();
		}	
	}
		// Display game over message
		/*void OnGUI() {
			
			// Show player score in white on the top left of the screen
			GUI.color = Color.white;   
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.skin.label.fontSize = 40;
			GUI.skin.label.fontStyle = FontStyle.Bold;
			GUI.Label(new Rect(0,Screen.height/ 4f,Screen.width,70), "Game over");
			
			//string message = "";
			
			// Check player's lives left...if more than 0,
			// then player won, otherwise the game was lost   
			// Generate appropriate final message

				// The lost message will be shown in red
				
				GUI.color = Color.white;   
				GUI.skin.label.alignment = TextAnchor.MiddleCenter;
				GUI.skin.label.fontSize = 40;
				GUI.skin.label.fontStyle = FontStyle.Bold;
				GUI.Label(new Rect(0,Screen.height/ 4f+120f,Screen.width,70), "You Lost!");
				
				
				
				
				

			//GUI.Label(new Rect(0,Screen.height/ 4f + 80f,Screen.width,70), message);
			
			// Last line will be shown in white
			GUI.color = Color.white;
			
			
			GUI.Label(new Rect(0,Screen.height/ 4f + 240f,Screen.width,70), "Press n key to continue...");
		}*/
	}
