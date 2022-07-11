using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 initiavalue;
    public Vector2 defaultValue;

    public void OnAfterDeserialize()
    {
        initiavalue = defaultValue;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
