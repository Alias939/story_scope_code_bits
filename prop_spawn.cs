//simple script to spawn props in a scene using fiducial markers



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prop_spawn : MonoBehaviour
{
    public GameObject menu;
    public Sprite[] Props;
    public GameObject prop_prefab;
    public GameObject Icon;

    public List<GameObject> spawnedProps = new List<GameObject>();

    private MenuScript menuScript;

    public int Selected;
    public bool previousSelected;
    // Start is called before the first frame update
    void Start()
    {
        previousSelected = true;
        menuScript = menu.GetComponent<MenuScript>();
    }

    // Update is called once per frame
    void Update()
    {

        Selected = menuScript.Selection;

        if (!menu.activeInHierarchy)          //when removing fiducial
        {

            if (previousSelected == false)      //to prevent more than one spawn
            {
                previousSelected = true;

                if (Selected == 3)          //undo section of the menu
                {
                    if (spawnedProps.Count > 0)
                    {  
                        Destroy(spawnedProps[spawnedProps.Count - 1]);        // remove from scene
                        spawnedProps.RemoveAt(spawnedProps.Count - 1);      //remove from list
                    }
                }
                else
                {
                    prop_prefab.GetComponent<SpriteRenderer>().sprite = Props[Selected];       
                    spawnedProps.Add(Instantiate(prop_prefab, transform.position, transform.rotation));     //spawn prop at location
                }
            }
        }
        if (menu.activeInHierarchy)
        {
            
            previousSelected = false;
            Icon.GetComponent<SpriteRenderer>().sprite = Props[Selected];       //update icon of menu in real time
        }

    }
}
