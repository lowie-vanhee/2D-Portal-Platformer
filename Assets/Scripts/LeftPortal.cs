using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPortal : MonoBehaviour
{
    GameObject character;
    bool lefttheportal = true;

    private void Awake()
    {
        character = GameObject.Find("Character");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //lefttheportal = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.CompareTag("RightPortal") && GameObject.Find("LeftBullet(Clone)") != null))
        {
            Weapon weapon = character.GetComponent<Weapon>();
            weapon.RespawnPrevLeftPortal();
            //wacht paar frames mss??
            Destroy(gameObject);
            if (GameObject.Find("LeftBullet(Clone)") != null)
            {
                GameObject prevleftbullet = GameObject.Find("LeftBullet(Clone)");
                Destroy(prevleftbullet);
            }
        } else if (collision.CompareTag("Player"))
        {
            GameObject rightportal = GameObject.Find("RightPortal(Clone)");
            if(rightportal != null)
            {
                RightPortal rightportalscript = rightportal.GetComponent<RightPortal>();
                if (lefttheportal && rightportalscript.isVisible())
                {
                    GameObject player = collision.gameObject;
                    player.transform.position = rightportal.transform.position;
                    RightPortal portal = rightportal.GetComponent<RightPortal>();
                    portal.setLeftThePortal(false);
                }
            }
        }
        
    }

    public void setLeftThePortal(bool b)
    {
        lefttheportal = b;
    }

    public void makeInvisible()
    {
        SpriteRenderer sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
    }
    public void makeVisible()
    {
        SpriteRenderer sprender = gameObject.GetComponent<SpriteRenderer>();
        sprender.enabled = true;
    }
    public bool isVisible()
    {
        SpriteRenderer sprender = gameObject.GetComponent<SpriteRenderer>();
        return sprender.enabled;
    }

    public bool getLeftthePortal()
    {
        return lefttheportal;
    }
}
