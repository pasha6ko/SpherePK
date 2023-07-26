using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] protected int score;
    [SerializeField] protected float hp;
    protected void Start()
    {
        GameResources.instance.SetMaxLevelScore(score);
    }
   protected void OnCollisionEnter(Collision collision)
    {
        hp -= collision.impulse.magnitude;
        if (hp > 0f) return;
        Destroy();
    }
    virtual protected void Destroy()
    {
        GameResources.instance.PlusScore(score);
        Destroy(gameObject);
    }
}
