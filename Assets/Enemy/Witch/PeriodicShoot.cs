using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource SoundFX;
    private float time;
    public float maxTime = 0.5f;
    public ParticleSystem bullet;
    public InPlayerZone inPlayerZone;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inPlayerZone.InZone) {
            time += Time.deltaTime;
            if (time > maxTime) {
                if (bullet != null) {
                    bullet.Play();
                }
                if (SoundFX != null) {
                    SoundFX.Play();
                }
                time = 0f;
            }
        }
    }
}
