using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContexClues : MonoBehaviour
{
    public GameObject contextClue;
    public void Enable()
    {
        contextClue.SetActive(true);
    }
    public void Disable()
    {
        contextClue.SetActive(false);
    }
}
