using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ActSelectBox : MonoBehaviour, Box
{

  GameObject SelectBox;
  Text[] ActDisplay;
  Text Description;
  Image[] SelectHearts;
  Image Arrow;
  List<Act> Acts;
  int Index = 0;
  int ActCount;

  void Start()
  {
    SelectBox = gameObject;
    ActDisplay = SelectBox.GetComponentsInChildren<Text>();
    Description = ActDisplay[6]; // description box
    SelectHearts = SelectBox.GetComponentsInChildren<Image>();
  }

  void Update()
  {

  }

  public void InitialLoadActs(List<Act> acts)
  {
    Acts = acts;
    ActCount = acts.Count;
    for (int i = 0; i < ActCount; i++)
    {
      ActDisplay[i].text = Acts[i].GetName();
    }
    Description.text = Acts[0].GetDescription();
  }

  public void DownInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index < 4)
    {
      if (ActCount > Index + 2) // check if there is an item to go down to
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
      if (ActCount > Index + 1)
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
      if (ActCount > Index + 1)
      {
        Index++;
      }
    }
    ReloadDescription();
    ImageVisible(SelectHearts[Index + 1]);
    Debug.Log(Index);
  }

  public Act ZInput()
  {
    return Acts[Index];
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
    Description.text = Acts[Index].GetDescription();
  }
}
