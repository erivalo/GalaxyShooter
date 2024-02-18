using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private identify
    // data type (int, floats, bool, strings)
    // every variable has a NAME
    // option value assigned

    [SerializeField]
    GameObject _laserPrefab;
    // fireRate is 0.25f
    // canFire -- has the amount of time between firing passed?
    // Time.time
    [SerializeField]
    float _fireRate = 0.25f;
    [SerializeField]
    float _speed = 5.0f;
    float _canFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(Time.time > _canFire)
        {
            // spawn my laser
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
            _canFire = Time.time + _fireRate;
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(horizontalInput * _speed * Time.deltaTime * Vector3.right);
        transform.Translate(_speed * Time.deltaTime * verticalInput * Vector3.up);

        // if player on the y is greater than 0
        // set player position to 0
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        //if(transform.position.x > 8.2)
        //{
        //    transform.position = new Vector3(8.2f, transform.position.y, 0);
        //}
        //else if(transform.position.x < -8.2)
        //{
        //    transform.position = new Vector3(-8.2f, transform.position.y, 0);
        //}

        // if player position on the x is greater than 9.5
        // position on the x needs to be -9.5
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }
}
