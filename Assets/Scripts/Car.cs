using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float selfTerminateTimeout = 3f;

    void Start()
    {
        Destroy(gameObject, selfTerminateTimeout);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            GameManager.instance.GameOver();
    }
}

