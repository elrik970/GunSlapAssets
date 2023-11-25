using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public float DamageAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy") {
            if (col.GetComponent<IDamageable>()!=null) {
                col.GetComponent<IDamageable>().Damage(DamageAmount);
            }
        }
        ActivateAugments(col.gameObject,col.transform.position);
    }
    void ActivateAugments(GameObject col, Vector3 Pos) {
        IAugmentable[] Augments = GetComponentsInChildren<IAugmentable>();
        foreach (IAugmentable augment in Augments) {
            augment.AugmentEffect(col, Pos,DamageAmount);
        }
        
    }
}
