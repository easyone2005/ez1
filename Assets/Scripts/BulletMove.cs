using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private void Start()
    {
        Destroy(gameObject, 2f);    
    }

    void Update()
    {        
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
