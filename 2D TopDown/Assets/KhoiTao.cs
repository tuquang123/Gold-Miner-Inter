using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhoiTao : MonoBehaviour
{
    public GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(character, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(character, gameObject.transform);
    }
}
