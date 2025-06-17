using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float projectileSpeed;
    public Vector3 direction = Vector3.forward;
    public GameObject enemy;
    public int damageToDo;
    public float lifeTime;
    public float explosionRadius;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {        
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other == GameObject.FindWithTag("Enemy").GetComponent<Collider>())
        {
            enemy = other.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            transform.LookAt(enemy.transform);
        }        
        transform.Translate(direction * projectileSpeed * Time.deltaTime);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            explosion.Play();
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.GetComponent<Enemy>().TakeDamage(damageToDo);
                    Destroy(gameObject);
                }
            }
        }
    }    
}
