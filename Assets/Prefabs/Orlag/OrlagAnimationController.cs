using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class OrlagAnimationController : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

  

    public void Attack()
    {
        var randomAnim = Random.Range(0,3);

        switch (randomAnim)
        {
            case 1:
                anim.SetTrigger("Attack1");
                break;
            case 2:
                anim.SetTrigger("Attack2");
                break;
        }
    }

    public void Walk()
    {
        anim.SetTrigger("Walk");
    }

    public void Run()
    {
        anim.SetTrigger("Run");
    }
    public void Idle()
    {
        var randomAnim = Random.Range(0, 3);

        switch (randomAnim)
        {
            case 1:
                anim.SetTrigger("Idle1");
                break;
            case 2:
                anim.SetTrigger("Idle2");
                break;
        }
    }

    public void Death()
    {
        anim.SetBool("Dead",true);
    }
}
