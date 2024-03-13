using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float shootInterval = 2f; 
    public float moveInterval = 5f;
    private int moveDistance;
    public float moveSpeed;
    private float shootTimer = 0f; 
    private float moveTimer = 0f; 
    private Transform player;
    public float bulletSpeed = 10f; 
    private Vector3 targetPosition; 

    void Start()
    {
        moveSpeed = Random.Range(2, 5);
        moveDistance = Random.Range(0, 12);

        player = GameObject.FindGameObjectWithTag("Player").transform; 
        targetPosition = transform.position; 
    }

    void Update()
    {
        if (player == null) return; 

        
        shootTimer += Time.deltaTime;

      
        moveTimer += Time.deltaTime;

        
        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f; 
        }

        
        if (moveTimer >= moveInterval)
        {
            CalculateNewTargetPosition();
            moveTimer = 0f; 
        }

        // P�ynnie przemieszczaj przeciwnika w kierunku docelowej pozycji
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        // Oblicz kierunek strza�u
        Vector3 direction = (player.position - firePoint.position).normalized;

        // Stw�rz pocisk
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Ustaw kierunek ruchu pocisku
        bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

        // Zniszcz pocisk po pewnym czasie, aby unikn�� zapychania pami�ci
        Destroy(bullet, 2f);
    }

    void CalculateNewTargetPosition()
    {
        moveDistance = Random.Range(1, 12);
        moveSpeed = Random.Range(2, 5);
        // Wygeneruj losow� pozycj� w odleg�o�ci moveDistance od aktualnej pozycji
        Vector3 randomDirection = Random.insideUnitSphere;
        randomDirection.y = 0; // Nie zmieniaj wysoko�ci

        targetPosition = transform.position + randomDirection * moveDistance;
    }
}
