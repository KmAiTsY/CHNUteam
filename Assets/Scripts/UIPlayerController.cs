using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerController : MonoBehaviour
{
    [SerializeField] private PressedButton left;
    [SerializeField] private PressedButton right;
    [SerializeField] private Button jump;
    [SerializeField] private Button shoot;

    public PressedButton Left
    {
        get { return left; }
    }
    public PressedButton Right
    {
        get { return right; }
    }
    public Button Jump
    {
        get { return jump; }
    }
    public Button Shoot
    {
        get { return shoot; }
    }

    void Start()
    {
        Player.Instance.InitPlayerController(this);
    }
}
