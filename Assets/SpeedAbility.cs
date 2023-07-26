using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAbility : MonoBehaviour, SpecialAbility
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    public void ActivateSpecialAbility()
    {
        rb.AddForce(rb.velocity*speed, ForceMode.Impulse);
    }
}
