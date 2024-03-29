using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    float _speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with: {other.name}");
        if (other.tag == "Player")
        {
            // access the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TripleShotPowerUpOn();
            }
            // destroy
            Destroy(this.gameObject);
        }
    }
}
