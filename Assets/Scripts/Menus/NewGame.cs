using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewGame : Button {

	public Text label;
	public int unSized;
	public int bigSize;
	
	public override void Entered() {
		label.fontSize = bigSize;
	}
	
	public override void Exited() {
		label.fontSize = unSized;
	}
	
	public override void Clicked (){
		GameMaster.currentLevel = 0;
		GameMaster.unlockedLevel = 0;
		for (int i = 0; i < GameMaster.scores.Length; i++) {
			GameMaster.scores[i] = 0;
		}
		Application.LoadLevel ("Tutorial");
		
	}
}
