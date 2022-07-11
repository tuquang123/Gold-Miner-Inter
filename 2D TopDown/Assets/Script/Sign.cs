using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : InteracAble
{
    public Text dialogText;
    public string dialog;
    public GameObject dialogBox;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            contextOff.Raise();
            playInRange = false;
            dialogBox.SetActive(false);
        }

    }



}
