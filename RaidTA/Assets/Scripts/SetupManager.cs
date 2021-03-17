using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetupManager : MonoBehaviour
{
    public UnitButton clickedButton { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceUnit();
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.clickedButton = null;
        }
    }

    public void PickUnit(UnitButton unitButton)
    {
        this.clickedButton = unitButton;
    }

    private void PlaceUnit()
    {
        if (!EventSystem.current.IsPointerOverGameObject() && this.clickedButton != null)
        {
            this.clickedButton.unitCount += 1;
            GameObject unit = (GameObject) Instantiate(this.clickedButton.UnitPrefab, transform.position, Quaternion.identity);

            Unit unitScript = unit.GetComponent<Unit>();
            if (unitScript != null){
                unitScript.number.text = this.clickedButton.unitCount.ToString();
            }
            
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 1;
            unit.transform.position = worldPos;
        }
    }
}
