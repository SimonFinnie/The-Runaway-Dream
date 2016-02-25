using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	public AudioClip sound;
	public float volume;

	// Use this for initialization
	void Start () {
		GameMaster.level.PlaySound (sound, volume);
	
	}
	

}
