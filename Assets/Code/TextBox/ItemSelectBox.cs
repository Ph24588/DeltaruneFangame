using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ItemSelectBox : MonoBehaviour, Box
{

  GameObject SelectBox;
  Text[] ItemDisplay;
  Text Description;
  Image[] SelectHearts;
  Image Arrow;
  List<Consumable> Items1;
  List<Consumable> Items2;
  List<Consumable> CurrentItems;
  int Index = 0; 
  int ItemCount;
  int MAXITEM = 6;
  int Menu = 1; // which item Menu
  bool IsMenu2Empty;

  void Start()
  {
    SelectBox = gameObject;
    ItemDisplay = SelectBox.GetComponentsInChildren<Text>();
    Description = ItemDisplay[6]; // description box
    SelectHearts = SelectBox.GetComponentsInChildren<Image>();
    Arrow = SelectHearts[7];

    Items1 = new List<Consumable>();
    Items2 = new List<Consumable>();
  }

  void Update()
  {

  }

  public void InitialLoadItems(List<Consumable> items)
  {
    if (items.Count > MAXITEM)
    {
      for (int i = 0; i < MAXITEM; i++)
      {
        Items1.Add(items[i]);
      }
      for (int i = MAXITEM; i < items.Count; i++)
      {
        Items2.Add(items[i]);
      }
    } else
    {
      Items1 = items;
    }
    ItemCount = Items1.Count + Items2.Count;
    for (int i = 0; i < Mathf.Min(ItemCount, MAXITEM); i++)
    {
      ItemDisplay[i].text = Items1[i].GetName();
    }
    if (ItemCount > MAXITEM)
    {
      Arrow.sprite = Resources.Load<Sprite>("down_arrow");
    } else
    {
      IsMenu2Empty = true;
    }
    CurrentItems = Items1; // set current items
    Description.text = CurrentItems[0].GetDescription();
  }

  public void DownInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Menu == 1 && Index == 4 && !IsMenu2Empty)
    {
      Index = 0;
      CurrentItems = Items2;
      Menu = 2;
      ReloadItems();
    } else if (Menu == 1 && Index == 5 && !IsMenu2Empty)
    {
      if (ItemCount == 7) // check how many items left
      {
        Index = 0;
      }
      else if (ItemCount > 7)
      {
        Index = 1;
      }
      CurrentItems = Items2;
      Menu = 2;
      ReloadItems();
    } else if (Index != 4 || Index != 5)
    {
      if (CurrentItems.Count > Index + 2) // check if there is an item to go down to
      {
        Index += 2;
        ReloadDescription();
      }
    }
    ImageVisible(SelectHearts[Index + 1]);
    Debug.Log(Index);
  }

  public void UpInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Menu == 2 && Index == 0)
    {
      Index = 4;
      CurrentItems = Items1;
      Menu = 1;
      ReloadItems();
    }
    else if (Menu == 2 && Index == 1)
    {
      Index = 5;
      CurrentItems = Items1;
      Menu = 1;
      ReloadItems();
    }
    else if (Index > 1)
    {
      Index -= 2;
      ReloadDescription();
    }
    ImageVisible(SelectHearts[Index + 1]);
    Debug.Log(Index);
  }

  public void RightInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index % 2 == 0)
    {
      if (CurrentItems.Count > Index + 1)
      {
        Index++;
      }
    } else
    {
      Index--;
    }
    ReloadDescription();
    ImageVisible(SelectHearts[Index + 1]);
    Debug.Log(Index);
  }

  public void LeftInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index % 2 == 1)
    {
      Index--;
    }
    else
    {
      if (CurrentItems.Count > Index + 1)
      {
        Index++;
      }
    }
    ReloadDescription();
    ImageVisible(SelectHearts[Index + 1]);
    Debug.Log(Index);
  }

  public Consumable ZInput()
  {
    return CurrentItems[Index];
  }

  public void UseItem()
  {
    // remove current item from list
    // if Menu 1, shift over first item from Menu 2
    // reload Menus
  }

  private void ImageVisible(Image image)
  {
    Color temp = image.color;
    temp.a = 255;
    image.color = temp;
  }

  private void ImageInvisible(Image image)
  {
    Color temp = image.color;
    temp.a = 0;
    image.color = temp;
  }

  public int GetIndex()
  {
    return Index;
  }

  private void ReloadItems()
  {
    for (int i = 0; i < MAXITEM; i++)
    {
      if (i < CurrentItems.Count)
      {
        ItemDisplay[i].text = CurrentItems[i].GetName();
      } else
      {
        ItemDisplay[i].text = "";
      }
      
    }
    foreach (Consumable item in CurrentItems)
    {
      Debug.Log(item.GetName());
    }
    Debug.Log(IsMenu2Empty);
    Description.text = CurrentItems[Index].GetDescription();
    if (Menu == 1)
    {
      if (!IsMenu2Empty)
      {
        Debug.Log("down arrow to load");
        Arrow.sprite = Resources.Load<Sprite>("down_arrow");
      } else
      {
        ImageInvisible(Arrow);
      }
    } else if (Menu == 2)
    {
      Debug.Log("up arrow to load");
      Arrow.sprite = Resources.Load<Sprite>("up_arrow");
    }
  }

  private void ReloadDescription()
  {
    Description.text = CurrentItems[Index].GetDescription();
  }
}
