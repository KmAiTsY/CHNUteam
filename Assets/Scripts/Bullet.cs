using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private TriggerDamage triggerDamage;
    [SerializeField] private float lifeTime;
    [SerializeField] private float force;
    public float Force
    {
        get { return force; }
        set { force = value; }
    }
    public void SetImpulse(Vector2 direction, float force, GameObject parent)
    {
        triggerDamage.Parent = parent;
        rigidbody.AddForce(direction * force, ForceMode2D.Impulse);
        StartCoroutine(StartLife());
    }

    private IEnumerator StartLife()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        yield break;
    }
}