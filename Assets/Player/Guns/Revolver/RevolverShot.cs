using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverShot : MonoBehaviour, IShootable
{
    // Start is called before the first frame update
    private GameObject instantiated;
    public ParticleSystem Bullet;
    public ParticleSystem AddedShootEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot() {
        // instantiated = (GameObject)GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);
        Bullet.Play();
        if (AddedShootEffect != null) {
            AddedShootEffect.Play();
        }
    }
}
