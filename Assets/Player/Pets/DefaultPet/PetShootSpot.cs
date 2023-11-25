using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShootSpot : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit2D ShootHit;
    public LayerMask RaycastLayerMask;
    public Vector3 ShootSpot;
    public float RaycastRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootHit = Physics2D.Raycast(transform.position, transform.right, RaycastRange,RaycastLayerMask);
        if (ShootHit.collider != null) {
            ShootSpot = ShootHit.point;
            // Debug.Log(ShootHit.collider.gameObject);
        }
    }
}
