using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonStoneSkill : Skill
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask PlayerLayerMask;
    [SerializeField] float range;
    [SerializeField] float rechargeTime;
    [SerializeField] GameObject particlePrefab;
    [SerializeField] float particleRechargeTime;

    public int numStones = 1;
    private int numStonesLeft;
    public GameObject stonePrefab;

    private float timer;
    private float particleTimer;


    // Start is called before the first frame update
    void Start()
    {
        numStonesLeft = numStones;
        timer = 0f;
    }

    private void Update()
    {
        if (timer >= rechargeTime && numStonesLeft < numStones)
        {
            numStonesLeft += 1;
            timer = 0;
        }

        timer += Time.deltaTime;
        particleTimer += Time.deltaTime;
    }

    public override void handleSkill(KeyCode k)
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, ~PlayerLayerMask))
        {
            if (Input.GetKey(k) && particleTimer >= particleRechargeTime)
            {
                Instantiate(particlePrefab, hit.point, transform.rotation * Quaternion.Euler(270f, 0f, 0f));
                particleTimer = 0;
            }
            
            if (Input.GetKeyUp(k) && numStonesLeft > 0)
            {
                Instantiate(stonePrefab, hit.point + new Vector3(0, 1, 0), Quaternion.identity);
                numStonesLeft -= 1;
            }
        }

    }
}
