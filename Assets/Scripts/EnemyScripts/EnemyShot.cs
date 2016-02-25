using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {
	
	float speed;
	float damage;
	public bool enemyShot;
	float angle;
	float speedX;
	float speedY;

	void Start(){
	}
	// Use this for initialization
	public void setUp (float speed, float damage, float angle) {
		this.angle = Mathf.PI * angle / 360;
		this.speed = speed;
		this.damage = damage;
		speedY = speed * Mathf.Sin (this.angle);
		speedX = speed * Mathf.Cos (this.angle);
	}
	
	// Update is called once per frame
	void Update () {
		// The projectile travels up (in the direction of positive y axis), but
		// the movement is multiplies by speed (so negative speed will get 
		// move the projectile down)
		transform.Translate(Vector3.right * speedX * Time.deltaTime);
		transform.Translate (Vector3.up * speedY * Time.deltaTime);
		
		// Check if the game object is visible, if not, destroy self   
		if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
			Destroy(gameObject);
		}
		
	}
}
