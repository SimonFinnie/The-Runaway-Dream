using UnityEngine;
using System.Collections;

public class CircleEnemy : BaseEnemy {

	public float radius;
	public float rotationRate;
	public Vector3 pivot;
	public float leeWay;
	public float deceleration;
	public float minSpeed;
	public bool fixedRotation;
	public float rotationByOrder;

	// Use this for initialization
	public override void Start () {
		base.Start();
		pivot = new Vector3 (transform.position.x, transform.position.y);
		transform.Translate (Vector3.up * radius);
		healthbarDrop = healthBar.transform.localPosition;
		if (fixedRotation) {
			transform.eulerAngles= new Vector3(0, 0, 270);
		}
		transform.RotateAround (pivot, Vector3.back, rotationByOrder * orderFactor);

	
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		Vector3 dis = transform.position - pivot;
		pivot -= (Vector3.right * speed * Time.deltaTime);
		transform.position = pivot + dis;
		//transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
		transform.RotateAround (pivot, Vector3.forward, rotationRate * Time.deltaTime);
		if (!lookAtPlayer) {
			if (fixedRotation) {
				
				healthBar.transform.position = transform.position + healthbarDrop;
				healthBar.transform.eulerAngles = new Vector3 (0, 0, 0);
			}else {
				transform.eulerAngles = new Vector3 (0, 0, 0);
			}
		} 
		speed -= deceleration * Time.deltaTime;
		if (speed < minSpeed) {
			speed = minSpeed;
		}



	
	}

	public override void ValidatePosition ()
	{
		if (hasEntered) {
			if(!Utility.isVisible(GetComponent<Renderer>(), Camera.main)) {
				if (wrap && pivot.x + leeWay < (-1f * GameMaster.level.width) && transform.position.y > pivot.y + radius*0.9){
					float offset = GameMaster.level.width + leeWay + pivot.x;  
					Vector3 dis = transform.position - pivot;
					pivot.x *= -1f;
					pivot.x += offset;
					transform.eulerAngles = new Vector3(0,0,0);
					transform.position = pivot + dis;
				} else if (!wrap && pivot.x + radius < (-1f * GameMaster.level.width)){
					Destroy (gameObject);
				}
			}
		} else if (Utility.isVisible(GetComponent<Renderer>(), Camera.main) ){
			hasEntered = true;
		}
	}
}
