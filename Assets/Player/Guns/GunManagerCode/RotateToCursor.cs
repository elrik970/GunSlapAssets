using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateToCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 CursorPos;
    private Camera Camera;
    void Start()
    {
        Camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera != null) {
            CursorPos = Camera.ScreenToWorldPoint(Input.mousePosition);
            transform.right = new Vector3(CursorPos.x,CursorPos.y,transform.position.z)-transform.position;
        }
        else {
            Camera = Camera.main;
        }
    }
}
