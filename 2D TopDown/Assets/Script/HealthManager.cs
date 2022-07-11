using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    private void Start()
    {
        InitHearts();
    }
    public void InitHearts()
    {
        for( int i =0;i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }
    public void UpdateHearts()
    {
        float tempHelth = playerCurrentHealth.RunTimeValue / 2;
        for ( int i = 0; i < heartContainers.initialValue; i++)
        {
            if(i<= tempHelth-1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHelth)
            {
                hearts[i].sprite = emptyHeart;
            }
            else 
            {
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
