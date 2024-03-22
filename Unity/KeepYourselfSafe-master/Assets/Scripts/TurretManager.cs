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

    [Header("Rotação da Torre")]
    [SerializeField] Transform torreTransform; // Objeto cuja rotação vai ser alterada
    [SerializeField] float rotacaoZ; //Valor da rotação do objeto

    void Update()
    {
        if (Time.time - tempoUltimoDisparo > intervaloDeDisparo)
        {
            // Dispara uma bala
            DispararBala();

            // Atualiza o tempo do último disparo
            tempoUltimoDisparo = Time.time;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotacaoZ); //Transforma a rotação do objeto
    }

    private void DispararBala()
    {
        // Instancia uma nova bala
        GameObject bala = Instantiate(balaPrefab, pontoDeDisparo.position, Quaternion.identity);

        // Obtém o componente Rigidbody2D da bala
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();

        // Aplica uma força para mover a bala para a direita
        rbBala.velocity = transform.right * velocidadeBala;

        // Destroi a bala após alguns segundos para evitar acumulação no jogo
        Destroy(bala, 5f);
    }
}
