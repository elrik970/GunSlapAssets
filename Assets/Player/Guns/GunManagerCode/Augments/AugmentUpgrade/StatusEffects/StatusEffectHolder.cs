using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectHolder : MonoBehaviour, IStatusEffectable
{
    public SpriteRenderer PoisonSkull;
    public List<float> PoisonDamage = new List<float>();
    public List<float> PoisonTime = new List<float>();
    public float PoisonLength = 3f;
    public float PoisonFrequency = 0.4f;
    private float curPoisonTime = 0f;


    public SpriteRenderer Burn;
    public List<float> BurnDamage = new List<float>();
    public List<float> BurnTime = new List<float>();
    public float BurnLength = 1.5f;
    public float BurnFrequency = 0.2f;
    private float curBurnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curPoisonTime += Time.deltaTime;
        if (curPoisonTime > PoisonFrequency) {
            int i = 0;
            for (int j=0; j < PoisonDamage.Count;j++) {
                PoisonTime[i]-=curPoisonTime;
                if (PoisonTime[i] < 0) {
                    DoDamage(PoisonDamage[i]);
                    PoisonTime.RemoveAt(i);
                    PoisonDamage.RemoveAt(i);
                }
                else {
                    DoDamage(PoisonDamage[i]);
                    i++;
                }
            }
            curPoisonTime = 0f;
        }
        if (PoisonTime.Count>0) {
            if (PoisonSkull != null) {
                PoisonSkull.enabled = true;
            }
            
        }
        else {
            if (PoisonSkull != null) {
                PoisonSkull.enabled = false;
            }
        }



        curBurnTime += Time.deltaTime;
        if (curBurnTime > BurnFrequency) {
            int i = 0;
            for (int j=0; j < BurnDamage.Count;j++) {
                BurnTime[i]-=curBurnTime;
                if (BurnTime[i] < 0) {
                    DoDamage(BurnDamage[i]);
                    BurnTime.RemoveAt(i);
                    BurnDamage.RemoveAt(i);
                }
                else {
                    DoDamage(BurnDamage[i]);
                    i++;
                }
            }
            curBurnTime = 0f;
        }
        if (BurnTime.Count>0) {
            if (Burn != null) {
                Burn.enabled = true;
            }
        }
        else {
            if (Burn != null) {
                Burn.enabled = false;
            }
        }
    }
    public void AddEffect(string Effect, float Damage) {
        if (Effect == "poison") {
            PoisonDamage.Add(Damage);
            PoisonTime.Add(PoisonLength);
        }

        if (Effect == "burn") {
            BurnDamage.Add(Damage);
            BurnTime.Add(BurnLength);
        }
    }
    void DoDamage(float Damage) {
        IDamageable Health = GetComponent<IDamageable>();
        if (Health != null) {
            Health.Damage(Damage);
        }
    }
}
