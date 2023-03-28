using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T> : ScriptableObject where T : MonoBehaviour
{
    protected T runner;

    public virtual void init(T parent)
    {
        runner = parent;
    }

    public abstract void CaptureInput();

    public abstract void Update();

    public abstract void FixedUpdate();

    public abstract void ChangeState();

    public abstract void Exit();
}
