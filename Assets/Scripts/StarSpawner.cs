using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour {

	public Transform star;
	public float prob = 1;
	public float ymax = 5;
	public float speedRange = 1;
	float check;
	float speedError;
	float pos;
	Transform star2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		check = Random.Range(0f,1f);
		if(check <= prob){
			pos = Random.Range((-ymax + 0.2f), (ymax - 0.2f));
			star2 = Instantiate (star);
			star2.position = transform.position;
			star2.Translate(new Vector3(0,pos,0));
			speedError = Random.Range(-speedRange, speedRange);
			star2.GetComponent<MoveX>().speed += speedError;
		}
	}
}
