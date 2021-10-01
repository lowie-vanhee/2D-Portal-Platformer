using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPortal : MonoBehaviour
{
    GameObject character;
    bool lefttheportal = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        character = GameObject.Find("Character");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //lefttheportal = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("LeftPortal") && GameObject.Find("RightBullet(Clone)") != null))
        {
            Weapon weapon = character.GetComponent<Weapon>();
            weapon.RespawnPrevRightPortal();
            //wacht paar frames mss??
            Destroy(gameObject);
            if (GameObject.Find("RightBullet(Clone)") != null)
            {
                GameObject prevrightbullet = GameObject.Find("RightBullet(Clone)");
                Destroy(prevrightbullet);
            }
        } else if (collision.CompareTag("Player"))
        {
            GameObject leftportal = GameObject.Find("LeftPortal(Clone)");
            if(leftportal != null)
            {
                LeftPortal leftportalscript = leftportal.GetComponent<LeftPortal>();
                if (lefttheportal && leftportalscript.isVisible())
                {
                    GameObject player = collision.gameObject;
                    //go in anim??
                    player.transform.position = leftportal.transform.position;
                    LeftPortal portal = leftportal.GetComponent<LeftPortal>();
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
