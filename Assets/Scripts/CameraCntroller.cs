using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntroller : MonoBehaviour
{
    public Transform transform;
    public Camera camera;
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.KeypadPlus) && camera.orthographicSize>1)
        {
            camera.orthographicSize -= 1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            camera.orthographicSize += 1f * Time.deltaTime;
        }
    }
}
