using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class Brain : MonoBehaviour
{
    public int dnaLength = 1;
    public float timeAlive = 0;
    public float distanceTravelled = 0;
    Vector3 startPosition;
    public DNA dna;

    private ThirdPersonCharacter m_Character;
    private Vector3 m_Move;
    private bool m_Jump;
    bool alive = true;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "dead")
        {
            alive = false;
        }
    }

    public void Init()
    {
        //initialise DNA
        //0 forward
        //1 back
        //2 left
        //3 right
        //4 jump
        //5 crouch
        dna = new DNA(dnaLength, 6);
        m_Character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
        startPosition = this.transform.position;
    }

    // FixedUpdate is called in sync with Physics
    private void FixedUpdate()
    {
        //read DNA
        float horizontal = 0;
        float vertical = 0;
        bool crouch = false;
        if (dna.GetGene(0) == 0) { vertical = 1; }
        else if (dna.GetGene(0) == 1) { vertical = -1; }
        else if (dna.GetGene(0) == 2) { horizontal = -1; }
        else if (dna.GetGene(0) == 3) { horizontal = 1; }
        else if (dna.GetGene(0) == 4) { m_Jump = true; }
        else if (dna.GetGene(0) == 5) { crouch = true; }

        m_Move = vertical * Vector3.forward + horizontal * Vector3.right;
        m_Character.Move(m_Move, crouch, m_Jump);
        m_Jump = false;
        if (alive)
        {
            timeAlive += Time.deltaTime;
            distanceTravelled = Vector3.Distance(this.transform.position, startPosition);
        }
    }
}
