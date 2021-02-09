using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThePlayer : MonoBehaviour
{
    public int damageThePl;
    public string tagName;
    bool isDamaged = false;
    public static int plDamageCalc;
    public static bool plDamage = false;
    // Start is called before the first frame update

    public void Start()
    {
        plDamageCalc = damageThePl;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagName)
        {
            isDamaged = true;
            plDamage = isDamaged;
        }
    }
    private void Update()
    {
        if (isDamaged)
        {
            DamageCalc();
        }
    }

    public void DamageCalc()
    {
        
        Helth.health -= damageThePl;
        isDamaged = false;
        Debug.Log("bis hier her");
    }
}
