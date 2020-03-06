using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveTextBox : MonoBehaviour, Box
{
  // TODO: Change Input key
  // TODO: Text sound
  // TODO: Font

  float textSpeed = 0.03f;

  GameObject TextBox;

  string linePrefix = "* ";
  string lineDelim = "/n";
  string display;

  bool isAnyKeyDown = false;

  // pop box to front
  void Start()
  {
    Debug.Log("Creating InteractiveTextBox");
    CreateUIBox();
    //DisplayOneLine("i'm a very long test line baby ayy lmao");
    //DisplayMultipleLines(new string[] { "test me i'm a test motherfucker", "yea you bitch", "crazy bitch" });
  }

  void Update()
  {
    if (Input.anyKeyDown)
    {
      isAnyKeyDown = true;
    }
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

  private void CreateUIBox()
  {
    TextBox = (GameObject)Instantiate(Resources.Load("InteractiveTextBox"));
    TextBox.transform.SetParent(GameObject.Find("Canvas").transform, false);
  }

  IEnumerator AnimateText(Text words, string totalText)
  {
    for (int i = 0; i < (totalText.Length + 1); i++)
    {
      if (isAnyKeyDown)
      {
        words.text = totalText;
        isAnyKeyDown = false;
        yield return StartCoroutine(DestroyBox());
        break;
      }
      words.text = totalText.Substring(0, i);
      yield return new WaitForSeconds(textSpeed);
    }
    yield return StartCoroutine(DestroyBox());
  }

  IEnumerator AnimateTexts(Text[] texts, string[] lines)
  {
    for (int i = 0; i < lines.Length; i++)
    {
      // TODO: This is a little laggy for some reason?
      if (isAnyKeyDown)
      {
        for (int k = 0; k < lines.Length; k++)
        {
          Text tempWord = texts[k];
          string tempTotalText = linePrefix + lines[k];
          tempWord.text = tempTotalText;
        }
        isAnyKeyDown = false;
        yield return StartCoroutine(DestroyBox());
        break;
      }
      Text words = texts[i];
      string totalText = linePrefix + lines[i];
      for (int j = 0; j < (totalText.Length + 1); j++)
      {
        words.text = totalText.Substring(0, j);
        yield return new WaitForSeconds(textSpeed);
      }
    }
    yield return StartCoroutine(DestroyBox());
  }

  IEnumerator DestroyBox()
  {
    while (!isAnyKeyDown)
    {
      yield return null;
    }
    Destroy(TextBox);
  }

}
