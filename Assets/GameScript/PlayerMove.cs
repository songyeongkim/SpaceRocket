using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float boostSpeed;
    public float forwardSpeed;
    public float moveSpeed;
    public RectTransform gageBar;
    float gageScale = 0;
    Rigidbody rocketRigid;
    float xMove;
    float yMove;
    bool canLaunch;
    bool nowLaunch;
    public bool nowGame;
    float rocketScale;
    public UIManager uiManager;
    public Transform goalPos;
    public ParticleSystem boosterEffect;
    public ParticleSystem boosterFire;

    private void Awake()
    {
        rocketRigid = GetComponent<Rigidbody>();
        canLaunch = true;
        nowLaunch = true;
        nowGame = true;
        rocketScale = 1;
        boosterEffect.Stop();
        boosterFire.Stop();
    }

    void Update()
    {
        if(nowGame)
        {
            if (!nowLaunch)
                RoketMove();

            if (canLaunch)
                RocketLaunch();
        }

        if (transform.position.z > goalPos.position.z && nowGame)
        {
            GameClearCheck();
            nowGame = false;
        }
            
    }

    void RocketLaunch()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            nowLaunch = true;

            gageScale += 0.2f;
            gageBar.localScale = new Vector3(gageScale, 0.2f, 1);
            if (gageScale >= 10)
                gageScale = 0;

            rocketScale -= 0.1f;
            if (rocketScale < 0.7f)
                rocketScale = 0.7f;
            transform.localScale = new Vector3(1,rocketScale,1);

            //float posZ = transform.position.z;
            //posZ -= 0.2f;
            //transform.position = new Vector3(transform.position.x, transform.position.y, posZ);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            nowLaunch = false;

            boostSpeed = gageScale * 100;
            rocketRigid.AddForce(Vector3.forward * boostSpeed, ForceMode.Impulse);
            rocketRigid.velocity = Vector3.forward * forwardSpeed;
            rocketScale = 1;
            transform.localScale = new Vector3(1, rocketScale, 1);

            canLaunch = false;

            StartCoroutine(GageInit());
        }
    }

    void RoketMove()
    {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        Vector3 getVal = new Vector3(xMove, yMove, 0) * moveSpeed;

        rocketRigid.velocity += getVal;
    }

    IEnumerator GageInit()
    {
        boosterEffect.Play();
        boosterFire.Play();
        while (gageScale > 0)
        {
            yield return new WaitForSeconds(0.01f);
            gageScale -= 0.1f;
            gageBar.localScale = new Vector3(gageScale, 0.2f, 1);
        }
        gageBar.localScale = new Vector3(0, 0.2f, 1);
        if(gageBar.localScale.x == 0)
        {
            canLaunch = true;
            boosterEffect.Stop();
            boosterFire.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            uiManager.GameOver();
        }

        if (collision.gameObject.tag == "goal")
        {
            GameClearCheck();
        }
    }

    void GameClearCheck()
    {
        uiManager.GameClear();
    }
}
