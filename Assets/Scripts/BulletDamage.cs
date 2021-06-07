using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool isDestroyAfterCollision;
    private GameObject parent;
    public GameObject Parent
    {
        get { return parent; }
        set { parent = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject == parent)
            return;
        var heath = col.gameObject.GetComponent<Health>();
        if (heath != null)
        {
            heath.TakeHit(damage);
        }
        if (isDestroyAfterCollision)
            Destroy(gameObject);
    }
}
