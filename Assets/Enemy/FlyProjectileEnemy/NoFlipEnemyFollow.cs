using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFlipEnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 OGscale;
    [SerializeField] private float MovementSpeed;
    public bool on = true;
    private Rigidbody2D rb;
    public float maxTime = 0.3f;
    public float Force = 30f;
    private float time = 0f;
    public GameObject Player;
    void Start()
    {
        OGscale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        if (on&&Player != null) {
            time += Time.deltaTime;
            if (time > maxTime){
                if (Player != null) {
                    rb.AddForce((Player.transform.position-transform.position)*((7f/Vector3.Distance(Player.transform.position,transform.position)))*Force,ForceMode2D.Impulse);   
                    time = 0f;
                }
            }
        }
    }
}
