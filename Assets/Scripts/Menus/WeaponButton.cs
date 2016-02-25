using UnityEngine;
using System.Collections;

public class WeaponButton : Button {

	public WeaponType weapon;
	public string description;
	public Sprite emptyLogo;
	public int unlockLevel;
	public int[] levelsToBeat;



	void Start() {
		tip = "Press ' , '  ' . ' or ' / ' to equip";
	}

	public override void Entered() {
		ShipMenu menu = menuRoot.GetComponent<ShipMenu> ();
		menu.selectionDescription = description;
		menu.selectionName = weapon.weaponName;
		menu.tipBox.text = tip;
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

	public override void Clicked() {
		/*ShipMenu menu = menuRoot.GetComponent<ShipMenu> ();
		menu.AddRemoveWeapon (weapon); */
	}

	public void Clicked(int i) {
		menuRoot.GetComponent<ShipMenu> ().AddRemoveWeapon (weapon, i);
	}

	public override void Exited() {




	}
}
