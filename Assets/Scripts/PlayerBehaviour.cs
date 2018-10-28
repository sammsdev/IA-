using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject obstaculo;
    [SerializeField] GameObject[] agentes;

    // Use this for initialization
    void Start()
    {
        //  agentes = GameObject.FindGameObjectsWithTag("Ghost");
    }
    // Update is called once per frame
    void Update()
    {
        agentes = GameObject.FindGameObjectsWithTag("Ghost");


        if (Input.GetMouseButtonDown(0) && agentes != null)
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
            {
                Instantiate(obstaculo, hitInfo.point,Quaternion.identity);
                foreach (GameObject a in agentes)
                    a.GetComponent<GhostBehaviour>().DetectaNovoObstaculo(hitInfo.point);
            }
        }
    }

}
