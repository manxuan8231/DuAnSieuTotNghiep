using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLine1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(0);
    }
}
