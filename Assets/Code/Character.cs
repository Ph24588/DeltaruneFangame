using UnityEngine;
using System.Collections;

public class Character
{
  public string Name;
  public float MaxHp;
  public float CurrentHp;
  public float Atk;
  public float Def;

  public Character(string name, float maxHp, float currentHp, float atk, float def)
  {
    this.Name = name;
    this.MaxHp = maxHp;
    this.CurrentHp = currentHp;
    this.Atk = atk;
    this.Def = def;
  }

  public void TakeDamage(int damage)
  {
    CurrentHp -= damage - Def;
  }

  public void RestoreHealth(int health)
  {
    CurrentHp = Mathf.Min(MaxHp, CurrentHp + health);
  }
}
