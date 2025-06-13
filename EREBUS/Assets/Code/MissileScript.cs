using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float projectileSpeed;
    public Vector3 direction = Vector3.forward;
    public Enemy enemy;
    public int damageToDo;
    public float lifeTime;
    public float explosionRadius;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<Enemy>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
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
