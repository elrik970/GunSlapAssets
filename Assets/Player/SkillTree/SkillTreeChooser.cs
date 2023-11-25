using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeChooser : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] SpotsToPutSkills;
    private GameObject instantiated;
    public GameObject Canvas;
    public List<SkillTreeSpot> ChosenUpgrades = new List<SkillTreeSpot>();
    private int ChosenUpgrade;
    private List<SkillTreeSpot> Skills;
    void Start()
    {
        // DontDestroyOnLoad(gameObject);
        Canvas = GameObject.FindWithTag("Canvas");
        // GetThreeSkills();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetThreeSkills() {
        

        Skills = new List<SkillTreeSpot>(GetComponentsInChildren<SkillTreeSpot>());
        Canvas = GameObject.FindWithTag("Canvas");
        if (Skills.Count < 1) {
            Debug.LogWarning("Out Of Upgrades To Choose From");
        }
        else {
            Time.timeScale = 0f;
            ChosenUpgrades = new List<SkillTreeSpot>();
            ChosenUpgrade = Random.Range(0, Skills.Count);
            ChosenUpgrades.Add(Skills[ChosenUpgrade]);
            Skills.RemoveAt(ChosenUpgrade);

            if (Skills.Count > 0) {
                ChosenUpgrade = Random.Range(0, Skills.Count);
                ChosenUpgrades.Add(Skills[ChosenUpgrade]);
                Skills.RemoveAt(ChosenUpgrade);
            }

            if (Skills.Count > 0) {
                ChosenUpgrade = Random.Range(0, Skills.Count);
                ChosenUpgrades.Add(Skills[ChosenUpgrade]);
                Skills.RemoveAt(ChosenUpgrade);
            }

            int i = 0;
            foreach (SkillTreeSpot SkillTree in ChosenUpgrades) {
                instantiated = (GameObject)GameObject.Instantiate(SkillTree.ClickableUIObject, SpotsToPutSkills[i], Quaternion.identity);
                
                instantiated.transform.SetParent(Canvas.transform,false);
                
                GivePet pet = instantiated.GetComponent<GivePet>();
                if (pet != null) {
                    pet.instantiater = SkillTree.gameObject;
                    // Upgrades.Add(pet.gameObject);
                }
                ApplyAugments augment = instantiated.GetComponent<ApplyAugments>();
                if (augment != null) {
                    augment.instantiater = SkillTree.gameObject;
                    
                }
                
                i++;
            }
            // Debug.Log(ChosenUpgrades);
        }
    }
    public void DestroyAllCards() {
        Time.timeScale = 1f;
        GameObject[] Upgrades = GameObject.FindGameObjectsWithTag("Upgrade");
        foreach (GameObject Card in Upgrades)  
        {  
            Destroy(Card);
        }  
    }
}
