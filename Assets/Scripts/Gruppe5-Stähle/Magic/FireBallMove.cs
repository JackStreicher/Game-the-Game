using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : MonoBehaviour
{
    public float speedOfTheFB;
    public float speedOfFireMode;

    void Update()
    {
        //wenn speed nicht null ist dann ...
        if (speedOfTheFB != 0)
        {
            //... wird der Fireball in Bewegung gesetzt (die Geschwindigkeit wird multipliziert)
            transform.position += transform.forward * (speedOfTheFB * Time.deltaTime);
        }
        else
        {
            //Um einen Fehler zu vermeiden
            Debug.Log("The FireBall needs a amount of speed!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        speedOfTheFB = 0;               //wenn die Collision passiert ist, dann fliegt der Feuerball nicht mehr bzw steht und ...
        Destroy(gameObject);            //... wird dann schließlich zerstört
    }
}
