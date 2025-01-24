using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float backgroundHeight = background.transform.GetComponent<Renderer>().bounds.size.y;
        float cameraMargin = backgroundHeight * 0.1f;
        if (player.transform.position.y < 0 - backgroundHeight / 2 + cameraMargin)
        {
            player.transform.position = new Vector3(0, 0, -1);
        }
    }
}
