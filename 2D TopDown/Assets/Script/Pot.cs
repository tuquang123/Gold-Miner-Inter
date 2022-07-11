using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;
   
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Smash()
    {
        animator.SetBool("smash", true);
        StartCoroutine(breakCo());
    }
    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.34f);
        this.gameObject.SetActive(false);
    }
}
