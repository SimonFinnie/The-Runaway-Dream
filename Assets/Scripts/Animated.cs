using UnityEngine;
using System.Collections;

public class Animated : MonoBehaviour {

	SpriteRenderer render;
	public float speed;
	public bool loop;
	public Sprite[] sprites;
	float timeTillNext;
	int current;

	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer> ();
		current = 0;
		timeTillNext = speed;
		render.sprite = sprites [0];
	
	}
	
	// Update is called once per frame
	void Update () {
		timeTillNext -= Time.deltaTime;
		if (timeTillNext <= 0) {
			current++;
			timeTillNext = speed;
			if (current < sprites.Length){
				render.sprite = sprites[current];
			} else if (loop) {
				current = 0;
				render.sprite = sprites[0];
			}
		}
	
	}
}
