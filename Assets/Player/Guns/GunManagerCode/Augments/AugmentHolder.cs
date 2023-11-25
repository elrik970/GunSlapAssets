using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugmentHolder : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject instantiated;
    public GameObject Bullet;
    public List<GameObject> Augments = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddAugments() {
        Bullet = GameObject.FindWithTag("PlayerAttack");
        Debug.Log(Bullet);
        for (int i=0; i<Bullet.transform.childCount;i++)
        {
            Destroy(Bullet.transform.GetChild(0).gameObject);
        }
        foreach (GameObject ThisAugment in Augments) {
            instantiated = (GameObject)GameObject.Instantiate(ThisAugment, Vector3.zero, Quaternion.identity);
            instantiated.transform.SetParent(Bullet.transform);
        }
    }
}
