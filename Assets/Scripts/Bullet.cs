using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Transform hitGreen, hitRed, hitBlue;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            Instantiate(hitGreen, transform.position, Quaternion.identity);
            enemy.Damage(5);
        }
        else if (other.TryGetComponent(out Hostage hostage))
        {
            Instantiate(hitRed, transform.position, Quaternion.identity);
            MainMenu.Instance.GameOver("You killed hostage :c ");

        }
        else
        {
            Instantiate(hitBlue, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);

    }

}//class
