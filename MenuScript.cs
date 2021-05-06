using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    [Range(5, 10)]
    public int Sensitivity;

    public FiducialController fiducialController;
    public float currentAngle;
    public int Selection;
    private int previousSelection;

    public bool multipleMenu = false;
    public float currentY;
    public int currentMenu;

    public GameObject[] Menus;

    public List<GameObject> menuItems = new List<GameObject>();

    
    private MenuPieceScript menuPiece;
    private MenuPieceScript previousMenuPiece;

    // Start is called before the first frame update
    void Start()
    {
        Sensitivity = 4;
        fiducialController = GetComponentInParent<FiducialController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = fiducialController.AngleDegrees;

        if (multipleMenu)
        {
            currentY = fiducialController.ScreenPosition.y;
            if (currentY<0.33 & currentMenu!=1)
            {
                menuItems.Clear();
                foreach (Transform child in Menus[0].gameObject.transform)
                {
                    menuItems.Add(child.gameObject);
                }
                currentMenu = 1;
            }
            if (currentY >= 0.33 & currentY<0.66 & currentMenu != 2)
            {
                menuItems.Clear();
                foreach (Transform child in Menus[1].gameObject.transform)
                {
                    menuItems.Add(child.gameObject);
                }
                currentMenu = 2;
            }
            if (currentY >= 0.66 & currentMenu != 3)
            {
                menuItems.Clear();
                foreach (Transform child in Menus[2].gameObject.transform)
                {
                    menuItems.Add(child.gameObject);
                }
                currentMenu = 3;
            }

        }

        Selection = (int)(currentAngle / (45/Sensitivity));
        Selection %= 8;

        //if(Selection != previousSelection)
        //{
        foreach(GameObject previousMenuPiece in menuItems)
        {
            menuPiece = previousMenuPiece.GetComponent<MenuPieceScript>();
            menuPiece.Deselect();
        }
        
        previousSelection = Selection;

        menuPiece = menuItems[Selection].GetComponent<MenuPieceScript>();
        menuPiece.Select();
        
       // }

    }
}
