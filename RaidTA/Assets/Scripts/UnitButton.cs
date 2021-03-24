using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;

    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private Color color;

    public int unitCount = 0;
    public int unitID;

    public GameObject UnitPrefab
    {
        get
        {
            return unitPrefab;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    public Color Color
    {
        get
        {
            return color;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer prefabSpriteRenderer = UnitPrefab.GetComponent<SpriteRenderer>();
        this.sprite = prefabSpriteRenderer.sprite;
        this.color = prefabSpriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
