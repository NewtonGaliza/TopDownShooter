using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float bulletSpped;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpped * Time.deltaTime); 

        //destruir a bala
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if(posicaoNaCamera.y > 1 ||
          posicaoNaCamera.y < -1 ||
          posicaoNaCamera.x > 1 ||
          posicaoNaCamera.x < -0.5)
        {
            Destroy(this.gameObject);
        }

    }
}
