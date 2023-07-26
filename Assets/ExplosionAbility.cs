using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosionAbility : MonoBehaviour, SpecialAbility
{
    [SerializeField] private SphereCollider collider;
    [SerializeField] private float explotionSpeed, explotionWidth;
    public void ActivateSpecialAbility()
    {
        collider.enabled = true;
        StartCoroutine(Explosion());
    }
    IEnumerator Explosion()
    {
        collider.transform.parent = null;
        float value = 0;
        while(value<1)
        {
            value += 1 / explotionSpeed * Time.deltaTime;
            collider.radius = Mathf.Lerp(0, explotionWidth,value);
            yield return null;  
        }
        collider.enabled = false;
    }
}
