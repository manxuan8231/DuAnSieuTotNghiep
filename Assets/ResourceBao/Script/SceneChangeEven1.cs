using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeEven1 : MonoBehaviour
{
    public int scene;
    void Start()
    {
        
    }

   
    void Update()
    {
       
    }
    public void ChangeCutSceneOpen()
    {
        SceneManager.LoadScene(scene);
    }
    
}
