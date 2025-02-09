using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    bool toogle;
    public Animator anim;
    public string sceneName = "SampleScene";
    private SceneFader sceneFader;

    public void Start()
    {
        sceneFader = FindObjectOfType<SceneFader>();
    }

    public void doorState()
    {
        toogle = !toogle;

        if (toogle == true) {
            anim.ResetTrigger("close");
            anim.SetTrigger("open");
        }
        
        if (toogle == false) {
            anim.ResetTrigger("open");
            anim.SetTrigger("close");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            sceneFader.FadeToScene(sceneName);
        }
    }
}
