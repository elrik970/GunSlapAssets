using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentInterface : MonoBehaviour
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
public interface IAugmentable {
    void AugmentEffect(GameObject col, Vector3 Pos, float Damage);
}
