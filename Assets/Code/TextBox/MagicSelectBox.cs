using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MagicSelectBox : MonoBehaviour, Box
{

  GameObject SelectBox;
  Text[] MagicDisplay;
  Text Description;
  Image[] SelectHearts;
  Image Arrow;
  List<Consumable> Magic;
  int Index = 0;
  int ItemCount;

  void Start()
  {
    SelectBox = gameObject;
    MagicDisplay = SelectBox.GetComponentsInChildren<Text>();
    Description = MagicDisplay[6]; // description box
    SelectHearts = SelectBox.GetComponentsInChildren<Image>();

    Magic = new List<Consumable>();
  }

  void Update()
  {

  }

  public void InitialLoadMagic(List<Consumable> magic)
  {
    ItemCount = magic.Count;
    Magic = magic;
    for (int i = 0; i < Magic.Count; i++)
    {
      MagicDisplay[i].text = Magic[i].GetName();
    }
    Description.text = Magic[0].GetDescription();
  }

  public void DownInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index < 4)
    {
      if (ItemCount > Index + 2) // check if there is an item to go down to
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
    if (Index > 1)
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
      if (ItemCount > Index + 1)
      {
        Index++;
      }
    }
    else
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
      if (ItemCount > Index + 1)
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
    return Magic[Index];
  }

  public void UseAct()
  {
    // remove current item from list
    // if menu 1, shift over first item from menu 2
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

  private void ReloadDescription()
  {
    Description.text = Magic[Index].GetDescription();
  }
}
