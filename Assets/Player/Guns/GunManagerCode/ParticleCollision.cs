using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem part;
    public GameObject HitEffect;
    [SerializeField] private float DamageAmount;
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    
    void Update() {
        
    }
    void OnParticleCollision(GameObject col) {
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
        int numCollisionEvents = part.GetCollisionEvents(col, collisionEvents);
        for (int i = 0; i < numCollisionEvents;i++) {
            DoDamage(col,collisionEvents[i].intersection);
            if (HitEffect != null) {
                GameObject itiated = (GameObject)GameObject.Instantiate(HitEffect, collisionEvents[i].intersection, Quaternion.identity,transform);
                itiated.transform.SetParent(null);
            }
        }
    }
    void ActivateAugments(GameObject col, Vector3 Pos, float DamageAmount) {
        IAugmentable[] Augments = GetComponentsInChildren<IAugmentable>();
        foreach (IAugmentable augment in Augments) {
            augment.AugmentEffect(col, Pos,DamageAmount);
            
        }
        
    }
    void DoDamage(GameObject col, Vector3 Pos) {
        IDamageable Health = col.GetComponent<IDamageable>();
        if (Health != null) {;
            Health.Damage(DamageAmount);
            
        }
        ActivateAugments(col, Pos,DamageAmount);
        
    }
}
