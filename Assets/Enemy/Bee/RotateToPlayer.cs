using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 CursorPos;
    private Transform Player;
    private Camera Camera;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // IEnumerator StartFunc() {
    //     yield return new WaitForSeconds(0.2f);
    //     Player = GameObject.FindWithTag("Player").transform;
    // }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) {
            transform.right = new Vector3(Player.position.x,Player.position.y,transform.position.z)-transform.position;
        }
        else {
            Player = GameObject.FindWithTag("Player").transform;
        }
    }
}
