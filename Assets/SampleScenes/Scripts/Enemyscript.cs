using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyscript : MonoBehaviour
{   public Transform target;
    NavMeshAgent agent;

    int enemyHP = 3;
    // Start is called before the first frame update
    void Start()
    {   GameObject player =GameObject.Find("FPSController");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    void Damage()
    {
        enemyHP -= 1;
    if (enemyHP <= 0)
        {
        Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FPSController")
        {
            other.gameObject.SendMessage("PlayerDamage");
            Destroy(this.gameObject);
        }

    }
}
