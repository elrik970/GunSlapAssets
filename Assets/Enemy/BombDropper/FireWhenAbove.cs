using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWhenAbove : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem Bullet;
    public GameObject Player;
    [SerializeField] float DistanceToShoot; 
    public float waitTime;
    private float time;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if (time > waitTime) {
            Check();
            time = 0f;
        }
    }
    void Check() {
        if (Player != null) {
            if (Mathf.Abs(transform.position.x-Player.transform.position.x) < DistanceToShoot) {
                Bullet.Play();
            }
        }
        else {
            Player = GameObject.FindWithTag("Player");
        }
    }
}
