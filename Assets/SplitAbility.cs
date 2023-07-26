using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitAbility : MonoBehaviour, SpecialAbility
{
    [SerializeField] Rigidbody rb;
    public void ActivateSpecialAbility()
    {
        GameObject clone1 = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, 0));
        clone1.GetComponent<Rigidbody>().AddForce(rb.velocity + Vector3.down * 1, ForceMode.VelocityChange);
        GameObject clone2 = Instantiate(gameObject, transform.position, Quaternion.Euler(0, 0, 0));
        clone2.GetComponent<Rigidbody>().AddForce(rb.velocity +Vector3.up * 1, ForceMode.VelocityChange);
    }
}
