using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour {

	Button[][] buttons;
	
	int i = 0;
	int j = 0;
	
	void Start() {
		buttons = new Button[1][];
		buttons [0] = GetComponentsInChildren<BackButton> ();
		//buttons [1] = GetComponentsInChildren<LoadGame> ();
		foreach (Button[] b in buttons) {
			foreach (Button bs in b) {
				bs.menuRoot = transform;
			}
		}
		
		buttons [0] [0].Entered ();
		
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
}
