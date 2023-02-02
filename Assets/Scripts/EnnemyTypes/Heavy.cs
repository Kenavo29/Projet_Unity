using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heavy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;
    public GameObject effect;

    public int health = 100;

    void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.3)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        //qd l'ennemie arrive a la fin du parcours
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }

    public void TakeDammage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.money += 6;
        GameObject deathEffect = (GameObject)Instantiate(effect, transform.position , Quaternion.identity);
        Destroy(gameObject);
    }
}
