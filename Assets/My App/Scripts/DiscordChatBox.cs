using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class DiscordChatBox : MonoBehaviour
{
    public string Message;
    public string Subject;
   
    public GameObject mess;
    public GameObject subject;
    string webhook_link = "https://discordapp.com/api/webhooks/1074597358723145769/4rjsZEv3aywVaNRjoIBC9Ax-eVs5gmXr2Na1XgIAi3q3rou7emF5VFFffQTdCYDkVKS1";

    public void Store()
    {
        Message = mess.GetComponent<TMP_Text>().text;
        Subject = subject.GetComponent<TMP_Text>().text;
    }

    /*public void msg()
    {
        StartCoroutine(SendWebHook(webhook_link, "/spoiler message: " + "360 imagine " + Subject + " " + Message, (success) =>
         {
             if(success)
             {
                 Debug.Log("Good");
             }
         }));
    }

    IEnumerator SendWebHook(string link, string mess, System.Action<bool> action)
    {
        WWWForm form = new WWWForm();
        form.AddField("content", mess);
        using(UnityWebRequest www = UnityWebRequest.Post(link, form))
        {
            yield return www.SendWebRequest();
            if(www.isNetworkError || www.isHttpError)
            {
                action(false);
            }
            else
            {
                action(true);
            }
        }
      
    }*/
}
