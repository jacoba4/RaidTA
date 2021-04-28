using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SMExecution : MonoBehaviour
{
    public SMNode node;
    protected bool connected;
    protected Image image;
    public Color initial_color;
    public Color connected_color;
  
    protected virtual void Start()
    {
        image = GetComponent<Image>();
        initial_color = new Color(0.5330188f, 0.548627f,1f);
        connected_color = new Color(0.25f, 0.2752099f, 1f);
        node = GetComponentInParent<SMNode>();
    }
    public virtual void Link()
    {
        connected = true;
        SetColor(connected_color);
    }

    public virtual void Unlink()
    {
        connected = false;
        SetColor(initial_color);
    }
    private void SetColor(Color c)
    {
        image.color = c;
    }
}
