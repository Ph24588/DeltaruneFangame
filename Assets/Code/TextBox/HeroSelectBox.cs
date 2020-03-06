using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectBox : MonoBehaviour, Box {

  GameObject SelectBox;
  Slider[] HealthSliders;
  Image[] SelectHearts;
  List<Character> Heroes;
  int Index = 0;

  void Start () {
    SelectBox = gameObject;
    HealthSliders = SelectBox.GetComponentsInChildren<Slider>();
    SelectHearts = SelectBox.GetComponentsInChildren<Image>();
  }
	
	void Update () {
		
	}

  // Displays heroes and returns Index which was selected
  public void LoadHeroes(List<Character> characters)
  {
    // Must be in order Kris, Susie, Ralsei
    for (int i = 0; i < characters.Count; i++) 
    {
      Character hero = characters[i];
      Slider health = HealthSliders[i];
      health.value = hero.CurrentHp / hero.MaxHp;
    }
    Heroes = characters;
  }

  public void DownInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index == 2)
    {
      Index = 0;
    }
    else
    {
      Index++;
    }
    ImageVisible(SelectHearts[Index + 1]);
  }

  public void UpInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index == 0)
    {
      Index = 2;
    }
    else
    {
      Index--;
    }
    ImageVisible(SelectHearts[Index + 1]);
  }

  public Character ZInput()
  {
    return Heroes[Index];
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
