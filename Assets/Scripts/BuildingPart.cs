using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPart : DestroyObject
{
    [SerializeField] List<Joint> joints;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        List<Joint> toDestroy = new List<Joint>();
        foreach (Joint joint in joints)
        {
            if (joint.connectedBody == null)
            {
                toDestroy.Add(joint);
            }
        }
        foreach (Joint joint in toDestroy)
        {
            joints.Remove(joint);
            Destroy(joint);
        }
    }
}
