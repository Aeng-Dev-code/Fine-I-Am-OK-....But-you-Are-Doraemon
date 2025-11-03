using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Hand setting")]
    public Transform RightHand;
    public Transform LeftHand;
    public List<Item> inventory = new List<Item>();

    Vector3 _inputDirection;
    bool _isAttacking = false;
    bool _isInteract = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
        Attack(_isAttacking);
        Interact(_isInteract);
    }
    public void Update()
    {
        HandleInput();
    }
    public void AddItem(Item item) 
    {
        inventory.Add(item);
    }
    
    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _inputDirection = new Vector3(x, 0, y);
        if (Input.GetMouseButtonDown(0))
        {
            _isAttacking = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isInteract = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }

    }
    public void Attack(bool isAttacking) 
    {
        if (isAttacking) 
        {
            animator.SetTrigger("Attack");
            var e = InFront as Idestoryable;
            if (e != null)
            {
                e.TakeDamage(Damage);
                Debug.Log($"{gameObject.name} attacks for {Damage} damage.");
            }
            _isAttacking = false;
        }
    }
    private void Interact(bool interactable)
    {
        if (interactable)
        {
            IInteractable e = InFront as IInteractable;
            if (e != null) {
                e.Interact(this);
            }
            _isInteract = false;

        }
    }
    //เพิ่มเติมฟังก์ชันการรักษาและรับความเสียหาย

    private Vector3 lastCheckpoint;

    // ฟังก์ชันบันทึกตำแหน่ง
    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpoint = position;
    }

    // ฟังก์ชันรีเซ็ตตำแหน่งกลับไปยัง Checkpoint
    public void Respawn()
    {
        if (lastCheckpoint != Vector3.zero)
        {
            transform.position = lastCheckpoint;
            health = maxHealth; // ฟื้นพลังกลับมาด้วยถ้าต้องการ
            Debug.Log("Respawned at checkpoint!");
        }
        else
        {
            Debug.Log("No checkpoint set!");
        }
    }

}
