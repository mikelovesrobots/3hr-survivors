using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState = null;
    [HideInInspector]
    public State currentState = null;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        if (initialState)
        {
            initialState.Activate();
            currentState = initialState;
        }
    }

    public void SwitchState(string stateName)
    {
        var stateTransform = transform.Find(stateName);
        var state = stateTransform?.GetComponent<State>();
        if (state != null)
        {
            SwitchState(state);
        }
        else
        {
            Debug.LogWarning($"State {stateName} not found.");
        }
    }

    public void SwitchState(State state)
    {
        if (currentState)
        {
            currentState.Deactivate();
            currentState = initialState;
        }

        this.currentState = state;
        state.Activate();
    }
}
