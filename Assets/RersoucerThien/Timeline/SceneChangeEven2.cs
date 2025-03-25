using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int scene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CooldownChangeScene());
    }
    public IEnumerator CooldownChangeScene()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(scene);
    }
}
