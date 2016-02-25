using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public float speed;
	public float damage;
	public int points;
	public bool enemyShot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
		// The projectile travels up (in the direction of positive y axis), but
		// the movement is multiplies by speed (so negative speed will get 
		// move the projectile down)
		transform.Translate(Vector3.right * speed * Time.deltaTime);
		
		// Check if the game object is visible, if not, destroy self   
		if(!Utility.isVisible(GetComponent<Collider2D>().bounds, Camera.main)) {
			Destroy(gameObject);
		}
	
	}
}
