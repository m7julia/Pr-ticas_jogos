using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteTeclas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Botão esquerdo do mouse foi pressionado sobre o player!");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Botão esquerdo do mouse foi mandido pressionado sobre o player!");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Botão esquerdo do mouse foi liberado sobre o player!");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("player pula!");
        }

        if (Input.GetButtonDown("Jump"))
            Debug.Log("player pula com jump!");

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f)
            Debug.Log($"Eixo horizontal = {horizontal}");
        if (vertical != 0f)
            Debug.Log($"Eixo vertical = {vertical}");

    }
}
