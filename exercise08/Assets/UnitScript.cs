using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public string unitName;
    public string unitDesc;
    public Renderer bodyRend;
    public Color hoverColor;
    public Color selectedColor;
    public Color defaultColor;

    public bool selected = false;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = bodyRend.material.color;

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (selected == false)
        {
            bodyRend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        if (selected == false)
        {
            bodyRend.material.color = defaultColor;
        }
    }

    private void OnMouseDown()
    {
        if (gm.selectedUnit != null)
        {
            // if we're here, something was already selected!
            // 1. Deselect it
            gm.selectedUnit.selected = false;
            gm.selectedUnit.bodyRend.material.color = gm.selectedUnit.defaultColor;
        }
        // 2. Select me!
        selected = true;
        bodyRend.material.color = selectedColor;

        if (gm.selectedUnit == null)
        {
            gm.namePanelAnimator.SetTrigger("fadeIn");
        }

        gm.selectedUnit = this;
        gm.nameText.text = unitName;
        gm.descText.text = unitDesc;
    }
}
