using UnityEngine;
using System.Collections;

public class ShipButton : Button {

	public PlayerShip ship;
	public string description;
	public int unlockLevel;
	public int[] levelsToBeat;
	
 
	void Awake(){
		tip = "Press ENTER to select";
	}

	public override void Clicked() {
		menuRoot.GetComponent<ShipMenu> ().SetShip (this.ship);

	}

	public bool IsUnlocked() {
		if (unlockLevel > GameMaster.unlockedLevel) {
			return false;
		}
		for (int i = 0; i < levelsToBeat.Length; i++) {
			if (GameMaster.scores[i] < GameMaster.scoresToBeat[i] ){
				return false;
			}
		}

		return true;
	}

	public override void Entered() {
		
		ShipMenu menu = menuRoot.GetComponent<ShipMenu> ();
		menu.selectionName = ship.shipName;
		menu.selectionDescription = description;
		menu.tipBox.text = tip;
	}

	public override void Exited() {
	}
	

}
