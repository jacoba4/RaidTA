using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();

        if (Input.GetMouseButtonDown(1))
        {
            Deactivate();
        }
    }

    private void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void Activate(UnitButton button)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = button.Sprite;
        spriteRenderer.color = new Color(button.Color.r, button.Color.g, button.Color.b, 0.5f);
    }

    public void Deactivate()
    {
        spriteRenderer.enabled = false;
    }
}
