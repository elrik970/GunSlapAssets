using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAugment : MonoBehaviour, IAugmentable
{
    // Start is called before the first frame update
    private GameObject instantiated;
    
    public float DamageAmount;
    private bool ExplosionOn = true;
    private float curTime;
    public float maxTime = 1;
    public float scale;
    
    public GameObject explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ExplosionOn) {
            curTime += Time.deltaTime;
            if (curTime > maxTime) {
                curTime = 0;
                ExplosionOn = true;
            }
        }
    }
    public void AugmentEffect(GameObject col, Vector3 Pos, float Damage) {
        if (ExplosionOn) {
            instantiated = (GameObject)GameObject.Instantiate(explosion, Pos, Quaternion.identity);
            instantiated.GetComponent<ColliderCollision>().DamageAmount = DamageAmount;
            instantiated.transform.localScale = new Vector3(scale,scale,scale);
            ExplosionOn = false;
            curTime = 0;
        }
    }
}
