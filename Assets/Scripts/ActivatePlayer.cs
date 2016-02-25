using UnityEngine;
using System.Collections;

public class ActivatePlayer : MonoBehaviour {

	void Start ()
	{
		GameMaster.level.player.gameObject.SetActive (true);
		GameMaster.level.Awake ();
		GameMaster.level.HUD.SetActive (true);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
