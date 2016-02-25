using UnityEngine;
using System.Collections;

public class Boss : EnemyDecelerate {

    public Transform triShot;
    public Transform aimShot;
	public Transform look;
    public static int n1 = 8;
    public static int n2 = 6;
    Transform[] rad2 = new Transform[n1];
    Transform[] rad1 = new Transform[n2];
    float r2 = 4;
    float r1 = 2;

    // Use this for initialization
    public override void Start() {
        base.Start();
		look = Instantiate (look);
		look.position = transform.position;
		look.SetParent (transform);
        for (int i = 0; i < rad2.Length; i++) { 
            rad2[i] = Instantiate(triShot);
            rad2[i].position = transform.position;
            rad2[i].Translate(new Vector3(0,r2,0));
            rad2[i].RotateAround(transform.position, Vector3.forward, i*(360.0f/rad2.Length));
            rad2[i].eulerAngles = new Vector3(0, 0, 0);
            rad2[i].SetParent(transform);
        }
        for (int i = 0; i < rad1.Length; i++){
            rad1[i] = Instantiate(aimShot);
            rad1[i].position = transform.position;
            rad1[i].Translate(new Vector3(0,r1,0));
            rad1[i].RotateAround(transform.position, Vector3.forward, i * (360.0f / rad1.Length));
            rad1[i].eulerAngles = new Vector3(0, 0, 0);
            rad1[i].SetParent(transform);
        }

    }
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
	
	}

	public override void Kill ()
	{
		BaseEnemy[] enemies = GetComponentsInChildren<BaseEnemy> ();
		foreach (BaseEnemy b in enemies) {
			if (b != this) {
				b.transform.parent = transform.parent;
				b.Kill ();
			}
		}
		base.Kill ();
	}
}
