using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAbilityScript : MonoBehaviour
{
    [SerializeField] private Transform _grabBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_grabBox.position, _grabBox.localScale);
    }
}