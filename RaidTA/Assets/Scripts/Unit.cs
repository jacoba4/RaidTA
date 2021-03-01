using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public float MeleeRange = 3f;

    [Header("Stats")]
    public int hp;
    public int max_hp;
    public int damage;
    public int healing;
    public float attack_speed;
    public float attack_countdown;
    public float range;
    public int threat_mod;
    public float move_speed;


    [Header("Conditions")]
    public bool is_healer;
    public bool is_player;
    public bool is_dead;
    public bool is_moving;
    
    [Header("Other")]
    public Unit current_target;
    public Vector3 target_destination;
    public int target_distance;
    public Encounter encounter;

    // Start is called before the first frame update
    public virtual void Start()
    {
        attack_countdown = attack_speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_dead)
            return;
        
        if (is_moving) {
            transform.position = Vector3.MoveTowards(transform.position, target_destination, Time.deltaTime * move_speed);
            is_moving = !(transform.position == target_destination);
        } else if (!is_moving && current_target != null) {
            bool isWithinRange = WithinRange();
            MoveWithinRange(isWithinRange);
            TargetAction(isWithinRange);
        }

        if (is_moving || current_target == null) {
            attack_countdown = attack_speed;
        }
    }

    bool WithinRange()
    {
        float distance = Vector3.Distance(transform.position, current_target.transform.position);
        return distance <= range;
    }

    void MoveWithinRange(bool isWithin)
    {
        if (!isWithin && !is_player) {
            Vector3 target_vector = current_target.transform.position - transform.position;
            target_vector.Normalize();
            MoveToLocation(target_vector * (-1 * range) + current_target.transform.position);
        }
    }

    bool TargetAction(bool isWithin)
    {
        if (isWithin) {
            if (attack_countdown <= 0 && !is_healer) {
                AttackUnit(current_target);
                attack_countdown = attack_speed;
                return true;
            } else if (attack_countdown <= 0 && is_healer) {
                HealUnit(current_target);
                attack_countdown = attack_speed;
                return true;
            } else {
                attack_countdown -= Time.deltaTime;
                return false;
            }
        }

        return false;
    }

    int TakeDamage(int damage_amount)
    {
        hp -= damage_amount;
        if (hp <= 0)
            is_dead = true;
        return damage_amount;
    }

    int TakeHealing(int heal_amount)
    {
        hp += heal_amount;
        return heal_amount;
    }

    void AttackUnit(Unit target)
    {
        SendThreatDamage(target.TakeDamage(damage));
    }

    void HealUnit(Unit target)
    {
        SendThreatHealing(target.TakeHealing(healing));
    }

    public void MoveToLocation(Vector3 location)
    {
        target_destination = location;
        is_moving = true;
    }

    public void SetNewTarget(Unit new_target)
    {
        if (new_target != this)
            current_target = new_target;
        
        if (is_player)
            MoveToLocation(new Vector3(transform.position.x,transform.position.y,transform.position.z));
    }

    public void ControlUnit(bool can_control)
    {
        is_player = can_control;
    }

    void CastSpell(int spell_id, Vector3 location)
    {

    }

    void SendThreatDamage(int damage_amount)
    {
        if(current_target is NPC)
        {
            NPC tar = (NPC)current_target;
            tar.AddThreat(this, damage_amount * threat_mod);
        }
    }

    void SendThreatHealing(int heal_amount)
    {
        encounter.BroadcastThreat(this, heal_amount * threat_mod);
    }
}
