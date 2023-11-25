using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFlipPlayerZone : MonoBehaviour
{
    // Start is called before the first frame update
    public NoFlipEnemyFollow EnemyFollow;
    public GameObject Player;
    public float SeeDistance;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckDistance());
    }

    IEnumerator CheckDistance() {
        if (Player != null) {
            if (Vector3.Distance(transform.position,Player.transform.position) < SeeDistance) {
                EnemyFollow.Player = Player;
            }
        }
        else {
            Player = GameObject.FindWithTag("Player");
        }
        yield return new WaitForSeconds(3f);
    }

}
