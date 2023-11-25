using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBalls : MonoBehaviour
{
    // Start is called before the first frame update
    public Player PlayerController;
    public float[] offset = {1f,0.5f};
    public float slimeBallNum;
    public float LerpSpeed = 2;
    public float DistanceMultiplayer;
    Vector3 PlayerPos;  
    Vector3 oldPos = new Vector3(0f,0f,0f);
    public float MaxX;
    public float MaxY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = PlayerController.transform.position;
        offset = new float[] {Mathf.Clamp(-PlayerController.rb.velocity.x/DistanceMultiplayer,-MaxX,MaxX),Mathf.Clamp(-PlayerController.rb.velocity.y/DistanceMultiplayer,-MaxY,MaxY)};
        Vector2 targetPos = new Vector3(PlayerPos.x+(offset[0]*slimeBallNum),PlayerPos.y+(offset[1]*slimeBallNum),0);
        transform.position = Vector2.Lerp(transform.position,targetPos,Time.deltaTime*LerpSpeed);
        transform.position = new Vector3(transform.position.x,transform.position.y,1f);
        oldPos = PlayerController.transform.position;
    }
}