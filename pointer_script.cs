//script for changing game scenes after selecting element with fiducial marker

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pointer_script : MonoBehaviour
{


    private FiducialController fid;
    private Image loader;
    private GameObject game;

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
                SceneManager.LoadScene(sceneName: game.name);

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
        game = collision.gameObject;

       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlay = false;
        game = null;
        selected = false;
    }
}
