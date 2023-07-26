using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdGrab : MonoBehaviour
{
    [SerializeField] private Camera camera;
    public float forceMultiplier;
    private float _distanceToBirds;
    private Vector3 _mousePosition;
    private AlyUnit selectedUnit;
    private SpecialAbility currentAbility;

    private void Start()
    {
        _distanceToBirds =  transform.position.z;
    }
    public void OnMousePosition(InputValue value)
    {
        _mousePosition = value.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        if (selectedUnit == null || !selectedUnit._isPressed) return;
        Vector3 mouseWorldSpacePoint = camera.ScreenToWorldPoint(_mousePosition + Vector3.forward * _distanceToBirds);
        selectedUnit.UpdatePosition(mouseWorldSpacePoint);
    }
    private void Interact()
    {

        Ray ray = camera.ScreenPointToRay(_mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent<AlyUnit>(out AlyUnit unit))
            {
                selectedUnit = unit;
                selectedUnit.Grab();
                _distanceToBirds = Vector3.Distance(new Vector3(transform.position.x, transform.position.y, selectedUnit.transform.position.z),transform.position);
            }
        }
    }
    private void ReleaseUnit()
    {
        if (selectedUnit == null) return;
        currentAbility = selectedUnit.transform.GetComponent<SpecialAbility>();
        selectedUnit.Release();
        selectedUnit = null;
    }
    public void OnFire(InputValue value)
    {
        if (value.isPressed) Interact();
        else ReleaseUnit();
    }
    public void OnSpecialAbility()
    {
        if (currentAbility == null) return;
        print(currentAbility);
        currentAbility.ActivateSpecialAbility();
        currentAbility = null;
    }

}
