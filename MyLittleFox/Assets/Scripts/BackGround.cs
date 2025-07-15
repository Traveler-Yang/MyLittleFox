using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private Vector2 movingSpeed;

    private Vector2 offset;

    private Material mat;

    private void Awake()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = movingSpeed * Time.deltaTime;
        mat.mainTextureOffset += offset;
    }
}
