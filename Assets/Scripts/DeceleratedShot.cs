using UnityEngine;
using System.Collections;

public class DeceleratedShot : Shot {

    public float minSpeed;
    public float decel;

    public override void Update() {
        base.Update();
        if (speed < minSpeed) {
            speed -= decel * Time.deltaTime;
        }
        if (speed > minSpeed) {
            speed = minSpeed;
        }
    }

}
