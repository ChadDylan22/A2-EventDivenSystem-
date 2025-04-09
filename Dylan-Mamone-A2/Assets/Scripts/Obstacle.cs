using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
//tells obsctacles where to spawn 
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    //allows obstacles to move, matching the speed of the ground. sets variable to detect when an obstacle is far enough off screen, if yes then that obstacle is destroyed.
    private void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
