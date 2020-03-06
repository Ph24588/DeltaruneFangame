using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleQueue {

  Queue<BattleAction> ActionQueue;
  Consumable KrisItem;
  Consumable SusieItem;
  Consumable RalseiItem;
  Consumable RalseiMagic;
  Consumable SusieMagic;

  bool SkipRalsei;
  bool SkipSusie;

  public BattleQueue()
  {
    ActionQueue = new Queue<BattleAction>();
    SkipRalsei = false;
    SkipSusie = false;
  }

  public void QueueFight(Character actor, Character target)
  {
    BattleAction action = new BattleAction(
      BattleAction.ActionType.FIGHT,
      actor,
      target,
      null);
    ActionQueue.Enqueue(action);
  }

  public void QueueAct(Character actor, Character target, Consumable act)
  {
    BattleAction action = new BattleAction(
      BattleAction.ActionType.ACT,
      actor,
      target,
      act);
    ActionQueue.Enqueue(action);
  }

  public void QueueMagic(Character actor, Character target)
  {
    Consumable magic;
    if (actor.Name.Equals("Susie"))
    {
      magic = SusieMagic;
    }
    else
    {
      magic = RalseiMagic;
    }
    BattleAction action = new BattleAction(
      BattleAction.ActionType.MAGIC,
      actor,
      target,
      magic);
    ActionQueue.Enqueue(action);
  }

  public void QueueItem(Character actor, Character target)
  {
    Consumable item;
    if (actor.Name.Equals("Kris"))
    {
      item = KrisItem;
    } else if (actor.Name.Equals("Susie"))
    {
      item = SusieItem;
    } else
    {
      item = RalseiItem;
    }
      BattleAction action = new BattleAction(
      BattleAction.ActionType.ITEM,
      actor,
      target,
      item);
    ActionQueue.Enqueue(action);
  }

  public void QueueSpare(Character actor, Character target)
  {
    BattleAction action = new BattleAction(
      BattleAction.ActionType.SPARE,
      actor,
      target,
      null);
    ActionQueue.Enqueue(action);
  }

  public void QueueDefend(Character actor)
  {
    BattleAction action = new BattleAction(
      BattleAction.ActionType.DEFEND,
      actor,
      null,
      null);
    ActionQueue.Enqueue(action);
  }

  public void DequeueAction()
  {
    ActionQueue.Dequeue();
  }

  public void SetKrisItem(Consumable item)
  {
    KrisItem = item;
  }

  public void SetSusieItem(Consumable item)
  {
    SusieItem = item;
  }

  public void SetRalseiItem(Consumable item)
  {
    RalseiItem = item;
  }

  public void SetSusieMagic(Consumable magic)
  {
    SusieMagic = magic;
  }

  public void SetRalseiMagic(Consumable magic)
  {
    RalseiMagic = magic;
  }

  public void SetSkipRalsei(bool boolean)
  {
    SkipRalsei = boolean;
  }

  public bool GetSkipRalsei()
  {
    return SkipRalsei;
  }

  public void SetSkipSusie(bool boolean)
  {
    SkipSusie = boolean;
  }

  public bool GetSkipSusie()
  {
    return SkipSusie;
  }

  public void Execute()
  {

  }

}
