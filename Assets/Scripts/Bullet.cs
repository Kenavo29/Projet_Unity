using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject particulePrefab;

    public float speed = 70f;

    public float explosionRadius = 0;

    public int damage = 50;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    //Gestion du suivi de la cible par le projectile
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
   
    //gestion de l'impact du projectile
    void HitTarget()
    {
        GameObject particule = (GameObject)Instantiate(particulePrefab, transform.position, transform.rotation);
        Destroy(particule, 2f);

        //Prise en compte de l'explosion du missile
        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
       
    }
    //gestion des dégats infligé par le projectile
    void Damage(Transform enemy)
    {
        Ennemy e = enemy.GetComponent<Ennemy>();
        if(e != null)
        {
            e.TakeDammage(damage);
        }
        else
        {
            Debug.Log("Erreur pas de script ennemy sur l'ennemy");
        }
        
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
