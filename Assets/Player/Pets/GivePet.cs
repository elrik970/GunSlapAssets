using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThisPet;
    private GameObject instantiated;
    public GameObject instantiater;
    public GameObject PetHolderObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPet() {
        PetHolderObject = GameObject.FindWithTag("AllPetsHolder");
        instantiated = (GameObject)GameObject.Instantiate(ThisPet, Vector3.zero, Quaternion.identity);
        instantiated.transform.SetParent(PetHolderObject.transform, false);
        instantiater.GetComponent<SkillTreeSpot>().ActivateChildren();


        Destroy(gameObject);
    }
}
