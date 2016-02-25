using UnityEngine;
using System.Collections;

public class EnemyWave : MonoBehaviour {
	
	// Variable poitning to object prefab
	public Transform alienPrefab;
	public float delay;
	public float doneTime;
	public bool started;
	public bool done;
	public bool spawnDone;
	public float parentDone = 0;
	public EnemyWave partner;
	// Use this for initialization
	void Start () {
		//move.generate (alienPrefab);      
	}

	public virtual void Update () {
		EnemyWave par = transform.parent.GetComponent<EnemyWave>();
		if (par != null) {
			if (par.done) {
				parentDone = par.doneTime;
			} else {
				parentDone = LevelMaster.timeScinceLevelStart;
			}
		} else {
			parentDone = 0;
		}


		if (LevelMaster.timeScinceLevelStart  - parentDone > delay && !started) {
			begin ();
		}
		if (spawnDone) {
			if (GetComponentInChildren<BaseEnemy>() == null && (partner == null || partner.done) && !done && GetComponent<SplashMessage>() == null){
				done = true;
				doneTime = LevelMaster.timeScinceLevelStart;
			}
		}
	}

	public virtual void begin() {
		started = true;

	}

	public virtual Transform Spawn() {
		Transform alien = Instantiate (alienPrefab);
		alien.position = transform.position;
		alien.parent = transform;
		return alien;
	}
	
		
	 
}