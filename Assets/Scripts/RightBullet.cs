using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBullet : MonoBehaviour
{
    public float speed = 38f;
    public Rigidbody2D rb;
    bool clickedonground = false;
    public float seconds = 0.029f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            clickedonground = true;
            rb.velocity = new Vector2(0, 0);
            Vector2 positionportal = gameObject.transform.position;
            if (GameObject.Find("RightPortal(Clone)") != null)
            {
                GameObject rightportal = GameObject.Find("RightPortal(Clone)");
                RightPortal rightportalscript = rightportal.GetComponent<RightPortal>();
                rightportalscript.makeInvisible();
                rightportal.transform.position = positionportal;
                SpriteRenderer sprender = gameObject.GetComponent<SpriteRenderer>();
                sprender.enabled = false;
                rb.velocity = -transform.right * speed;

                StartCoroutine(Wait5sec());
                rightportalscript.makeVisible();
            }
        }
        else if (collision.CompareTag("RightPortal"))
        {
            if (!clickedonground)
            {
                Destroy(gameObject);
                GameObject gameObj = collision.gameObject;
                RightPortal rightPortal = gameObj.GetComponent<RightPortal>();
                rightPortal.makeVisible();
                //createanim?
            }
        }
    }
    IEnumerator Wait5sec()
    {
        GameObject rightportal = GameObject.Find("RightPortal(Clone)");
        RightPortal rightportalscript = rightportal.GetComponent<RightPortal>();
        rightportalscript.makeInvisible();
        rightportal.transform.position = rb.position;

        yield return new WaitForSecondsRealtime(seconds);

        rightportal = GameObject.Find("RightPortal(Clone)");
        rightportal.transform.position = rb.position;

        Destroy(gameObject);
    }
}
