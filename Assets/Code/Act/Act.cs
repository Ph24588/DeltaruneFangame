using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Act {

  string GetName();
  List<string> GetActors();
  string GetDescription();
  void Use();

}
