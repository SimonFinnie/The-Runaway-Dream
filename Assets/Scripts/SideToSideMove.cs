using UnityEngine;
using System.Collections;

public class SideToSideMove : MonoBehaviour {

    public float speed = 5;
    public Vector3 leftWall;
    public Vector3 rightWall;
    bool left = true;
	public EnemyWave partner;
	float deathtime = 0;


    // Use this for initialization
    void Start () {
		leftWall = new Vector3(-GameMaster.level.width, 0, 0);
        rightWall = new Vector3(GameMaster.level.width, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		if (GameMaster.level.GetComponentInChildren<Boss>() == null) {
			if (left) {
				if (transform.position [0] <= leftWall [0]) {
					left = false;
				} else {
					transform.Translate (Vector3.left * (speed * Time.deltaTime));
				}
			} else {
				if (transform.position [0] >= rightWall [0]) {
					left = true;
				} else {
					transform.Translate (Vector3.right * (speed * Time.deltaTime));
				}
			}
		} else {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
			deathtime += Time.deltaTime;
			if(deathtime > 6){
				Destroy (gameObject);
			}
		}
	}
}