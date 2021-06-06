using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenHealth : MonoBehaviour
{
    public Text text;
    public Player player;
    private Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = health.health.ToString();
    }
}
