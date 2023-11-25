using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject NewGunToSwap;
    private GameObject ActualSwapObject;
    public GameObject GunToSwap;
    public GameObject AugmentHolderObject;
    private PlayerInputs movement;
    void Awake() {
        movement = new PlayerInputs();
    }
    void OnEnable() {
        movement.Enable();
    }

    void OnDisable() {
        if (movement != null) movement.Disable();
    }
    void Start()
    {
        AugmentHolderObject = GameObject.FindWithTag("AugmentHolder");
        movement.Player.Pickup.performed += SwapGuns;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AddAugmentActivation() {
        yield return new WaitForSeconds(0.2f);
        AugmentHolderObject.GetComponent<AugmentHolder>().AddAugments();
    }
    void SwapGuns(InputAction.CallbackContext context) {
        if (NewGunToSwap != null) {
            GameObject.Instantiate(GunToSwap.GetComponent<Shoot>().GunPickup, transform.position, Quaternion.identity);
            Destroy(GunToSwap);
            GunToSwap = (GameObject)GameObject.Instantiate(NewGunToSwap, transform.position, Quaternion.identity);
            Destroy(ActualSwapObject);
            NewGunToSwap = null;
            GunToSwap.transform.parent = transform.GetChild(0).transform.GetChild(0).transform;
            GunToSwap.transform.localPosition = Vector3.zero;
            GunToSwap.transform.localRotation = Quaternion.identity;
            StartCoroutine(AddAugmentActivation());
            
        }
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "PickupGun") {
            NewGunToSwap = col.GetComponent<ThisGun>().Gun;
            ActualSwapObject = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.tag == "PickupGun") {
            NewGunToSwap = null;
        }
    }
}
