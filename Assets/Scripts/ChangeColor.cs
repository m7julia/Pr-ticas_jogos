﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] cores;
    private int qualCor = 0;
    private SpriteRenderer spObjeto;

    private void Awake()
    {
        spObjeto = this.GetComponent<SpriteRenderer>();
        // Debug.Log("Estou associado a um objeto da tela atual!");
    }

    // Start is called before the first frame update
    /*void Start()
    {
        Debug.Log("O jogador acabou de pressionar o botão PLAY.");
    }*/

    // Update is called once per frame
    void Update()
    {
        // Verificaremos digitação de teclas pelo jogador e mudaremos cores
        if (Input.GetKeyDown(KeyCode.R))
            spObjeto.color = Color.red;
        if (Input.GetKeyDown(KeyCode.G))
            spObjeto.color = Color.green;
        if (Input.GetKeyDown(KeyCode.Y))
            spObjeto.color = Color.yellow;
        if (Input.GetKeyDown(KeyCode.C))
            spObjeto.color = Color.cyan;
        if (Input.GetKeyDown(KeyCode.B))
            spObjeto.color = Color.black;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            spObjeto.color = cores[qualCor];
            if (++qualCor >= cores.Length)
                qualCor = 0;
        }
    }
}
