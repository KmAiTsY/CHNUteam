using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int silverNutsCount;
    public int goldNutsCount;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SilverNut"))
        {
            silverNutsCount++;
            Debug.Log(silverNutsCount);
        }
        if (collision.gameObject.CompareTag("GoldNut"))
        {
            goldNutsCount++;
            Debug.Log(goldNutsCount);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SilverNut"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("GoldNut"))
        {
            Destroy(collision.gameObject);
        }
    }
}
