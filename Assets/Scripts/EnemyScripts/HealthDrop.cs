using UnityEngine;
using System.Collections;

public class HealthDrop : MonoBehaviour {
	public float hp;


	void OnTriggerEnter2D(Collider2D other) {
		PlayerShip player = other.GetComponent<PlayerShip> ();
		if (player != null && player.HP < player.MaxHP) {
			player.HP += hp;
			if (player.HP > player.MaxHP) {
				player.HP = player.MaxHP;
			}
			Destroy (gameObject);
		}
	}
}
