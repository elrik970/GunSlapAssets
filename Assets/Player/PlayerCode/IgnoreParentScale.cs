using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreParentScale : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;
        Vector3 ParentScale = Parent.localScale;
        transform.localScale = new Vector3(scale.x/ParentScale.x,scale.y/ParentScale.y,scale.z/ParentScale.z);
    }
    void LateUpdate() {
        // Vector3 scale = transform.localScale;
        // Vector3 ParentScale = Parent.localScale;
        // transform.localScale = new Vector3(scale.x/ParentScale.x,scale.y/ParentScale.y,scale.z/ParentScale.z);
    }
}
