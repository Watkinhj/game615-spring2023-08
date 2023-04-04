using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UnitScript selectedUnit;

    public TMP_Text nameText;
    public TMP_Text descText;

    public Animator namePanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray) == false)
            {
                if (selectedUnit != null)
                {
                    selectedUnit.selected = false;
                    selectedUnit.bodyRend.material.color = selectedUnit.defaultColor;

                    selectedUnit = null;

                    namePanelAnimator.SetTrigger("fadeOut");
                }
            }
        }
    }
}
