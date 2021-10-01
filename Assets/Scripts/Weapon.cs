using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePointleft;
    public Transform firePointright;

    public GameObject leftbulletPrefab;
    public GameObject leftportalPrefab;
    public GameObject rightbulletPrefab;
    public GameObject rightportalPrefab;
    public GameObject EscapeMenuCanvas;
    public GameObject DeathMenuCanvas;

    Vector2 lookDirection;
    float lookAngle;

    Vector2 locationlastleftportal = new Vector2();
    Quaternion rotationlastleftportal = Quaternion.identity;
    Vector2 locationlastrightportal = new Vector2();
    Quaternion rotationlastrightportal = Quaternion.identity;

    // Update is called once per frame
    void Update()
    {
        //Left Click
        if(Input.GetButtonDown("Fire1") && !EscapeMenuCanvas.activeSelf && !DeathMenuCanvas.activeSelf)
        {
            ShootLeftPortal();
        }

        //Right Click
        if (Input.GetButtonDown("Fire2") && !EscapeMenuCanvas.activeSelf && !DeathMenuCanvas.activeSelf)
        {
            ShootRightPortal();
        }

        //Close Portal 1
        if (Input.GetButtonDown("Close Portal 1") && !EscapeMenuCanvas.activeSelf && !DeathMenuCanvas.activeSelf)
        {
            if(GameObject.Find("LeftBullet(Clone)") != null)
            {
                Destroy(GameObject.Find("LeftBullet(Clone)"));
            }
            if (GameObject.Find("LeftPortal(Clone)") != null)
            {
                Destroy(GameObject.Find("LeftPortal(Clone)"));
            }
        }

        //Close Portal 2
        if (Input.GetButtonDown("Close Portal 2") && !EscapeMenuCanvas.activeSelf && !DeathMenuCanvas.activeSelf)
        {
            if (GameObject.Find("RightBullet(Clone)") != null)
            {
                Destroy(GameObject.Find("RightBullet(Clone)"));
            }
            if (GameObject.Find("RightPortal(Clone)") != null)
            {
                Destroy(GameObject.Find("RightPortal(Clone)"));
            }
        }
    }

    private void ShootLeftPortal()
    {
        if (GameObject.Find("LeftBullet(Clone)") == null)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            Vector2 offset = new Vector2(Input.mousePosition.x - screenPoint.x, Input.mousePosition.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            firePointleft.rotation = Quaternion.Euler(0f, 0f, angle);
            Instantiate(leftbulletPrefab, firePointleft.position, firePointleft.rotation);

            if (GameObject.Find("LeftPortal(Clone)") != null)
            {
                GameObject prevleftPortal = GameObject.Find("LeftPortal(Clone)");
                locationlastleftportal = prevleftPortal.transform.position;
                rotationlastleftportal = prevleftPortal.transform.rotation;
                //Destroyanim?
                Destroy(prevleftPortal);
            }

            Vector3 portalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            portalPosition.z = 0f;
            GameObject gameObj = Instantiate(leftportalPrefab, portalPosition, Quaternion.identity);
            LeftPortal leftPortal = gameObj.GetComponent<LeftPortal>();
            leftPortal.makeInvisible();
        }
    }

    private void ShootRightPortal()
    {
        if (GameObject.Find("RightBullet(Clone)") == null)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
            Vector2 offset = new Vector2(Input.mousePosition.x - screenPoint.x, Input.mousePosition.y - screenPoint.y);
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            firePointright.rotation = Quaternion.Euler(0f, 0f, angle);
            Instantiate(rightbulletPrefab, firePointright.position, firePointright.rotation);
            
            if (GameObject.Find("RightPortal(Clone)") != null)
            {
                GameObject prevrightPortal = GameObject.Find("RightPortal(Clone)");
                locationlastrightportal = prevrightPortal.transform.position;
                rotationlastrightportal = prevrightPortal.transform.rotation;
                //Destroyanim?
                Destroy(prevrightPortal);
            }
            
            Vector3 portalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            portalPosition.z = 0f;
            GameObject gameObj = Instantiate(rightportalPrefab, portalPosition, Quaternion.identity);
            RightPortal rightPortal = gameObj.GetComponent<RightPortal>();
            rightPortal.makeInvisible();
        }
    }

    public void RespawnPrevLeftPortal()
    {
        if (!locationlastleftportal.Equals(new Vector2()))
        {
            Instantiate(leftportalPrefab, locationlastleftportal, rotationlastleftportal);
        }
    }

    public void RespawnPrevRightPortal()
    {
        if (!locationlastrightportal.Equals(new Vector2()))
        {
            Instantiate(rightportalPrefab, locationlastrightportal, rotationlastrightportal);
        }
    }
}
