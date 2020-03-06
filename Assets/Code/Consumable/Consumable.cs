using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Consumable
{
  string GetName();
  string GetDescription();
  string GetType(); // enemy or hero
  void Use(Character character);
}
