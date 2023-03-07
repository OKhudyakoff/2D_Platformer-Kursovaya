using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Trap : MonoBehaviour
{
    [SerializeField] private bool isStatic;
    [SerializeField] private Transform[] target_points;
    [SerializeField] private int current_target_point_index = 0;
    [SerializeField] private int move_speed;

    private void Update()
    {
        if (!isStatic)
        {
            Move();
        }
    }

    private void Move()
    {
        if (transform.position == target_points[current_target_point_index].position)
        {
            IncreaseTargetInt();
        }

        transform.position = Vector2.MoveTowards(transform.position,
            target_points[current_target_point_index].position,
            move_speed * Time.deltaTime);
    }

    private void IncreaseTargetInt()
    {
        current_target_point_index++;
        if (current_target_point_index >= target_points.Length)
        {
            current_target_point_index = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == LevelManager.Instance.CurrentPlayer().Player_Collider)
        {
            other.isTrigger = true;
            LevelManager.Instance.levelLoader.RestartLevel();
        }
    }
}