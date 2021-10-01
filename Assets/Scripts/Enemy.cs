using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject DeathMenuCanvas;
    bool lefttheleftportal = true;
    bool lefttherightportal = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            DeathMenuCanvas.SetActive(true);
        } else if(collision.CompareTag("LeftPortal"))
        {
            GameObject rightportal = GameObject.Find("RightPortal(Clone)");
            if (rightportal != null)
            {
                RightPortal rightportalscript = rightportal.GetComponent<RightPortal>();
                if (lefttheleftportal && rightportalscript.isVisible())
                {
                    //go in anim??
                    transform.position = rightportal.transform.position;
                    lefttheleftportal = true;
                    lefttherightportal = false;
                }
            }
        } else if (collision.CompareTag("RightPortal"))
        {
            GameObject leftportal = GameObject.Find("LeftPortal(Clone)");
            if (leftportal != null)
            {
                LeftPortal leftportalscript = leftportal.GetComponent<LeftPortal>();
                if (lefttherightportal && leftportalscript.isVisible())
                {
                    //go in anim??
                    transform.position = leftportal.transform.position;
                    lefttheleftportal = false;
                    lefttherightportal = true;
                }
            }
        }
    }

    public bool getLeftTheLeftPortal()
    {
        return lefttheleftportal;
    }

    public void setLeftTheLeftPortal(bool b)
    {
        lefttheleftportal = b;
    }

    public bool getLeftTheRightPortal()
    {
        return lefttherightportal;
    }

    public void setLeftTheRightPortal(bool b)
    {
        lefttherightportal = b;
    }
}
