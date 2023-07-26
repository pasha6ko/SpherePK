using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEvents : MonoBehaviour
{
    static public IEnumerator WaitTilDo(float time, Action action)
    {
        while (time > 0)
        {
            time-= Time.deltaTime;
            yield return null;
        }
        action.Invoke();
    }
}
