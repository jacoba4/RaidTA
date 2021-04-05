using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetupManager : MonoBehaviour
{
    [System.Serializable]
    public struct UnitEntry
    {
        public int unitID;
        public Vector3 unitPos;
    }

    public UnitButton clickedButton { get; private set; }
    private List<Unit> unitList;
    private List<UnitEntry> unitEntries;
    private int partyCount = 0;
    private int partyLimit = 6;
    EditMenu editMenu;

    protected test_encounter encounter;

    // Start is called before the first frame update
    void Start()
    {
        unitList = new List<Unit>();
        unitEntries = new List<UnitEntry>();
        editMenu = GameObject.Find("EditMenu").GetComponent<EditMenu>();
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
        if (this.clickedButton == null){ return; }

        if (clickedButton.UnitPrefab == null)
        {
            //This means EditButton is selected
            RaycastHit hitData;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitData))
            {
                if(hitData.transform.tag == "Player")
                {
                    editMenu.LoadUnit(hitData.transform.GetComponent<Unit>());
                }
            }       
        }
        else if (!EventSystem.current.IsPointerOverGameObject() && this.partyCount < this.partyLimit)
        {
            this.clickedButton.unitCount += 1;
            GameObject unit = (GameObject) Instantiate(this.clickedButton.UnitPrefab, transform.position, Quaternion.identity);

            Unit unitScript = unit.GetComponent<Unit>();
            if (unitScript != null){
                unitScript.number.text = (this.partyCount+1).ToString();
                unitScript.enabled = false;
            }

            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 1;
            unit.transform.position = worldPos;

            unitList.Add(unitScript);
            unitEntries.Add(new UnitEntry() { unitID = this.clickedButton.unitID, unitPos = unit.transform.position });
            this.partyCount += 1;
        }
    }

    public void StartRaid()
    {
        GameObject tenc = new GameObject("test_encounter");
        encounter = tenc.AddComponent(typeof(test_encounter)) as test_encounter;
        encounter.Init(this.unitList);

        GameObject UIObj = GameObject.Find("Canvas");
        Canvas UICanvas = UIObj.GetComponent<Canvas>();
        UICanvas.enabled = false;
        this.GetComponent<SetupManager>().enabled = false;
    }

    public void DeleteUnit()
    {
        if(editMenu.unit == null) { return; }
        Unit u = editMenu.unit;
        unitList.Remove(u);
        partyCount--;
        for(int i = 0; i < partyCount; i++)
        {
            unitList[i].number.text = (i+1).ToString();
        }
        Destroy(u.gameObject);
        editMenu.Interactable(false);
        editMenu.Clear();
    }
}
