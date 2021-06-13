using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int silverNutsCount;
    public int goldNutsCount;
    public int bulletCount;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("SilverNut"))
        {
            silverNutsCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("GoldNut"))
        {
            goldNutsCount++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bulletCount += 10;
            Destroy(collision.gameObject);
        }
    }
}
