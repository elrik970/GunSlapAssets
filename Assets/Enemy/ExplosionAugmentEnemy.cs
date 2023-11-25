using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAugmentEnemy : MonoBehaviour, IAugmentable
{
    // Start is called before the first frame update
    private GameObject instantiated;
    public float DamageAmount;
    public float scale;
    public GameObject explosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AugmentEffect(GameObject col, Vector3 Pos, float Damage) {
        instantiated = (GameObject)GameObject.Instantiate(explosion, Pos, Quaternion.identity);
        instantiated.GetComponent<Collision>().DamageAmount = DamageAmount;
        instantiated.transform.localScale = new Vector3(scale,scale,scale);
    }
}
