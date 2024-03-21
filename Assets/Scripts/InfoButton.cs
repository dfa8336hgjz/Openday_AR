using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MyButton
{
    [HideInInspector]
    public bool on = false;
    [SerializeField] Animator[] buttonAnim;
    public override void OnClick()
    {
        if (!on)
        {
            on = true;
            foreach (var anim in buttonAnim)
            {
                anim.SetBool("active", true);
            }
        }
        else
        {
            on = false;
            foreach (var anim in buttonAnim)
            {
                anim.SetBool("active", false);
            }
        }
    }

}
