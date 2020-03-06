using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkCandy : Consumable {

	string name = "Dark Candy";
  string description = "Heals 40 HP. A red-and-black star that tastes like marshmallows.";
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
