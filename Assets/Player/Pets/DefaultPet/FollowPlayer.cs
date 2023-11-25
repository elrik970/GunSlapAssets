using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private float curTime = 0f;
    public float maxDistance = 30f;
    public float maxTime = 0.3f;
    public float Force = 5;
    private Rigidbody2D rb;
    public Vector3 SpotToMove;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        curTime+=Time.deltaTime;
        if (curTime > maxTime) {
            rb.AddForce(Vector3.Normalize(SpotToMove-transform.localPosition)*Force,ForceMode2D.Impulse);
            curTime = 0;
        }
        if (Vector3.Distance(transform.localPosition, SpotToMove) > maxDistance) {
            transform.localPosition = SpotToMove;
        }
    }
}
