using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkmark : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Enemies;
    public SpriteRenderer CheckmarkSprite;
    private bool AllDead = false;
    void Start()
    {
        CheckmarkSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!AllDead) {
            StartCoroutine(CheckKilled());
        }
    }
    IEnumerator CheckKilled() {
        bool dead = true;
        foreach (GameObject enemy in Enemies) {
            if (enemy != null) {
                dead = false;
            }
        }
        if (dead) {
            AllDead = true;
            CheckmarkSprite.enabled = !CheckmarkSprite.enabled;
        }
        yield return new WaitForSeconds(10f);
    }
}
