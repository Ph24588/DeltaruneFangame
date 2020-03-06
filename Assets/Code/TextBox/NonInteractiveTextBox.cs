using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonInteractiveTextBox : MonoBehaviour, Box
{
  // TODO: Change Input key
  // TODO: Text sound
  // TODO: Font
  float textSpeed = 0.03f;

  GameObject TextBox; 

  string linePrefix = "* ";
  string lineDelim = "/n";
  string display; 

  void Start()
  {
    TextBox = gameObject;
  }

  void Update()
  {

  }

  public void DisplayOneLine(string line)
  {
    Text words = TextBox.GetComponentInChildren<Text>();
    string totalText = linePrefix + line;
    StartCoroutine(AnimateText(words, totalText));
  }

  // Can only display up to three max
  public void DisplayMultipleLines(string[] lines)
  {
    if (lines.Length > 3)
    {
      Debug.LogError("Too many lines to display");
      return;
    }
    Text[] texts = TextBox.GetComponentsInChildren<Text>();
    StartCoroutine(AnimateTexts(texts, lines));
  }

  IEnumerator AnimateText(Text words, string totalText)
  {
    for (int i = 0; i < (totalText.Length + 1); i++)
    {
     words.text = totalText.Substring(0, i);
     yield return new WaitForSeconds(textSpeed);
    }
  }

  IEnumerator AnimateTexts(Text[] texts, string[] lines)
  {
    for (int i = 0; i < lines.Length; i++)
    {
      Text words = texts[i];
      string totalText = linePrefix + lines[i];
      for (int j = 0; j < (totalText.Length + 1); j++)
      {
        words.text = totalText.Substring(0, j);
        yield return new WaitForSeconds(textSpeed);
      }
    }
  }
}
