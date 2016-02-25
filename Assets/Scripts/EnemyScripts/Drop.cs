using UnityEngine;
using System.Collections;

public class Drop : DestroyScript {
	public float dropChance;
	public Transform dropType;
	public bool tracked;
	public static float adjustment = 1f;
    public bool skipParent;


	public override void Run ()
	{
		float chance = dropChance;
		if (tracked) {
			chance *= adjustment;
			if (Random.Range (0f, 1f) <= chance && GetComponentInParent<BaseEnemy> () != null && !GetComponentInParent<BaseEnemy> ().badKill) {
				Transform drop = Instantiate (dropType);
				drop.position = transform.position;
				drop.parent = transform.parent;
				if (skipParent) {
					drop.parent = drop.parent.parent;
				}
					adjustment *= 0.5f;
			} else  {
				adjustment *= Mathf.Pow (2f, dropChance);
			}
		} else {
			if (Random.Range (0f, 1f) <= chance) {
				Transform drop = Instantiate (dropType);
				drop.position = transform.position;
				drop.parent = transform.parent;
				if (skipParent) {
					drop.parent = drop.parent.parent;
				}
			}
		}
	}
}
