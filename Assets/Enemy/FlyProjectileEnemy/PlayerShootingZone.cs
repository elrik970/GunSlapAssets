using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingZone : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Bullet;
    private float CurrentTime;
    [SerializeField] private float MaxTime;
    public NoFlipEnemyFollow EnemyFollow;
    private Transform Player;
    public float SeeDistance;
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EnemyFollow.on) {
            CurrentTime+=Time.deltaTime;
            if (CurrentTime > MaxTime) {
                Bullet.Play();
                CurrentTime = 0f;
            }
        }
        StartCoroutine(CheckDistance());
    }
    // void OnTriggerEnter2D(Collider2D col) {
    //     if (col.gameObject.tag == "Player") {
    //         EnemyFollow.on = false;
    //     }
    // }
    IEnumerator CheckDistance() {
        if (Player != null) {
            if (Vector3.Distance(transform.position,Player.position) < SeeDistance) {
                EnemyFollow.on = false;
            }
            else {
                EnemyFollow.on = true;
            }
        }
        else {
            Player = GameObject.FindWithTag("Player").transform;
        }
        yield return new WaitForSeconds(1f);
    }
}
