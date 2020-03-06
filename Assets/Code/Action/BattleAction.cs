using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction {

  public enum ActionType
  {
    FIGHT,
    ACT,
    MAGIC,
    ITEM,
    SPARE,
    DEFEND
  }
  public ActionType Type;
  public Character Actor;
  public Character Target;
  public Consumable Cons;

  public BattleAction(ActionType type, Character actor, Character target, Consumable cons)
  {
    this.Type = type;
    this.Actor = actor;
    this.Target = target;
    this.Cons = cons;
  }

}
