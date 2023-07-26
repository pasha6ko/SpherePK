using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRender : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] AlyUnit unit;
    [SerializeField] private float width;
    private void Start()
    {
        line.enabled = true;
    }
    private void FixedUpdate()
    {
        line.SetPosition(0, unit.slingshotCenter.position - Vector3.forward * width / 2);
        line.SetPosition(1, transform.position);
        line.SetPosition(2, unit.slingshotCenter.position + Vector3.forward * width / 2);
    }
}
