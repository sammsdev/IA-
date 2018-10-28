using UnityEngine;
using UnityEngine.AI;

public class GhostBehaviour : MonoBehaviour {

    GameObject localDestino;
    NavMeshAgent agente;
    GameObject[] Fogo;
    float raioDeteccao = 1;
    float raioFuga = 5;

    void Recalibra()
    {
        agente.speed = Random.Range(1f, 4f);
        agente.angularSpeed = Random.Range(90, 150);
        agente.ResetPath();
    } 

    void Start()
    {
        Fogo = GameObject.FindGameObjectsWithTag("Fire");
        localDestino = GameObject.FindGameObjectWithTag("Cristal");

        agente = this.GetComponent<NavMeshAgent>();
        Recalibra();
        agente.SetDestination(localDestino.transform.position);

    }

    void Update()
    {
        
           agente.SetDestination(localDestino.transform.position);
        
    }

    public void DetectaNovoObstaculo(Vector3 position)
    {
        int f = Random.Range(0, 2);
        if (Vector3.Distance(position, this.transform.position) < raioDeteccao)
        {
            Vector3 direcaoFuga = (Fogo[f].transform.position - this.transform.position).normalized;
            Vector3 novoDestino = this.transform.position + direcaoFuga * raioFuga;
            localDestino = Fogo[f];
            NavMeshPath path = new NavMeshPath();
            agente.CalculatePath(novoDestino, path);
            if (path.status != NavMeshPathStatus.PathInvalid)
            {
                agente.SetDestination(path.corners[path.corners.Length - 1]);
            }
        }

    }


}
