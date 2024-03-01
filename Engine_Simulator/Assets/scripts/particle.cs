using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class particle : MonoBehaviour
{
    //[SerializeField] Rigidbody rb;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float range;
    [SerializeField] Transform centrePoint;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 random = new Vector3(Random.Range(-9, -6.3f), Random.Range(3, 9), Random.Range(-6.9f, -3.9f));
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, random, Time.deltaTime * 1);

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
