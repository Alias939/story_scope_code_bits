using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_script : MonoBehaviour
{
    public GameObject meat;
    public GameObject salad;
    public GameObject bottom_bun;
    public GameObject top_bun;
    public GameObject tomato;


    public float timer;
    public bool free = false;
    public bool bottom = true;
    public float spawn_rate = 3.0f;
    // Start is called before the first frame update

    void Update()
    {
        if (!free)
        {
            meat.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            salad.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            bottom_bun.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            top_bun.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            tomato.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            
        }
        if (free)
        {
            meat.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            salad.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            bottom_bun.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            top_bun.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            tomato.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            
        }
        //burger


        timer += Time.deltaTime;


        if (timer > spawn_rate)
        {
            int rand = Random.Range(0, 3);
            float coordrand = Random.Range(-8f, 8f);


            transform.position = new Vector3(coordrand, 19.52f, -46f);

            if (bottom)
            {
                Instantiate(bottom_bun, transform.position, transform.rotation);
                bottom = false;
                timer = 0;
            }
            else
            {
                switch (rand)
                {
                    case 0:
                        Instantiate(meat, transform.position, transform.rotation);
                        break;
                    case 1:
                        Instantiate(salad, transform.position, transform.rotation);
                        break;
                    case 2:
                        Instantiate(tomato, transform.position, transform.rotation);
                        break;
                    case 3:
                        Instantiate(top_bun, transform.position, transform.rotation);
                        break;
                }
                timer = 0;
            }
        }


       

    }
}
