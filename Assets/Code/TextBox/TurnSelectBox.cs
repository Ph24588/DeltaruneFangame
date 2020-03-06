using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSelectBox : MonoBehaviour, Box {

  GameObject SelectBox;
  Character Chara;
  Image[] SelectActions;
  int Index = 1; // first image is the box itself, +1 to everything
  Slider HealthSlider;

  // Use this for initialization
  void Start () {
    SelectBox = gameObject;
    SelectActions = SelectBox.GetComponentsInChildren<Image>();
    HealthSlider = SelectBox.GetComponentInChildren<Slider>();
  }
	
	// Update is called once per frame
	void Update () {
		
	}

  public void LoadHero(Character character)
  {
    Chara = character;
    HealthSlider.value = Chara.CurrentHp / Chara.MaxHp;
  }

  public void RightInput()
  {
    ImageInvisible(SelectActions[Index]);
    if (Index == 5)
    {
      Index = 1;
    }
    else
    {
      Index++;
    }
    ImageVisible(SelectActions[Index]);
  }

  public void LeftInput()
  {
    ImageInvisible(SelectActions[Index]);
    if (Index == 1)
    {
      Index = 5;
    }
    else
    {
      Index--;
    }
    ImageVisible(SelectActions[Index]);
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
}
