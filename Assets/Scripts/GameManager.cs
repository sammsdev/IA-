
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // Use this for initialization
    [SerializeField] float spawnSpeed;
    [SerializeField] GameObject [] ghosts;
    [SerializeField] GameObject[] spawnPoints;
    private int life=20;
    [SerializeField] private Text lifetxt;
    
    public static GameManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            
        } else
        {
            instance = this;
        }
    }
    void Start () {
        lifetxt.text = life.ToString() + "x";
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Invoke("SpawnGhost", spawnSpeed);
	}
	
    void SpawnGhost()
    {
        int i = Random.Range(0, 3);
        int k = Random.Range(0, 2);
        Instantiate(ghosts[k], spawnPoints[i].transform.position, Quaternion.identity);
        Invoke("SpawnGhost", spawnSpeed);

    }

    private void LateUpdate()
    {
        if(life <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
            
  
    }
    public void UpdateLife()
    {
        life--;
        lifetxt.text = life.ToString()+"x";
        
    }
}
