using UnityEngine;
using System.Collections;

public class DoubleEnemy : MonoBehaviour {

    public Transform enemyType;
    public int r = 1;

	// Use this for initialization
	void Start () {
        Transform doubleEnemy = Instantiate(enemyType);
        doubleEnemy.position = transform.position;
        doubleEnemy.Translate(new Vector3(0, r, 0));
        doubleEnemy.SetParent(transform);
        doubleEnemy = Instantiate(enemyType);
        doubleEnemy.position = transform.position;
        doubleEnemy.Translate(new Vector3(0, -r, 0));
        doubleEnemy.SetParent(transform);

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime);
	}
}
