using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [Header ("Torre")]
    [SerializeField] GameObject balaPrefab;  // Prefab da bala
    [SerializeField] Transform pontoDeDisparo;  // Ponto de origem das balas
    [SerializeField] float intervaloDeDisparo = 1f;  // Intervalo entre os disparos
    [SerializeField] float velocidadeBala = 10f;  // Velocidade da bala
    private float tempoUltimoDisparo;

    [Header("Rotacao da Torre")]
    [SerializeField] Transform torreTransform; // Objeto cuja rotacao vai ser alterada
    [SerializeField] float rotacaoZ; //Valor da rotacao do objeto

    void Update()
    {
        if (Time.time - tempoUltimoDisparo > intervaloDeDisparo)
        {
            // Dispara uma bala
            DispararBala();

            // Atualiza o tempo do ultimo disparo
            tempoUltimoDisparo = Time.time;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotacaoZ); //Transforma a rotacao do objeto
    }

    private void DispararBala()
    {
        // Instancia uma nova bala
        GameObject bala = Instantiate(balaPrefab, pontoDeDisparo.position, Quaternion.identity);

        // Obtém o componente Rigidbody2D da bala
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();

        // Aplica uma força para mover a bala para a direita
        rbBala.velocity = transform.right * velocidadeBala;

        // Destroi a bala após alguns segundos para evitar acumulacao no jogo
        Destroy(bala, 5f);
    }
}
