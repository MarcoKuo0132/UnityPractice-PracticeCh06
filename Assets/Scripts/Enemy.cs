using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject emitter;
    bool targetfound;
    bool forward;
    bool turn;
    int linearcount;
    int angularcount;
    RaycastHit hit;
    private float period1 = 0.0f;
    private float period2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetfound)
        {
            if (linearcount < 200 && forward)
            {
                transform.Translate(transform.forward * 0.125f, Space.World);
                linearcount++;
            }

            if (linearcount == 200 && !turn)
            {
                turn = true;
                forward = false;
            }

            if (turn)
            {
                transform.Rotate(new Vector3(0, 1, 0), 2.0f);
                angularcount++;
            }

            if (angularcount == 90)
            {
                angularcount = 0;
                linearcount = 0;
                turn = false;
                forward = true;
            }
        }

        if (Physics.Raycast(transform.position, transform.forward,out hit,50.0f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                period2 = Time.time;
                if (period2 - period1 > 2.0f)
                {
                    targetfound = true;
                    GameObject newBullet = (GameObject)Instantiate(Bullet);
                    newBullet.transform.position = emitter.transform.position + emitter.transform.right * 2;
                    newBullet.GetComponent<Rigidbody>().AddForce(emitter.transform.right * 1000);
                    period1 = Time.time;
                }
            }
            else
            {
                targetfound = false;
            }
        }
        else
        {
            targetfound = false;
        }
    }

    public void attacked()
    {
        print(this.name + " hitted ");
    }
}
