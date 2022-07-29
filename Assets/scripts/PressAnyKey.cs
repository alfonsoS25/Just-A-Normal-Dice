using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PressAnyKey : MonoBehaviour
{
    [SerializeField]
    float timer = 0;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Input.anyKeyDown && timer > 2)
        {
            anim.SetTrigger("NextScene");
        }
    }
    public void StartScene()
    {
        SceneManager.LoadScene("Main");
    }
}
