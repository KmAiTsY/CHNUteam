using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public Button[] buttons;
    public void ButtonFunc()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int temp = i;
            buttons[i].onClick.AddListener(() =>
            {
                SceneManager.LoadScene(temp + 2);
            });
        }
    }
}