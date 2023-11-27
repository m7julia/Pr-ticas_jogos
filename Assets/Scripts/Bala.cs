using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Vector2 direcao;
    public float velocidade = 2f;

    public float tempoDeVida = 3f;

    public Color corInicial = Color.white;
    public Color corFinal;
    private SpriteRenderer _srBala;
    private float _tempoInicial;

    void Awake()
    {
        _srBala = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _tempoInicial = Time.time; //obtém o horário inicial do script
        Destroy(this.gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movimento = direcao.normalized * velocidade * Time.deltaTime;
        transform.Translate(movimento);

        float _tempoDecorrido = Time.time - _tempoInicial;
        float _porcentagemCompleta = _tempoDecorrido / tempoDeVida;
        _srBala.color = Color.Lerp(corInicial, corFinal, _porcentagemCompleta);
    }
}