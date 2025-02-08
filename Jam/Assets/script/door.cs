using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class door : MonoBehaviour
{
    bool toogle;
    public Animator anim;

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
}
