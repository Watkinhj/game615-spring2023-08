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
    public UnityEngine.AI.NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = bodyRend.material.color;

        GameObject gmObj = GameObject.Find("GameManagerObject");
        gm = gmObj.GetComponent<GameManager>();

        nma = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Here's the code for the movement.
        Vector3 rayStartPos = transform.position;
        // Raise the position up 1.5 units
        rayStartPos.y = rayStartPos.y + 1.5f;
        Debug.DrawRay(rayStartPos, transform.forward * 10);
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
