using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float parallax;
	public bool wrap;
	public bool parented;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * parallax * Time.deltaTime);
		if (!Utility.isVisible (GetComponent<Renderer> (), Camera.main) && GetComponent<Renderer>().bounds.center.x < 0) {
			if (wrap) {
				transform.Translate((Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f, 0f)).x 
				                     + GetComponent<Renderer>().bounds.extents.x) * Vector3.right * 2);
			} else if (parented) {
				Destroy (transform.parent.gameObject);
			}
			else {
				Destroy (gameObject);
			}
		}
	
	}
}
