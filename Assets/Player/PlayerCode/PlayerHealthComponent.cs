using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    public Animator animator;
    
    private bool Damageable = true;
    public string SceneToLoadName;
    public AudioSource HitSoundFx;
    public float Health;
    [SerializeField] private float InvizTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Destroy(gameObject);
            if (gameObject.tag == "Player") {
                string currentSceneName = SceneToLoadName;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }
    public void Damage(float DamageAmount) {
        if (Damageable) {
            if (HitSoundFx != null) {
                HitSoundFx.Play();
            }
            StartCoroutine(Inviz(DamageAmount));
            Health-=DamageAmount;
            if (animator != null) {
                animator.Play("HitAnim");
            }
            
        }
    }
    IEnumerator Inviz(float DamageAm)
    {
        
        if (InvizTime != 0&&DamageAm != 0) {
            Damageable = false;
            yield return new WaitForSeconds(InvizTime);
            Damageable = true;
        }
        else {
            Damageable = true;
        }
        
    }
}
