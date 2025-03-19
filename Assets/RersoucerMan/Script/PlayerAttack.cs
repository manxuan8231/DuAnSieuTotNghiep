using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    public RigBuilder rigBuilder;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
           StartCoroutine(WaitRig());

        }
    }
    IEnumerator WaitRig()
    {
        rigBuilder.enabled = false;
        yield return new WaitForSeconds(3);
       rigBuilder.enabled = true;
    }
}
