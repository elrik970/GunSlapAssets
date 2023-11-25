using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShoot : MonoBehaviour
{
    // Start is called before the first frame update
    
    public ParticleSystem part;
    private bool DamageOn = true;
    private float curTime;
    public float maxTime = 1;
    void Start()
    {
        // Shoot.Shot+=Shot;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > maxTime) {
            curTime = 0;
            Shot();
            DamageOn = true;
        }
    }
    void Shot() {
        if (part != null&&DamageOn) {
            part.Play();
            // DamageOn = false;
        }
        
    }
}
