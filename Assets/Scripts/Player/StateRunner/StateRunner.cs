using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateRunner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private List<State<T>> states;
    private readonly Dictionary<Type, State<T>> stateByType = new();
    private State<T> activeState;

    protected virtual void Awake()
    {
        states.ForEach(s => stateByType.Add(s.GetType(), s));
        setState(states[0].GetType());
    }

    public void setState(Type newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }
        activeState = stateByType[newState];
        activeState.init(GetComponent<T>());
    }

    private void Update()
    {
        activeState.CaptureInput();
        activeState.Update();
        activeState.ChangeState();
    }

    private void FixedUpdate()
    {
        activeState.FixedUpdate();
    }
}
