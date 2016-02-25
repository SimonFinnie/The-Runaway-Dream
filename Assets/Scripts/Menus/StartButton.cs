using UnityEngine;
using System.Collections;

public class StartButton : Button {


	public Sprite hilighted;
	public Sprite nonhilighted;

	public override void Entered() {
		GetComponent<SpriteRenderer> ().sprite = hilighted;
			

	}

	public override void Exited() {
		GetComponent<SpriteRenderer> ().sprite = nonhilighted;
	}

	public override void Clicked (){
			GameMaster.player.transform.parent = null;
            Application.LoadLevel(GameMaster.levels[GameMaster.currentLevel]);

	}
}
