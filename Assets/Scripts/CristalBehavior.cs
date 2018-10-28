using UnityEngine;

public class CristalBehavior : MonoBehaviour {

    [SerializeField] float speedRot = 2f;
    AudioSource caliceSound;
    private void Start()
    {      
       
        this.gameObject.transform.tag = "Cristal";
        caliceSound = GetComponent<AudioSource>();

    }


    private void Update()
    {
    
        transform.Rotate( new Vector3(0, speedRot * Time.deltaTime, 0));

    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ghost"))
        {
            if (other.transform.name == "PF_BadSoul(Clone)")
                GameManager.instance.UpdateLife();
            Destroy(other.gameObject);

            if (!caliceSound.isPlaying)
            {
                caliceSound.Play();
            }
        }

       

    }





}
