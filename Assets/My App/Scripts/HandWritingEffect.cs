using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Text;

public class HandWritingEffect : MonoBehaviour
{
	public TMP_Text text;


	public void StartEvent()
	{
		StartCoroutine(RevealText());
	}

	public void EventPromptTitle()
    {
		StartCoroutine(RevealText());
	}

		

	public void StopEvent()
    {
		StopAllCoroutines();
    }

	IEnumerator RevealText()
	{
		var originalString = text.text;
		text.text = "";

		var numCharsRevealed = 0;
		while (numCharsRevealed < originalString.Length)
		{
			while (originalString[numCharsRevealed] == ' ')
				++numCharsRevealed;

			++numCharsRevealed;

			text.text = originalString.Substring(0, numCharsRevealed);

			yield return new WaitForSeconds(0.04f);
		}
	}

	public void RevealText2(TMP_Text textx)
	{
		var originalString = textx.text;
		textx.text = "";

		var numCharsRevealed = 0;
		while (numCharsRevealed < originalString.Length)
		{
			while (originalString[numCharsRevealed] == ' ')
				++numCharsRevealed;

			++numCharsRevealed;

			textx.text = originalString.Substring(0, numCharsRevealed);

		}
	}

}
