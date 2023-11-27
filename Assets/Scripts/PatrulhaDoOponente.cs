using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulhaDoOponente : MonoBehaviour
{
    public float velocidade = 1f;
    public float minX, maxX;
    public float tempoDeEspera = 2f;
    private GameObject _meta;

    private Animator _animator;

    private Arma _arma;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _arma = GetComponentInChildren<Arma>();
    }

    private void AtualizarMeta()
    {
        //se é a primeira vez que esta chamando o metodo, cria a mata a esquerda
        if (_meta == null)
        {
            _meta = new GameObject("Alvo");
            _meta.transform.position = new Vector2(minX, transform.position.y);
            return;
        }
        // se estamos na esquerda, trocamos a meta para direita
        if (_meta.transform.position.x <= minX)
        {
            _meta.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        //se estamos na direita, trocamos a meta para esquerda
        else
        if (_meta.transform.position.x >= maxX)
        {
            _meta.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    IEnumerator PatrulhaAteMeta()
    {
        //Corrotina para mover o oponente 
        while (Vector2.Distance(transform.position, _meta.transform.position) > 0.05f)
        {
            _animator.SetBool("Idle", false); //como está andando Idle é falso!!!
            Vector2 direcao = _meta.transform.position - transform.position;
            float direcaoX = direcao.x;
            transform.Translate(direcao.normalized * velocidade * Time.deltaTime);
            //IMPORTANTE
            yield return null;
        }
        //neste ponto, encontramos a meta e vamos ajustar a posição do oponente para a meta:
        transform.position = new Vector2(_meta.transform.position.x, transform.position.y);
        AtualizarMeta();

        _animator.SetBool("Idle", true); //como está na meta, Idle é true para esperar!!!
        
        _animator.SetTrigger("Shooting");

        //Oponente fica à toa e esperamos pelo tempo definido pela variável tempoDeEspera:
        yield return new WaitForSeconds(tempoDeEspera);

        //tendo esperado, vamos restaurar o comportamento de patrulha
        StartCoroutine("PatrulhaAteMeta");
    }

    void PodeAtirar(){
        if(_arma != null){
            _arma.Atirar();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        AtualizarMeta();
        StartCoroutine("PatrulhaAteMeta");
    }

    // Update is called once per frame
    void Update()
    {

    }
}