using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDamageEffect : MonoBehaviour, IAugmentable
{
    // Start is called before the first frame update
    public float DamagePercentage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AugmentEffect(GameObject col, Vector3 Pos, float Damage) {
        if (col.GetComponent<IDamageable>()!=null) {
            col.GetComponent<IDamageable>().Damage(Damage*(DamagePercentage/100));
            Debug.Log(Damage*(DamagePercentage/100));
        }
    }
}
