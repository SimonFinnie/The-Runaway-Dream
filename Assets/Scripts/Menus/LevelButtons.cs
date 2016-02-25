using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class LevelButtons : Button {

	public string LevelName;
	public int levelNumber;
	public Text label;
	public string notBeaten;
	public Color noLoadColour = new Color(0,0,0,0);
	
	void Start(){
		tip = "Press ENTER to begin level";
		if (GameMaster.unlockedLevel < levelNumber - 1) {
			label.color = noLoadColour;
		}
	}
	
	public override void Clicked() {
		GameMaster.currentLevel = levelNumber;
		GameMaster.player.transform.parent = null;
		Application.LoadLevel(GameMaster.levels[GameMaster.currentLevel]);

	}
	
	public override void Entered() {
		ShipMenu menu = menuRoot.GetComponent<ShipMenu> ();
		if (levelNumber == 0) {
			menu.selectionDescription = "Learn to play!";
		} else {
			menu.selectionDescription = "Your best score for this level is " +  GameMaster.scores[levelNumber].ToString() + "." + notBeaten;
		}
		menu.selectionName = LevelName;
		menu.tipBox.text = tip;



	}
	
	public override void Exited() {
	}
	
	
}