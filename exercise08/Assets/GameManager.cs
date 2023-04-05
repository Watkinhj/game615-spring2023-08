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

        // Code for movement.
        if (Input.GetMouseButtonDown(1))
        {
            // Create a ray from where the player clicked into the 3d world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {

                // If we get in here, it means that we hit something. 'hit' is
                // an object that Unity filled with all of the info about what the Raycast hit.
                //
                // Check to make sure we actually clicked on the ground. Don't forget to
                // create and add the tag "Ground" to your ground!
                if (hit.collider.CompareTag("Ground"))
                {
                    // Set the destination to where the player clicked.
                    selectedUnit.nma.SetDestination(hit.point);
                }
            }
        }
    }
}
