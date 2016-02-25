using UnityEngine;
using System.Collections;

public class TimeSpaceDelaySpawner : TimeDelaySpawner {

	public float xDif;
	public float yDif;

	public override Transform Spawn() {
		if (n != count) {
			x += xDif;
			y += yDif;
		}
		return base.Spawn ();
	}


}
