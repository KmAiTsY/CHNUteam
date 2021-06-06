using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenSilverNuts : MonoBehaviour
{
    public Text text;
    public Player player;
    private PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerInventory.silverNutsCount.ToString();
    }
}
