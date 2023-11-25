using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    // Start is called before the first frame update
    public float RaycastDist;
    private RaycastHit2D LeftHit;
    public float waitTime;
    private float time;
    
    private RaycastHit2D RightHit;
    public float SwapDirectionTime;
    private Rigidbody2D rb;
    public LayerMask GroundLayerMask;
    private float ogSpeedMult;
    public float SpeedMult;
    void Start()
    {
        ogSpeedMult = SpeedMult;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        if (time > SwapDirectionTime) {
            SpeedMult = -SpeedMult;
            time = 0f;
        }
        StartCoroutine(Move());
    }

    IEnumerator Move() {
        // RightHit = Physics2D.Raycast(transform.position, Vector2.right, RaycastDist,GroundLayerMask);
        // if (RightHit.collider != null) {
        //     SpeedMult = -ogSpeedMult;
        // }
        // else {
        //     LeftHit = Physics2D.Raycast(transform.position, Vector2.left, RaycastDist,GroundLayerMask);
            
        //     if (LeftHit.collider != null) {
        //         SpeedMult = ogSpeedMult;
        //     }
        // }
        rb.AddForce(Vector3.right*SpeedMult,ForceMode2D.Impulse);   
        yield return new WaitForSeconds(waitTime);
    }
    
    
}
