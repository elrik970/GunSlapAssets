using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetFollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera virtualCamera;
    
    void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (virtualCamera.Follow == null) {
            
            // Set the follow target to the specified transform
            if (virtualCamera != null)
            {
                virtualCamera.Follow = GameObject.FindWithTag("Player").transform;
            }
        }
    }
}
