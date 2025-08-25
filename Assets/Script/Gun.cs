using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float rotateOffset = 180f;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shotDelay= 0.15f;
    private float nextShot;
    [SerializeField] private int maxAmmor = 24;
    public int currentAmmor;

    void Start()
    {
        currentAmmor = maxAmmor;
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        Shot();
        Reload();
    }
    void RotateGun()
    {
        if(Input.mousePosition.x < 0 || Input.mousePosition.x >Screen.width || Input.mousePosition.y  <0
            || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        if(angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shot()
    {
        if(Input.GetMouseButtonDown(0) && currentAmmor >0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmmor--;
        }
    }
    void Reload()
    {
        if(Input.GetMouseButtonDown(1) && currentAmmor < maxAmmor)
        {
            currentAmmor = maxAmmor;
        }
    }
}
