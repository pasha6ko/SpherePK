using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookByVelocity : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private void Update()
    {
        if (rb.velocity.magnitude < 0.5f) return;
        transform.rotation = Quaternion.LookRotation(rb.velocity.normalized);
    }
}
