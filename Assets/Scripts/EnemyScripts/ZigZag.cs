using UnityEngine;
using System.Collections;

public class ZigZag : BaseEnemy {


    public float zigZagLength = 3;
    float curTime = LevelMaster.timeScinceLevelStart;
    public bool startZig = true;
    public float ySpeed = 1;
    public float xSpeed = 1;
    public float times = LevelMaster.timeScinceLevelStart;
    float largestSpeed;

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update() {
        times = LevelMaster.timeScinceLevelStart;;
        base.Update();
        if ((LevelMaster.timeScinceLevelStart - curTime) >= zigZagLength/ySpeed)
        {
            startZig = !startZig;
            curTime = LevelMaster.timeScinceLevelStart;;
        }
        if (startZig)
        {
            transform.Translate(new Vector3(-1*xSpeed * Time.deltaTime, 1 * ySpeed * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(new Vector3(-1 * xSpeed * Time.deltaTime, -1 * ySpeed * Time.deltaTime, 0));
        }
        }
    }
