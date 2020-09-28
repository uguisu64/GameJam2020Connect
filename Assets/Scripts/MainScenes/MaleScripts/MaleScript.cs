using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleScript : MonoBehaviour
{

    private float speed;

    void Start()
    {
        speed = 0.64f;
    }

    void Update()
    {
        //左右に移動する
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void HitOthers()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position += new Vector3(speed, 0.64f), Vector3.back, 10);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position += new Vector3(speed, 0.64f), Vector3.back, 10);

        if (hit.collider || hit2.collider)
        {
            if (hit.collider.tag == "Imortal" || hit.collider.tag == "Block"|| hit2.collider.tag == "Imortal" || hit2.collider.tag == "Block")
            {
                MaleReverse();
                return;
            }
        }
        MaleJump();
    }

    public void MaleJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10);
    }

    public void MaleReverse()
    {
        transform.position -= Vector3.right * speed;
        transform.eulerAngles += new Vector3(0, 180, 0);
        speed *= -1;
    }
}
