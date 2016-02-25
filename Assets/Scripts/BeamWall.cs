using UnityEngine;
using System.Collections;

public class BeamWall : BaseEnemy {

	float time1 = LevelMaster.timeScinceLevelStart;
	public float timeSpace;
	public Transform wallBeam;
	public float bumpingDamage = 5;
	Transform beam;

	// Use this for initialization
	void Start () {
		transform.Translate (Vector3.back * 3);
		beam = Instantiate (wallBeam);
		//beam.localScale = transform.lossyScale;
        beam.position = transform.position;
		beam.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if((LevelMaster.timeScinceLevelStart - time1) >= timeSpace) {
			SwitchSetting ();
			time1 = LevelMaster.timeScinceLevelStart;
		}
	}

	void SwitchSetting(){
		beam.gameObject.SetActive(!beam.gameObject.active);
	}
}

