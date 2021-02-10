using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    private Collider vision;
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        vision = GameObject.FindWithTag("VisionCone").
    }
    
    public void FixedUpdate()
    {
        IsPlayerVisible();
    }

    public void SelectTarget()
    {
        
    }

    public bool IsPlayerVisible()
    {

        
        if ()
        {
            Debug.Log("I can See you\n-The enemy");
        }
        else
        {
            Debug.Log("Cant see player");
        }
        return false;
    }
}
