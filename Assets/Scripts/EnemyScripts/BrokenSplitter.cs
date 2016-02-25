using UnityEngine;
using System.Collections;

public class BrokenSplitter : BaseEnemy
{
    public Transform newEnemy;
    public int splitCount = 2;
    public float xdis = 3;
    int count = 0;


    public override void Update()
    {
        base.Update();
    }

    public override void Kill()
    {
        base.Kill();
        for (int y = 0; y < splitCount; y++)
        {
            Transform split = Instantiate(newEnemy);
            split.position = transform.position;
            if (splitCount % 2 != 0)
            {
                split.Translate(new Vector3(-10 * xdis, 0, 0));
                splitCount--;
            }
            else if (splitCount != 0)
            {
                count++;
                split.eulerAngles = (Vector3.forward * (count * (180 / (splitCount))));
                split.Translate(new Vector3(xdis, 0, 0));
                split = Instantiate(newEnemy);
                split.position = transform.position;
                split.eulerAngles = (Vector3.forward *(-count * (180 / (splitCount))));
                split.Translate(new Vector3(-xdis, 0, 0));
                splitCount -= 2;
            }
        }
    }
}