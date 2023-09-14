using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool lowerUp;
    private float upperEdge;
    private float lowerEdge;

    private void Awake()
    {
        upperEdge = transform.position.y - movementDistance;
        lowerEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        if (lowerUp)
        {
            if (transform.position.y > upperEdge)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
                lowerUp = false;
        }
        else
        {
            if (transform.position.y < lowerEdge)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                lowerUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}