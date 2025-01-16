using System.Collections;
using UnityEngine;
using System.IO;
using SFB;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public string musicPath;

    public GameObject playImage;
    public GameObject pauseImage;

    AudioSource audioSource;
    MusicBar musicBar;

    public int songNumble = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        musicBar = GetComponent<MusicBar>();
    }

    private void Start()
    {
        //Core.Initialize();

        if (audioClips == null || audioClips.Length == 0)
        {

        }   
        else
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }    
    }

    private void LateUpdate()
    {
      
    }

    public void OpenFileSelectionDialog()
    {
        string fileExtensions = "mp3";
        string defaultDirectory = "";
        string filePath = StandaloneFileBrowser.OpenFilePanel("Select Audio File", defaultDirectory, fileExtensions, false)[0];
        if (!string.IsNullOrEmpty(filePath))
        {
            StartCoroutine(LoadAudio(filePath,AudioType.MPEG));
        }
    }

    IEnumerator LoadAudio(string filePath, AudioType audioType)
    {
        using (var www = new WWW("file://" + filePath))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip audioClip = www.GetAudioClip();
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                string clipName = Path.GetFileNameWithoutExtension(filePath);
                audioClip.name = clipName;
                musicBar.musicNameOnPlay.text = audioClip.name;
                audioSource.Play();
            }
        }
    }
    
    public void OnClickNameMusic(int button)
    {
        audioSource.clip = audioClips[button];
        audioSource.Play();
        songNumble = button;
    }

    public void OnClickNextSong()
    {
        songNumble++;
        if(songNumble >= audioClips.Length)
        {
            songNumble = 0;
        }

        audioSource.clip = audioClips[songNumble];
        audioSource.Play();
    }
    public void OnClickPreviousSong()
    {
        songNumble--;
        if (songNumble < 0)
        {
            songNumble = audioClips.Length -1;
        }

        audioSource.clip = audioClips[songNumble];
        audioSource.Play();
    }
    public void OnClickPlayOrPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            pauseImage.SetActive(true);
            playImage.SetActive(false);
        }
        else
        {
            audioSource.Play();
            pauseImage.SetActive(false);
            playImage.SetActive(true);
        }
    }
    public void OnLoop()
    {
        if (audioSource.loop == true)
        {
            audioSource.loop = false;
        }
        else
        {
            audioSource.loop = true;
        }
    }
}
