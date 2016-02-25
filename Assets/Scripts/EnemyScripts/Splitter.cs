using UnityEngine;
using System.Collections;

public class Splitter : BaseEnemy
{
    public Transform newEnemy;
    public int splitCount = 2;
    public float ydis = 1;
    int count = 0;


    public override void Update()
    {
        base.Update();
    }

     public override void Kill()
       {
        DestroyScript[] destroytools = GetComponents<DestroyScript>();
        for (int i = 0; i < destroytools.Length; i++)
        {
            destroytools[i].Run();
        }
        Destroy(gameObject);
        Transform split = Instantiate(newEnemy);
        split.position = transform.position;
        split.Translate(new Vector3(0, ydis, 0));
        split = Instantiate(newEnemy);
        split.position = transform.position;
        split.Translate(new Vector3(0, -ydis, 0));
    }
}