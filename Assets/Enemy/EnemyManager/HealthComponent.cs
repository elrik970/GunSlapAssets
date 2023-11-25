using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    [SerializeField] private float Health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Destroy(gameObject);
        }
    }
    public void Damage(float DamageAmount) {
        Health-=DamageAmount;
    }
}
