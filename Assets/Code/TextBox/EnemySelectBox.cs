using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelectBox : MonoBehaviour, Box {

  GameObject SelectBox;
  Slider[] HealthSliders;
  Image[] SelectHearts;
  Text[] EnemyNames;
  Character[] Enemies;
  int Index = 0;
  int numEnemies;

  void Start()
  {
    SelectBox = gameObject;
    HealthSliders = SelectBox.GetComponentsInChildren<Slider>();
    SelectHearts = SelectBox.GetComponentsInChildren<Image>();
    EnemyNames = SelectBox.GetComponentsInChildren<Text>();
  }

  void Update()
  {

  }

  // Displays heroes and returns Index which was selected
  public void LoadEnemies(Character[] characters)
  {
    for (int i = 0; i < characters.Length; i++)
    {
      Character enemy = characters[i];
      HealthSliders[i].value = enemy.CurrentHp / enemy.MaxHp;
      EnemyNames[i].text = enemy.Name;
    }
    numEnemies = characters.Length;
    Enemies = characters;
  }

  public void DownInput()
  {
    ImageInvisible(SelectHearts[Index + 1]);
    if (Index == numEnemies - 1)
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
      Index = numEnemies - 1;
    }
    else
    {
      Index--;
    }
    ImageVisible(SelectHearts[Index + 1]);
  }

  public Character ZInput()
  {
    return Enemies[Index];
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
