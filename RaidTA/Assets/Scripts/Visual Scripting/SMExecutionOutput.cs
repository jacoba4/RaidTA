using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SMExecutionOutput : SMExecution, IDragHandler, IEndDragHandler
{
    GameObject input;
    LineRenderer lr;
    bool dragging;
    float offset;
    Camera cam;

    protected override void Start()
    {
        base.Start();
        offset = .01f;
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    private void Update()
    {
        //Set first position to the output
        Vector3 pos = transform.position;
        pos.z = offset;
        lr.SetPosition(0, pos);

        //While dragging set second position to mouse
        if (dragging)
        {
            Vector3 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.x = mousepos.x;
            pos.y = mousepos.y;
            lr.SetPosition(1, pos);

            //Also set color of output
            image.color = connected_color;
        }
        else if (connected)
        {
            Vector3 input_pos = input.transform.position;
            pos.x = input_pos.x;
            pos.y = input_pos.y;
            lr.SetPosition(1, pos);
        }
        else
        {
            lr.SetPosition(1, pos);
            image.color = initial_color;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = true;
            if (input != null)
            {
                connected = false;
                input.GetComponent<SMExecutionInput>().Unlink();
                node.SetNext(null);
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = false;
            input = CheckOverInput();
            if (input != null)
            {
                connected = true;
                SMExecutionInput EXin = input.GetComponent<SMExecutionInput>();
                EXin.Link(node);
                node.SetNext(EXin.node);
            }
        }
    }

    public GameObject CheckOverInput()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current) { position = Input.mousePosition };
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.tag == "EXInput")
                {
                    SMExecutionInput input = results[i].gameObject.GetComponent<SMExecutionInput>();
                    return results[i].gameObject;
                }
            }
        }
        return null;
    }
}
