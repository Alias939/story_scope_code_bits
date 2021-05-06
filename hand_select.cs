//script for selecting element after hovering over it for some time with a fiducial marker

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hand_select : MonoBehaviour
{


    private FiducialController fid;
    private Image loader;
    public Animator anim;
    public AudioSource music;

    public bool selected = false;
    public float timer;
    public float speed;
    public bool overlay;

    public float select_time = 1.0f;
    public float sensitivity = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        fid = GetComponent<FiducialController>();
        loader = GetComponentInChildren<Image>();
        Debug.Log(fid.name);
        Debug.Log(loader.name);
    }

    // Update is called once per frame
    void Update()
    {
        speed = fid.Speed;

        //checks if cursor is stopped, and if it's on an object, and if it's visible in the scene
        if (speed < sensitivity && overlay && loader.IsActive())
        {
            //selected tests if it has been selected already so you need to move outside of the trigger box
            if (!selected)
            {
                timer += Time.deltaTime;

                loader.fillAmount = timer / select_time;
            }
            if (timer > select_time && !selected)
            {
                loader.fillAmount = 0;
                selected = true;
                //add interactions here

                anim.SetTrigger("selected");
                music.Play();

            }
            
        }
        else
        {
            timer = -0.5f;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        overlay = true;
        anim = collision.gameObject.GetComponent<Animator>();
        music = collision.gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlay = false;
        anim = null;
        selected = false;
        music = null;
    }
}
