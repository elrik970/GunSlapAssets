using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLevelUp : MonoBehaviour
{
    // Start is called before the first frame update
    private bool Upgradable = true;
    public AudioSource LevelUpSound;
    public SkillTreeChooser SkillTree;
    void Start()
    {
        LevelUpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            if (Upgradable) {
                if (LevelUpSound != null) {
                    LevelUpSound.Play();
                }
                SkillTree = GameObject.FindWithTag("SkillTree").GetComponent<SkillTreeChooser>();
                SkillTree.GetThreeSkills();
                Upgradable = false;
                Destroy(gameObject,0.3f);
            }
        }
    }
}
