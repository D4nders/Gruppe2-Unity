using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    public int expValue = 10;
    private int lifetime = 5;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}