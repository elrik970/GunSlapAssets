using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToShootSpot : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 ShootSpot;
    public PetShootSpot PetShootSpot;
    void Start()
    {
        PetShootSpot = GameObject.FindWithTag("PetHolder").GetComponent<PetShootSpot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PetShootSpot != null) {
            ShootSpot = PetShootSpot.ShootSpot;
            transform.right = new Vector3(ShootSpot.x,ShootSpot.y,transform.position.z)-transform.position;
        }
        else {
            PetShootSpot = GameObject.FindWithTag("PetHolder").GetComponent<PetShootSpot>();
        }
        
    }
}
