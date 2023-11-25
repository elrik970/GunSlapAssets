using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DestroyAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float MaxTime;
    public CinemachineImpulseSource CameraShake;
    private float time = 0;
    void Start()
    {
        if (CameraShake != null) {
            CameraShake.GenerateImpulseWithForce(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if (time > MaxTime) {
            Destroy(gameObject);
        }
    }
}
