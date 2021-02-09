using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThePlayer : MonoBehaviour
{
    public int damageThePl;
    public string tagName;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == tagName)
        {
            DamageCalc();
        }
    }

    public void DamageCalc()
    {
        Helth.health -= damageThePl;
    }
}
