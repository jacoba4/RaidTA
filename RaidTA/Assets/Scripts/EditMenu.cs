using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Unit unit;

    public InputField hp;
    public InputField damage;
    public InputField attack_speed;
    public InputField range;
    public InputField move_speed;
    public Button delete;

    void Start()
    {
        Interactable(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadUnit(Unit u)
    {
        if (unit != null)
        {
            unit.ControlUnit(false);
        }
        Interactable(true);
        unit = u;
        u.ControlUnit(true);
        hp.text = u.max_hp.ToString();
        if (u.is_healer)
        {
            damage.text = u.healing.ToString();
        }
        else
        {
            damage.text = u.damage.ToString();
        }
        attack_speed.text = u.attack_speed.ToString("F1");
        range.text = u.range.ToString("F1");
        move_speed.text = u.move_speed.ToString("F1");
    }

    public void EditUnit()
    {
        unit.max_hp = int.Parse(hp.text);
        if(unit.is_healer)
        {
            unit.healing = int.Parse(damage.text);
        }
        else
        {
            unit.damage = int.Parse(damage.text);
        }
        unit.attack_speed = float.Parse(attack_speed.text);
        unit.range = float.Parse(range.text);
        unit.move_speed = float.Parse(move_speed.text);
    }

    public void Interactable(bool b)
    {
        delete.interactable = hp.interactable = damage.interactable = attack_speed.interactable = range.interactable = move_speed.interactable = b;
    }

    public void Clear()
    {
        unit = null;
        hp.text = damage.text = attack_speed.text = range.text = move_speed.text = "";
    }

    

    public void SetHealth()
    {
        if(unit == null) { return; }
        unit.max_hp = int.Parse(hp.text);
        unit.hp = int.Parse(hp.text);
    }

    public void SetDamage()
    {
        if (unit == null) { return; }
        if (unit.is_healer)
        {
            unit.healing = int.Parse(damage.text);
        }
        else
        {
            unit.damage = int.Parse(damage.text);
        }
    }

    public void SetAttackSpeed()
    {
        if (unit == null) { return; }
        unit.attack_speed = float.Parse(attack_speed.text);
    }
    public void SetRange()
    {
        if (unit == null) { return; }
        unit.range = float.Parse(range.text);
    }
    public void SetMoveSpeed()
    {
        if (unit == null) { return; }
        unit.move_speed = float.Parse(move_speed.text);
    }
}
