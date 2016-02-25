using UnityEngine;
using System.Collections;

public class WeaponDisplay : MonoBehaviour {

	public WeaponType weapon;
	bool done;
	Transform chargeBar;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().sprite = weapon.icon;
		Transform c = transform.GetChild (0);
		if (!weapon.passive) {
			chargeBar = c;
		} else {
			c.gameObject.SetActive (false);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		if (!weapon.passive) {
			chargeBar.transform.localScale = new Vector3(weapon.getCharge(), 1f, 1f);
				if (!done && weapon.getCharge() == 1f) {
				done = true;
				chargeBar.GetComponent<SpriteRenderer>().color = Color.green;
			} else if (done && weapon.getCharge() < 1f) {
				done = false;
				chargeBar.GetComponent<SpriteRenderer>().color = Color.blue;
			}
		}
	
	}
}
