using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject TankEmitter;

    int anglenow = 0;
    int top_anglenow = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        view();
        move();
        fire();
    }

    void view()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            float vertical_size = Input.mousePosition.y - Screen.height / 2.0f;
            float horizontal_size = Input.mousePosition.x - Screen.width / 2.0f;

            if (anglenow < (int)(Mathf.Atan(vertical_size / 100f) * Mathf.Rad2Deg) & anglenow < 45)
            {
                TankEmitter.transform.Rotate(new Vector3(0, 1, 0), 1);
                anglenow++;
            }
            else if (anglenow > (int)(Mathf.Atan(vertical_size / 100f) * Mathf.Rad2Deg) & anglenow > -10)
            {
                TankEmitter.transform.Rotate(new Vector3(0, -1, 0), 1);
                anglenow--;
            }

            if (top_anglenow < (int)(Mathf.Atan(horizontal_size / 100f) * Mathf.Rad2Deg) & top_anglenow < 90)
            {
                TankEmitter.transform.Rotate(new Vector3(0, 1, 0), 1);
                top_anglenow++;
            }
            else if (top_anglenow > (int)(Mathf.Atan(horizontal_size / 100f) * Mathf.Rad2Deg) & top_anglenow > -90)
            {
                TankEmitter.transform.Rotate(new Vector3(0, -1, 0), 1);
                top_anglenow--;
            }
        }
    }

    void move()
    {
        
    }

    void fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = (GameObject)Instantiate(Bullet);

            newBullet.transform.position = TankEmitter.transform.position + TankEmitter.transform.right * 2;

            newBullet.GetComponent<Rigidbody>().AddForce(TankEmitter.transform.right * 1000);
        }
    }

    public void attacked()
    {
        print(this.name + " hitted ");
    }
}
