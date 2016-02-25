using UnityEngine;
using System.Collections;

public class TimeDelaySpawner : EnemyWave {

	float time;
	public float timeSpace;
	public int count;
	protected float n;
	public float x;
	public float y;
	
	void Start(){
		n = count;
	}
	/*public void generate(Transform enemy){
		enemyPrefab = enemy;
	}*/
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		if (started && !done) {
		
			while (n> 0 && time <= 0) {
				Transform enemy = Spawn ();
				enemy.position = new Vector3 (x, y, 0); 
				enemy.GetComponent<BaseEnemy>().orderFactor = count - n;
				time = timeSpace;
				n --;
			}
			if (n <= 0) {
				spawnDone  = true;
			}
			time -= Time.deltaTime;
		}
	}
}