using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SMInput : MonoBehaviour
{
    public string input_type;
    protected bool connected;
    protected DragableOutput output;
    protected Image input_image;
    
    protected virtual void Start()
    {
        input_image = GetComponent<Image>();
    }

    public virtual void Link(DragableOutput o)
    {
        connected = true;
        output = o;
        SetColor(o.output_image.color);
    }


    public virtual void Unlink()
    {
        connected = false;
        output = null;
        SetColor(Color.white);
    }

    private void SetColor(Color c)
    {
        input_image.color = c;
    }
}
