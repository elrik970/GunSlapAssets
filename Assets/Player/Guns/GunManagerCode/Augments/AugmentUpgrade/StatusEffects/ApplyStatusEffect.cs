using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyStatusEffect : MonoBehaviour, IAugmentable
{
    // Start is called before the first frame update
    public string StatusEffect;
    public float DamageAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AugmentEffect(GameObject col, Vector3 Pos, float Damage) {
        IStatusEffectable status = col.GetComponent<IStatusEffectable>();
        if (status != null) {
            status.AddEffect(StatusEffect,DamageAmount);
        }
    }
}
