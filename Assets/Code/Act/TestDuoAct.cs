using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDuoAct : Act
{
  string description = "Test act for Kris, Susie";
  string name = "TestDuoAct";
  public string GetName()
  {
    return name;
  }

  public List<string> GetActors()
  {
    List<string> actors = new List<string>();
    actors.Add("Kris");
    actors.Add("Susie");
    return actors;
  }

  public string GetDescription()
  {
    return description;
  }

  public void Use()
  {

  }
}
