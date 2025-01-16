using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{
    public Transform player;
    public Animator anim;

    Vector3 fixedPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        fixedPos = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        anim.SetBool("Fade", true);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1.2f);
        anim.SetBool("Fade", false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ResetPlayer()
    {
        player.position = fixedPos;
        player.rotation = Quaternion.identity;
        player.GetComponent<CharacterControl>().rotationX = 0;
    }

}
