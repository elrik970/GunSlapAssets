using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float DamageAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update() {
        
    }
    void OnParticleCollision(GameObject col) {
        if (col.gameObject.tag == "Player") {
            IDamageable Health = col.GetComponent<IDamageable>();
            if (Health != null) {
                Health.Damage(DamageAmount);
            }
        }
    }
}