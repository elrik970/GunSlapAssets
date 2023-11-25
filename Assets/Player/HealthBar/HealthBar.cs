using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealthComponent HealthComponent;
    private float maxHealth;
    public bool IsPlayer = false;
    private float BeginningScale; 
    void Start()
    {
        if (IsPlayer) {
            HealthComponent = GameObject.FindWithTag("Player").GetComponent<PlayerHealthComponent>();
        }
        maxHealth = HealthComponent.Health;
        BeginningScale = transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthComponent != null) {
            if (HealthComponent.Health > 0) {
                transform.localScale = new Vector3(BeginningScale*(HealthComponent.Health/maxHealth),transform.localScale.y,transform.localScale.z);
            }
            else {
                transform.localScale = Vector3.zero;
            }
        }
        else {
            if (IsPlayer) {
                HealthComponent = GameObject.FindWithTag("Player").GetComponent<PlayerHealthComponent>();
                maxHealth = HealthComponent.Health;
                BeginningScale = transform.localScale.x;
            }
        }
    }
}
