using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeSpot : MonoBehaviour
{
    // Start is called before the first frame update
    // public bool Activated;
    public GameObject[] Children;
    public bool Clickable;
    public GameObject ClickableUIObject;
    // public int x;
    // public int y;
    void Start()
    {
        Debug.Log(Clickable);
        if (Clickable) {
            gameObject.SetActive(true);
        }
        else {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateChildren() {
        foreach (GameObject child in Children) {
            child.SetActive(true);
        }
        Clickable = false;
        gameObject.SetActive(false);

        GameObject.FindWithTag("SkillTree").GetComponent<SkillTreeChooser>().DestroyAllCards();
    }
}
