using UnityEngine;
using System.Collections;

public class ReubenBossHead : ReubenBossRoot {


    public ReubenBossRoot[] extras;
    public ReubenBossRoot next;


    public override void Kill() {
        foreach (ReubenBossRoot r in extras) {
            if (r != null) {
                next.HP += r.HP;
                r.Kill();
            }
        }
        base.Kill();
    }
}
