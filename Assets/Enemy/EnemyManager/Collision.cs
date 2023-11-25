using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    public float DamageAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update() {
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            IDamageable Health = col.gameObject.GetComponent<IDamageable>();
            if (Health != null) {
                Health.Damage(DamageAmount);
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            IDamageable Health = col.gameObject.GetComponent<IDamageable>();
            if (Health != null) {
                Health.Damage(DamageAmount);
            }
            
        }
    }
}
