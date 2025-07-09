using UnityEngine;

public class EnemigoDisparador : Enemigo
{
    public GameObject Character;
    public GameObject BulletPrefab;

    private float lastShoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Character.transform.position - transform.position;
        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        }

        float distance = Mathf.Abs(Character.transform.position.x - transform.position.x);

        if (distance < 10.0f && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.left;
        else direction = Vector3.right;

        GameObject EnemyBullet = Instantiate(BulletPrefab, transform.position + direction * 0.2f, Quaternion.identity);
        EnemyBullet.GetComponent<EnemyBullet>().setDirection(direction);
    }

}
