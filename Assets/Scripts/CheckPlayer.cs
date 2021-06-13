using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Transform transform;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float distance;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        player.GetComponent<Transform>();
        if ((player.transform.position.y - transform.position.y) > distance)
        {
            boxCollider.isTrigger = false;
        }
        else
        {
            boxCollider.isTrigger = true;
        }
    }
}
