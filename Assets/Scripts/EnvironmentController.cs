﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] environmentElement;
    [SerializeField] Transform  referencePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
    }

IEnumerator CreateEnvironmentElement()
    {
        Vector3 offset = new Vector3(10, 0, 0);
        Instantiate(environmentElement[Random.Range(0,environmentElement.Length)], referencePoint.position+ offset, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3,6));
        //call again
        StartCoroutine(CreateEnvironmentElement());
    }
}
