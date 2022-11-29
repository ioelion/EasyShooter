using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage = 20;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag){
            case("Player"):
                PlayerController pc = other.gameObject.GetComponent<PlayerController>();
                pc.TakeDamage(damage);
                Destroy(this.gameObject);
                break;
            case("Enemy"):
                EnemyController ec = other.gameObject.GetComponent<EnemyController>();
                ec.TakeDamage(damage);
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }
}
