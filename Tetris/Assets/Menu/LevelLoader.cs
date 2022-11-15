using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public AudioSource transitionSoundIn;
    public AudioSource transitionSoundOut;
    public float transitionTime = 0.3f;
    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    private void Start()
    {
        transitionSoundOut.Play();
    }
    IEnumerator LoadLevel(string sceneName)
    {
        transitionSoundIn.Play();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }

}
