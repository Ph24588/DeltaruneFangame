using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMagic : Consumable
{

  string name = "Test Magic";
  string description = "Test magic";
  string type = "hero";

  public string GetName()
  {
    return name;
  }

  public string GetDescription()
  {
    return description;
  }

  public string GetType()
  {
    return type;
  }

  public void Use(Character character)
  {
    character.RestoreHealth(40);
  }
}
