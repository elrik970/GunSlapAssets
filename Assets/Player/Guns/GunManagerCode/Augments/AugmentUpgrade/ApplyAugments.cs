using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAugments : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThisAugment;
    private GameObject instantiated;
    public GameObject instantiater;
    public GameObject AugmentHolderObject;
    void Start()
    {
        AugmentHolderObject = GameObject.FindWithTag("AugmentHolder");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ApplyAugment() {
        AugmentHolderObject.GetComponent<AugmentHolder>().Augments.Add(ThisAugment);
        AugmentHolderObject.GetComponent<AugmentHolder>().AddAugments();
        instantiater.GetComponent<SkillTreeSpot>().ActivateChildren();

        

        Destroy(gameObject);
    }
}
