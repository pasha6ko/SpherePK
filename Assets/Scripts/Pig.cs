using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : DestroyObject
{
    protected void Start()
    {
        base.Start();
        GameResources.instance.AddPig(this);
        print("pig");
    }
    protected void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
    protected override void Destroy()
    {
        GameResources.instance.RemovePig(this);
        base.Destroy();
    }

}
