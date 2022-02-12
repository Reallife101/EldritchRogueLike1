using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTowardsPlayer : MonoBehaviour
{
    public NavMeshAgent agent;
    public float minDistance = 25f;
    public float maxDistance = 40f;

    [SerializeField] bool followRegardless;
    [SerializeField] float randomDistance;

    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        RaycastHit hit;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (followRegardless)
        {
            agent.SetDestination(player.transform.position + randomOffset());
        }
        else
        if (dist > minDistance && dist < maxDistance && Physics.Raycast(transform.position + Vector3.up, transform.forward, out hit, maxDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                agent.SetDestination(player.transform.position + randomOffset());
            }
        }
    }

    Vector3 randomOffset()
    {
        return new Vector3(Random.Range(0, randomDistance), Random.Range(0, randomDistance), Random.Range(0, randomDistance));
    }
}
