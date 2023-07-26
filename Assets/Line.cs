using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private float timeToMove;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<AlyUnit> units;
    private void Start()
    {
        
    }
    public void Pause(Action e, float time)
    {
        StartCoroutine(PauseAsync(e,time));
    }
    IEnumerator PauseAsync(Action e ,float time)
    {
        yield return new WaitForSeconds(time);
        e.Invoke();
    }
    public void ChangeLinePosition()
    {
        StartCoroutine(ChangeLinePositionAsync());
    }
    IEnumerator ChangeLinePositionAsync()
    {
        units.RemoveAt(0);
        if (units.Count <= 0)
        {
            StartCoroutine(TimeEvents.WaitTilDo(4f, SceneEvents.instance.EndGame));
            yield break;
        }
        float value = 0;
        while (value < 1)
        {
            value += 1 / timeToMove * Time.deltaTime;
            for (int i = 0; i < units.Count; i++)
            {
                units[i].transform.position = Vector3.Lerp(spawnPoints[i + 1].position, spawnPoints[i].position, value);
            }
            yield return null;
        }
        units[0].rb.isKinematic = false;
        units[0].transform.parent = null;
        units[0].enabled = true;
        units[0].rope.enabled= true;
        units[0].collider.enabled= true;
        print(units);
    }
}
