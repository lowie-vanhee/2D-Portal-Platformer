using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetection : MonoBehaviour
{
    public GameObject Ape;
    bool isincircle = false;
    public float cooldown = 4.7f;
    bool firsttime = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //if(!isincircle)
                //Ape.GetComponent<ApeAI>().ApeJump();
            isincircle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isincircle = false;
            firsttime = true;
        }
    }
    private void Update()
    {
        if(firsttime && isincircle)
        {
            firsttime = false;
            StartCoroutine(Waitsec(cooldown));
        }
    }

    IEnumerator Waitsec(float sec)
    {
        if(isincircle)
            Ape.GetComponent<ApeAI>().ApeJump();
        yield return new WaitForSecondsRealtime(sec);
        StartCoroutine(Waitsec(cooldown));
    }
}
