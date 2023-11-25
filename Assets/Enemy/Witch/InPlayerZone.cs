using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlayerZone : MonoBehaviour
{
    // Start is called before the first frame update
    public float SeeDistance = 10;
    private Transform Player;
    public bool InZone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckDistance());
    }
    IEnumerator CheckDistance() {
        if (Player != null) {
            if (Vector3.Distance(transform.position,Player.position) < SeeDistance) {
                InZone = true;
            }
            else {
                InZone = false;
            }
        }
        else {
            Player = GameObject.FindWithTag("Player").transform;
        }
        yield return new WaitForSeconds(1f);
    }
}
