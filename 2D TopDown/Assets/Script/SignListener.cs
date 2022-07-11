using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignListener : MonoBehaviour
{
    public Signal Signal;
    public UnityEvent signalEvent;
   public void OnSiGnalRaised()
    {
        signalEvent.Invoke();
    }
    private void OnEnable()
    {
        Signal.RegisterListener(this);
    }
    private void OnDisable()
    {
        Signal.DeRegisterListener(this);
    }
}
