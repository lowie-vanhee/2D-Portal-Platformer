using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApeAI : MonoBehaviour
{
    float animation;

    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    public GameObject Character;

    // Update is called once per frame
    void Update()
    {
        /**
        animation += Time.deltaTime;

        animation = animation % 5f;

        transform.position = MathParabola.Parabola(Vector3.zero, Vector3.right*10f, 5f, animation / 5f);*/
    }

    public void ApeJump()
    {
        Point1.transform.position = GetComponent<Rigidbody2D>().transform.position;
        Point2.transform.position = new Vector3((Character.transform.position.x - Mathf.Abs(GetComponent<Rigidbody2D>().transform.position.x)) / 2,
                        GetComponent<Rigidbody2D>().transform.position.y + (Mathf.Abs(GetComponent<Rigidbody2D>().transform.position.y - Character.transform.position.y)) / 2);
        Point3.transform.position = Character.transform.position;
        GetComponent<ParabolaController>().FollowParabola();
    }
}
