using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual void OnEnterState()
    {
        // Default implementation (empty)
    }

    public virtual void OnExitState()
    {
        // Default implementation (empty)
    }

    public void Deactivate()
    {
        OnExitState();
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        OnEnterState();
    }
}
