using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBullet : MonoBehaviour
{
    public float speed = 38f;
    public Rigidbody2D rb;
    bool clickedonground = false;
    public float seconds = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            clickedonground = true;
            rb.velocity = new Vector2(0,0);
            Vector2 positionportal = gameObject.transform.position;
            if(GameObject.Find("LeftPortal(Clone)") != null)
            {
                GameObject leftportal = GameObject.Find("LeftPortal(Clone)");
                LeftPortal leftportalscript = leftportal.GetComponent<LeftPortal>();
                leftportalscript.makeInvisible();
                leftportal.transform.position = positionportal;
                SpriteRenderer sprender = gameObject.GetComponent<SpriteRenderer>();
                sprender.enabled = false;
                rb.velocity = -transform.right * speed;
                
                StartCoroutine(Wait5sec());
                leftportalscript.makeVisible();
            }
        } else if (collision.CompareTag("LeftPortal"))
        {
            if(!clickedonground)
            {
                Destroy(gameObject);
                GameObject gameObj = collision.gameObject;
                LeftPortal leftPortal = gameObj.GetComponent<LeftPortal>();
                leftPortal.makeVisible();
                //createanim?
            }
        }
    }

    IEnumerator Wait5sec()
    {
        GameObject leftportal = GameObject.Find("LeftPortal(Clone)");
        LeftPortal leftportalscript = leftportal.GetComponent<LeftPortal>();
        leftportalscript.makeInvisible();
        leftportal.transform.position = rb.position;

        yield return new WaitForSecondsRealtime(seconds);

        leftportal = GameObject.Find("LeftPortal(Clone)");
        leftportal.transform.position = rb.position;

        Destroy(gameObject);
    }
}
