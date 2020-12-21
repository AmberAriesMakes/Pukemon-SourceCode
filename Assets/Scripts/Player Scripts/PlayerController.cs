using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask Solid;
    public LayerMask EnemyGrass;
    public float movementSpeed;
    public bool isMoving;
    public event Action OnEncountered;
    private Animator Animator;
    private Vector2 input;
    // Start is called before the first frame update
    Save playerPosData;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        playerPosData = FindObjectOfType<Save>();
        playerPosData.PlayerPosLoad();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
   public void HandleUpdate()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                Animator.SetFloat("MoveX", input.x);
                Animator.SetFloat("MoveY", input.y);

                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;
                if (input.x != 0) input.y = 0;
                if (IsNotSolid(targetPosition))
                {
                    StartCoroutine(Move(targetPosition));

                }
            }
            Animator.SetBool("Walking", isMoving);
        }

        IEnumerator Move(Vector3 targetPosition)
        {
            isMoving = true;
            while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = targetPosition;
            isMoving = false;

            IsEncounter();
        }
        bool IsNotSolid(Vector3 targetPosition)
        {
            if (Physics2D.OverlapCircle(targetPosition, 0.3f, Solid) != null)
            {
                return false;
            }
            return true;
        }
    }

    private void IsEncounter()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, EnemyGrass) !=null)
        {
            if(UnityEngine.Random.Range(1, 21) <= 10)
            {
                Debug.Log("Fight!");
                Animator.SetBool("Walking", false);
                OnEncountered();
            }

        }
    }
   
}
