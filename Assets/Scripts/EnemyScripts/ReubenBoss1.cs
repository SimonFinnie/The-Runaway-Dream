using UnityEngine;
using System.Collections;

public class ReubenBoss1 : BaseEnemy {

	public ReubenBossRoot[] children;
	public int[] states;
	int state;
	Vector3 hpPos;

	// Use this for initialization
	public override void Start () {
		children = GetComponentsInChildren<ReubenBossRoot> ();
		HP = 0;
		foreach (ReubenBossRoot r in children) {
			HP += r.HP;
			foreach (Collider2D c in r.GetComponents<Collider2D>()) {
				c.enabled = false;
			}
		}
		MaxHP = HP;
		changeState (0);
		hpPos = healthBar.transform.position;
	
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update (); 
		HP = 0;
		foreach (ReubenBossRoot r in children) {
			if (r != null){
			HP += r.HP;
			}
		}
		if (HP > MaxHP) {
			MaxHP = HP;;
		}
		healthBar.transform.position = hpPos;
	
	}

	public void changeState(int state) {
		foreach (ReubenBossRoot r in children) {
			if (r != null) {
			this.state = state;
			r.setState(state);
			}
		}
	}

	public void advanceState(int state) {
		if (state < states.Length) {
			if (--states[state] <= 0 && this.state == state && state + 1 < states.Length) {
				changeState(state + 1);
			}
		}
	}
}
