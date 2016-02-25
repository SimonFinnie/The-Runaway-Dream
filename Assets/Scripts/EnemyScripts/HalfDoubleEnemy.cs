using UnityEngine;
using System.Collections;

public class HalfDoubleEnemy : BaseEnemy
{
    public Transform destroyed;

    public override void Start()
    {
        base.Start();
    }


    public override void Update()
    {
        base.Update();
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public override void Kill()
    {
        base.Kill();
        Transform deadShip = Instantiate(destroyed);
        deadShip.position = transform.position;
        deadShip.SetParent(transform.parent);
    }
}