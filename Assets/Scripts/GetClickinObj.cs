using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GetClickinObj : MonoBehaviour
{
    AudioSource audioData;

    public Animation rock;
    public Animation Flower;
    public Animation chest;
    public MeshRenderer key;
    public MeshRenderer sphere;
    public Animation keyatRock;
    public Animation jumpingBean;
    public AudioClip clip;

    public float delay = 1;
    public Image image;
    public Image image2;
    bool getkey;
    public bool chestOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        audioData = chest.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Flower")
                {
                    Debug.Log("...");
                }
                else if (hit.transform.name == "KeyAtLock")
                {
                    if (getkey == true)
                    {
                        image.enabled = false;
                        key.GetComponent<MeshRenderer>().enabled = true;
                        chest.GetComponent<Animation>().Play();
                        chestOpen = true;
                    }
                    else
                    {
                        audioData.Play(0);
                    }
                }

                else if (image.enabled == false && hit.transform.name == "Rock")
                {
                    rock.GetComponent<Animation>().Play();
                    keyatRock.GetComponent<Animation>().Play();
                    getkey = true;
                    image.enabled = true;
                }
                else if (hit.transform.name == "JumpingBean")
                {
                    jumpingBean.GetComponent<Animation>().Play();
                }

                if (chestOpen == true && hit.transform.name == "Chest")
                {
                    image2.enabled = true;
                    sphere.GetComponent<MeshRenderer>().enabled = false;
                }
                if (hit.transform.name == "Chest" && chestOpen == true)
                {
                    chest.GetComponent<Animation>().Play("chest close");
                    chestOpen = false;
                }
            }
        }
    }


}
