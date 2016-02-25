using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadGame : Button {
	
	public Text label;
	public int unSized;
	public int bigSize;
	public Color noLoadColour = Color.gray;

	void Start() {
		if (!GameMaster.CanLoad ()) {
			label.color = noLoadColour;
			gameObject.SetActive(false);
		}
	}
	
	public override void Entered() {
		label.fontSize = bigSize;
	}
	
	public override void Exited() {
		label.fontSize = unSized;
	}
	
	public override void Clicked (){
		GameMaster.Load ();
		Application.LoadLevel ("ShipMenu");
		
	}
}
