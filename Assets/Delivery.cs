using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor=new Color32(251,91,91,255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    SpriteRenderer spriteRenderer;

    bool hasPackage=false;
    [SerializeField] float delayInDelete=0.3f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Gaadi thok di!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package PickedUp! ");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject,delayInDelete);
        }
        if(collision.tag =="Item Delivered" && hasPackage)
        {
            Debug.Log("Package Delivered! ");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
