using UnityEngine;
using System.Collections;

public class RandomVolly : MonoBehaviour {

    public Transform shotType;
    public int numShots;
    public float angularSpread;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < numShots; i++) {
            Transform s = Instantiate(shotType);
            s.parent = transform.parent;
            s.position = transform.position;
            s.rotation = transform.rotation;
            s.Rotate(Vector3.forward * Random.Range(-angularSpread, angularSpread));
        }

        Destroy(gameObject);

    }
}
