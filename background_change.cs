//simple script to change sprite of a background object and mask the change behind an animation
//the menus are controlled by fiducial markers
//in the inspector in unity multiple elements need to be linked

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_change : MonoBehaviour
{
    public GameObject menu;
    public Sprite[] backgrounds;
    public GameObject background;
    public SpriteRenderer renderer;
    public Animator animator;
    public float animation_time;


    public FiducialController fiducialController;


    public GameObject[] previousItem;

    private MenuScript menuScript;

    public int eventSection;
    public int eventCounter;
    public int Selected;
    public int previousSelected;
    public float currentX;
    // Start is called before the first frame update
    void Start()
    {
        renderer = background.GetComponent<SpriteRenderer>();

        menuScript = menu.GetComponent<MenuScript>();
        fiducialController = GetComponent<FiducialController>();
    }

    // Update is called once per frame
    void Update()
    {
        animation_time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;    //to get the time of the animation
        if (!menu.activeInHierarchy)                //when fiducial marker is not visible, the menu disappears
        {
            previousSelected = Selected;            //to prevent the background changing constantly
            Selected = menuScript.Selection;
            if (Selected != previousSelected)
            {
                animator.SetTrigger("transition");      //trigger animation
                


            }
            if (animation_time >0.5 & animation_time <0.7)      //when animation is halfway through
            {
                renderer.sprite = backgrounds[Selected];        //trigger change based on selected background
            }
        }
    }

}
