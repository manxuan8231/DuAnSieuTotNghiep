using System.Collections;
using UnityEngine;

public class CameraForest : MonoBehaviour
{
   

    private void Start()
    {

       
    }

    private void Update()
    {
        StartCoroutine(CooldownRotation());    
    }
    IEnumerator CooldownRotation()
    {
        CameraFollowHead cameraFollowHead = FindAnyObjectByType<CameraFollowHead>();
        cameraFollowHead.rotation = false;
        yield return new WaitForSeconds(7);
        cameraFollowHead.rotation = true;
    }
}
