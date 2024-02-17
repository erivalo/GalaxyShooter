using UnityEngine;

public class Player : MonoBehaviour
{
    // public or private identify
    // data type (int, floats, bool, strings)
    // every variable has a NAME
    // option value assigned

    [SerializeField]
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);
        transform.Translate(speed * Time.deltaTime * verticalInput * Vector3.up);

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
