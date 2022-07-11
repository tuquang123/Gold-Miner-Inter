using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : InteracAble
{
    public Item contents;
    public Inventory playerInventory;
    public bool isOPen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anm;
    private void Start()
    {
        anm = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playInRange)
        {
            if (! isOPen)
            {
                //oprn chest
                OpenChest();
            }
            else
            {
                //chest is already open
                ChestALreadyOpen();
            }
        }
    }
    public void OpenChest()
    {
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDesciption;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        isOPen = true;
        contextOn.Raise();
        anm.SetBool("open", true);

    }
    public void ChestALreadyOpen()
    {
        dialogBox.SetActive(false);
        raiseItem.Raise();
        contextOff.Raise();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOPen)
        {
            contextOn.Raise();
            playInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOPen)
        {
            contextOff.Raise();
            playInRange = false;
        }

    }

}
