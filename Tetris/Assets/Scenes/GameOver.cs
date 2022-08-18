using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] public Animator Text;
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    // Start is called before the first frame update
    void Start()
    {
        Text.Play("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
