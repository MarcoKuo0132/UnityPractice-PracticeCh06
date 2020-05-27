using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Explosion;
    public AudioClip sExplosion;
    public PhysicMaterial material;

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        GameObject NewExplosion = (GameObject)Instantiate(Explosion, transform.position, Quaternion.identity);

        switch (other.tag)
        {
            case "Barrel":
                other.material = material;
                break;
            case "Enemy":
                other.gameObject.GetComponent<Enemy>().attacked();
                break;
            case "Player":
                other.GetComponent<Player>().attacked();
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
