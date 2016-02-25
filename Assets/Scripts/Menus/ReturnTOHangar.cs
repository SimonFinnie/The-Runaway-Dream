using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReturnTOHangar : Button {

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
		Application.LoadLevel ("ShipMenu");
		
	}
}
