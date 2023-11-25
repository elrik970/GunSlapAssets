using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public interface IStatusEffectable {
    void AddEffect(string Effect, float Damage);
}