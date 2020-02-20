using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] private GameObject lastCreatedPlatform;
    [SerializeField] float spaceBetweenPlaforms = 2;
    float lastPlatformWidth;
    // Start is called before the first frame update
    void Start()
    {
        //lastCreatedPlatform=Instantiate(platformPrefab,referencePoint.position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Create a new platform when a previous reaches 0
        if (lastCreatedPlatform.transform.position.x < referencePoint.position.x)
        {
            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + spaceBetweenPlaforms, 0,0);
            int randomPlatform = Random.Range(0, platformPrefab.Length);
            lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);

            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth=collider.bounds.size.x;
        }
    }
}
