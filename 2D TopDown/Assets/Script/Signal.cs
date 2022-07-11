using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignListener> listeners = new List<SignListener>();
    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSiGnalRaised();
        }
    }
    public void RegisterListener(SignListener listener)
    {
        listeners.Add(listener);
    }
    public void DeRegisterListener(SignListener listener)
    {
        listeners.Remove(listener);
    }
}
