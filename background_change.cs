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
        animation_time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (!menu.activeInHierarchy)
        {
            previousSelected = Selected;
            Selected = menuScript.Selection;
            if (Selected != previousSelected)
            {
                animator.SetTrigger("transition");
                


            }
            //not very pretty wip
            if (animation_time >0.5 & animation_time <0.7)
            {
                renderer.sprite = backgrounds[Selected];
            }
        }
    }

}
