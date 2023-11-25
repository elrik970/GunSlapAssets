using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class NextRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public string OtherScene;
    public static event Action Change;
    public GameObject ObjectToMove;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            // SceneManager.MoveGameObjectToScene(col.gameObject, SceneManager.GetSceneByName(OtherScene));
            // SceneManager.LoadScene(OtherScene, LoadSceneMode.Single);
            col.transform.position = Vector3.zero;
            StartCoroutine(LoadYourAsyncScene(col.gameObject));
            
        }
    }

    IEnumerator LoadYourAsyncScene(GameObject m_MyGameObject)
    {
        // Set the current Scene to be able to unload it later
        
        // yield return new WaitForSeconds(0.1f);
        Scene currentScene = SceneManager.GetActiveScene();
        ObjectToMove.transform.SetParent(null);
        Destroy(Camera.main.gameObject);

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(OtherScene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        // while (!asyncLoad.isDone)
        // {
        //     yield return null;
        // }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(ObjectToMove, SceneManager.GetSceneByName(OtherScene));
        
        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("SkillTree"), SceneManager.GetSceneByName(OtherScene));
        
        GameObject instantiatedGameObject = Instantiate(m_MyGameObject, Vector3.zero,Quaternion.identity,ObjectToMove.transform);
        // move instantiated gameObject to root of scene
        instantiatedGameObject.transform.SetParent(null);
        // Destroy(ObjectToMove);
        // Unload the previous Scene

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        SceneManager.UnloadSceneAsync(currentScene);

        
    }
}
