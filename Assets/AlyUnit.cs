using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlyUnit : MonoBehaviour
{
    public Transform slingshotCenter;
    public RopeRender rope;
    public Collider collider;
    [SerializeField] TrajectoryRenderer trajectoryRenderer; // перенеси в grab
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] Line line;
    [SerializeField] Slingshot slingshot;
    [SerializeField] private bool destroyAfterFire;
    public Rigidbody rb;
    public bool _isPressed = false;
    private Vector3 _mousePosition;
    private BirdGrab birdGrab;
    private Camera _camera;
    private float forceMultiplier;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        _camera = Camera.main;
        birdGrab = _camera.GetComponent<BirdGrab>();
        forceMultiplier = birdGrab.forceMultiplier;
    }
    public void Grab()
    {
        _isPressed = true; 
        rb.isKinematic = true;
        rb.useGravity = false;
        collider.enabled = false;
    }
    private void ResetPosition()
    {
        rb.position = slingshotCenter.position;
    }
    public void Release()
    {
        _isPressed = false;
        collider.enabled = true;
        float distanceToSlingshot = Vector3.Distance(transform.position, slingshotCenter.position);
        if(distanceToSlingshot < slingshot.fireDistance)
        {
            ResetPosition();
            return;
        }
        Vector3 forceDirectrion = slingshotCenter.position - transform.position;
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(forceDirectrion * forceMultiplier * distanceToSlingshot, ForceMode.VelocityChange);
        line.Pause(line.ChangeLinePosition, 2f);
        trajectoryRenderer.ResetTrajectory();
        if (destroyAfterFire)
        {
            Destroy(rope);
            Destroy(lineRenderer);
            Destroy(this);
        }
    }
    public void UpdatePosition(Vector3 mouseWorldSpacePoint)
    {
        float distanceToSlingshot = Vector3.Distance(transform.position, slingshotCenter.position);
        Vector3 forceDirectrion = slingshotCenter.position - transform.position;
        rb.position = mouseWorldSpacePoint;
        trajectoryRenderer.ShowTrajectory(slingshotCenter.position, forceDirectrion * forceMultiplier * distanceToSlingshot);
    }
    
    private void FixedUpdate()
    {
        if (_isPressed == false) return;
    }
}
