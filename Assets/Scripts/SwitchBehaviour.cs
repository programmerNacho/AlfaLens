using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBehaviour : MonoBehaviour
{
    public enum States { Off, On }

    [SerializeField]
    private States currentState;
    public UnityEvent OnTurnOn = new UnityEvent();
    public UnityEvent OnTurnOff = new UnityEvent();

    public void Change()
    {
        switch (currentState)
        {
            case States.Off:
                currentState = States.On;
                break;
            case States.On:
                currentState = States.Off;
                break;
        }
        StateChangeCallEvents();
    }

    public void Change(States state)
    {
        currentState = state;
        StateChangeCallEvents();
    }

    private void StateChangeCallEvents()
    {
        switch (currentState)
        {
            case States.Off:
                OnTurnOff.Invoke();
                break;
            case States.On:
                OnTurnOn.Invoke();
                break;
            default:
                break;
        }
    }
}
