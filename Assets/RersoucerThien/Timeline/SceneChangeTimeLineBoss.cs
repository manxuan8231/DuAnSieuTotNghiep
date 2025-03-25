using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTimeLineBoss : MonoBehaviour
{
    public string scene;
    public TextMeshProUGUI textEven;
    void Start()
    {
        textEven.enabled = false;        
    }

   
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CoolDownChange() );
        }
    }
    public IEnumerator CoolDownChange()
    {
        textEven.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
