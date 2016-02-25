using UnityEngine;
using System.Collections;

public class SideMove : MonoBehaviour {

	public Transform enemyPrefab;
	int n = 0;
	float time = LevelMaster.timeScinceLevelStart;
	public float timeSpace;
	public int count;
	public float x = 4;
	public float y = -5;

	void Start(){
	}
	/*public void generate(Transform enemy){
		enemyPrefab = enemy;
	}*/
	// Update is called once per frame
	void Update () {

			if (n < count && (LevelMaster.timeScinceLevelStart - time) >= timeSpace) {
				Transform alien = Instantiate (enemyPrefab);
				alien.position = new Vector3 (x, y, 0); 
				time = LevelMaster.timeScinceLevelStart;
				n++;
			}
		}
	}

