using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "States/Player/Walk")]
public class StateWalk : State<PlayerController>
{
    private Rigidbody2D rb;

    private PlayerInput input;

    [SerializeField] private float walkingSpeed;
    private Vector2 direction;
    private bool sprintKey;

    public override void init(PlayerController parent)
    {
        base.init(parent);

        if (rb == null) rb = parent.GetComponent<Rigidbody2D>();

        if (input == null) input = parent.GetComponentInChildren<PlayerInput>();
    }

    public override void CaptureInput()
    {
        direction = input.getMovement();
        sprintKey = input.getSprint();
    }

    public override void Update() { }

    public override void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * walkingSpeed, rb.velocity.y);
    }


    public override void ChangeState()
    {
        if (sprintKey)
        {
            runner.setState(typeof(StateSprint));
        }
    }

    public override void Exit() { }
}
