using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlat : MonoBehaviour
{
    // Start is called before the first frame update
    private Player Player;
    private Collider2D PlayerCollider;
    public Collider2D thisCollider;
    void Start()
    {
        // Player = GameObject.FindWithTag("Player").GetComponent<Player>();
        // PlayerCollider = Player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void OnTriggerEnter2D(Collider2D col) {
        // if (col.gameObject.tag == "Player") {
        //     if (Player.rb.velocity.y > 0f){
        //         Physics2D.IgnoreCollision(PlayerCollider, Collider,true);
        //     }
        //     else {
        //         Physics2D.IgnoreCollision(PlayerCollider, Collider,false);
        //     }
        // }
        // else {
        //     Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), Collider,true);
        // }
    // }
}
