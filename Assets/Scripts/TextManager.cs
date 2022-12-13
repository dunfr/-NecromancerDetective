using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct TextEffect_t
{
    public string str;
    public int delay;
}
public class TextManager : MonoBehaviour
{
    public Text text;
    public float wordDelay;

    public List<TextEffect_t> inputTexts = new List<TextEffect_t>();

    private void Start()
    {
        text.text = "";
        StartCoroutine(textCoroutine());
    }

    IEnumerator textCoroutine()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < inputTexts.Count; ++i)
        {
            for (int j = 0; j < inputTexts[i].str.Length; ++j)
            {
                text.text += inputTexts[i].str[j];
                yield return new WaitForSeconds(wordDelay);
            }
            yield return new WaitForSeconds(inputTexts[i].delay);
            text.text = "";
        }
    }
}
