using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float DamageAmount;
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
                Destroy(gameObject);
            }
        }
    }
}
