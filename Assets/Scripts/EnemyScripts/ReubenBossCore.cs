using UnityEngine;
using System.Collections;

public class ReubenBossCore : ReubenBossRoot {

    public float magnitude;
    public float verticalDecel;
    public float oscilationSpeed;
    public float equlibrium;
    public float verticalSpeed;
    public int state;

    public override void Start() {
        base.Start();
        if (transform.position.y >= 0) {
            verticalSpeed = oscilationSpeed;
        } else {
            verticalSpeed = -oscilationSpeed;
            verticalDecel *= -1f;
        }
        if (transform.position.y > GameMaster.level.height || transform.position.y < -GameMaster.level.height) {
            equlibrium = 0f;
            verticalDecel *= -1f;
            verticalSpeed *= -1f;
        } else {
            equlibrium = transform.position.y;
        }

    }


    // Update is called once per frame
    public override void Update() {
        base.Update();
        if (started) {
            if (state == 0) {
                transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
                if ((transform.position.y > equlibrium + magnitude && verticalSpeed > 0) || (transform.position.y < equlibrium - magnitude && verticalSpeed < 0)) {
                    state = 1;
                }
            } else {
                verticalSpeed -= verticalDecel * Time.deltaTime;
                transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
                if (verticalSpeed >= oscilationSpeed && transform.position.y < equlibrium) {
                    verticalSpeed = oscilationSpeed;
                    state = 0;
                    verticalDecel *= -1;
                } else if (verticalSpeed <= -oscilationSpeed && transform.position.y > equlibrium) {
                    verticalSpeed = -oscilationSpeed;
                    state = 0;
                    verticalDecel *= -1;
                }
            }
        }

    }
}
