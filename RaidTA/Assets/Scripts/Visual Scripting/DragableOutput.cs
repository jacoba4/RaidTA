using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableOutput : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public SMNode node;
    public string output_type;
    bool dragging;
    bool linked;
    float offset;
    GameObject input;
    public Image output_image;
    LineRenderer lr;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        node = transform.parent.GetComponent<SMNode>();
        offset = .01f;
        output_image = GetComponent<Image>();
        lr = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Set first position to the output
        Vector3 pos = transform.position;
        pos.z = offset;
        lr.SetPosition(0, pos);

        //While dragging set second position to mouse
        if(dragging)
        {
            Vector3 mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.x = mousepos.x;
            pos.y = mousepos.y;
            lr.SetPosition(1, pos);

            //Also set color of output
            output_image.color = lr.colorGradient.colorKeys[0].color;
        }
        else if(linked)
        {
            Vector3 input_pos = input.transform.position;
            pos.x = input_pos.x;
            pos.y = input_pos.y;
            lr.SetPosition(1, pos);
        }
        else
        {
            lr.SetPosition(1, pos);
            output_image.color = Color.white;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = true;
            if(input != null)
            {
                linked = false;
                input.GetComponent<SMInput>().Unlink();
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            dragging = false;
            input = CheckOverInput();
            if(input != null)
            {
                linked = true;
                input.GetComponent<SMInput>().Link(this);
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
                if (results[i].gameObject.tag == "SMInput")
                {
                    SMInput input = results[i].gameObject.GetComponent<SMInput>();
                    Type out_type = Type.GetType(output_type);
                    Type in_type = Type.GetType(input.input_type);
                    if(in_type.IsAssignableFrom(out_type))
                    {
                        return results[i].gameObject;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        return null;
    }
}
