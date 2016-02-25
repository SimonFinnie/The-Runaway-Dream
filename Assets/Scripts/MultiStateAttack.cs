using UnityEngine;
using System.Collections;

public class MultiStateAttack : MonoBehaviour {

	public int state;
	public float coolDownTime;
	public float coolDownLeft;
	public float activeTime;
	public Attack weapon;

	void Awake() {
		if (weapon == null) {
			weapon = GetComponent<Attack> ();
			if (weapon == null) {
				Destroy (this);
			}
		}
	}

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
		coolDownLeft -= Time.deltaTime;
		if (coolDownLeft <= 0) {
			if (weapon.enabled) {
				weapon.enabled = false;
				coolDownLeft += coolDownTime;
			} else {
				weapon.enabled = true;
				weapon.timeSinceLastShot = 0;
				weapon.Shoot ();
				coolDownLeft += activeTime;
			}
		}
	
	}
}
