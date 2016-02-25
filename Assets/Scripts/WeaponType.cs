using UnityEngine;
using System.Collections;

public class WeaponType : MonoBehaviour {


	public Sprite icon;
	public string weaponName;
	public bool passive;
	public bool centered;

	// Use this for initialization
	void Start () {
	
	}

	public virtual void Activate(){
		Attack a = GetComponent<Attack> ();
		if (a != null ) {
			a.Shoot();
		}
	}

	public virtual float getCharge() {
		Attack a = GetComponent<Attack> ();
		if (a != null ) {
			return a.timeSinceLastShot / a.fireCooldownTime;
		}
		return 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
