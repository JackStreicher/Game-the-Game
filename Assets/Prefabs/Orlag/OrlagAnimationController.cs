using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class OrlagAnimationController : MonoBehaviour
{

    protected bool isDead = false;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }





    public virtual void Attack()
    {
        var randomAnim = Random.Range(0, 5);

        switch (randomAnim)
        {
            case 1:
                anim.SetTrigger("Attack1");
                break;
            case 2:
                anim.SetTrigger("Attack2");
                break;
            case 3:
                anim.SetTrigger("Attack3");
                break;
            case 4:
                anim.SetTrigger("Attack4");
                break;

        }
    }

    public virtual void Walk()
    {
        anim.SetTrigger("Walk");
    }

    public virtual void Run()
    {
        anim.SetTrigger("Run");
    }
    public virtual void Idle()
    {
        var randomAnim = Random.Range(0, 5);

        switch (randomAnim)
        {
            case 1:
                anim.SetTrigger("Idle1");
                break;
            case 2:
                anim.SetTrigger("Idle2");
                break;
            case 3:
                anim.SetTrigger("Idle3");
                break;
            case 4:
                anim.SetTrigger("Idle4");
                break;
        }
    }

    public virtual void TakingDamage()
    {
        anim.SetTrigger("TakingDamage");
    }

    public virtual void CombatStance()
    {
        anim.SetTrigger("CombatStance");
    }

    public virtual void Death()
    {
        if (!isDead) {
            anim.SetBool("Dead", true);
            isDead = true;
            var animRand = Random.Range(0, 2);

            Debug.Log(animRand);
            switch (animRand)
            {
                case 0:
                    anim.SetTrigger("Death1");
                    break;

                case 1:
                    anim.SetTrigger("Death2");
                    break;


            }
        }
    }


}
