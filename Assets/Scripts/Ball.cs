using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        transform.position = Vector3.zero;
        GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color randomlySelectedColor = GetRandomColor();
        GetComponent<Renderer>().material.color = randomlySelectedColor;
    }

    private Color GetRandomColor()
    {
        return new Color(
            r: UnityEngine.Random.Range(0f, 1f),
            g: UnityEngine.Random.Range(0f, 1f),
            b: UnityEngine.Random.Range(0f, 1f));
    }

}
