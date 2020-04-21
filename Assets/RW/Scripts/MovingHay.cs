using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHay : MonoBehaviour
{
    public float limitHayMov = 21;
    public GameObject limitRight;
    public GameObject limitLeft;
    public GameObject hayPrefab;

    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint; //The point from which the hay will to be shot.
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer; //A timer that to keep track whether the machine can shoot 



    // Start is called before the first frame update
    void Start()
    {
        limitLeft = GameObject.Find("limite izquierda"); //asignarlo automaticamente
    }

    // Update is called once per frame
    void Update()
    {
        float horizonalInput = Input.GetAxisRaw("Horizontal");
        if (horizonalInput < 0 && transform.position.x>limitLeft.transform.position.x)
        {
            transform.Translate(-transform.right * 10 * Time.deltaTime); //transform.right nos da la direccion local del objeto
        }
        if (horizonalInput > 0 && transform.position.x<limitRight.transform.position.x)
        {
            transform.Translate(transform.right * 10 * Time.deltaTime);
        }
        UpdateShooting();
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(hayPrefab, transform.position, Quaternion.identity); //quaternion->representation of rotations
        }
        */
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

}
