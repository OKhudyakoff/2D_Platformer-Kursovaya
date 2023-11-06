using UnityEngine;

public class MoveableTrap : MonoBehaviour
{
    [SerializeField] private Transform[] target_points;
    [SerializeField] private int move_speed;
    [SerializeField] private Transform moveableObject;
    private int current_target_point_index = 0;
    private bool isMoveBack = false;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (moveableObject.position == target_points[current_target_point_index].position)
        {
            ChangeTargetPoint();
        }

        moveableObject.position = Vector2.MoveTowards(moveableObject.position,
            target_points[current_target_point_index].position,
            move_speed * Time.deltaTime);
    }

    private void ChangeTargetPoint()
    {
        if (!isMoveBack)
        {
            if (current_target_point_index == target_points.Length - 1)
            {
                current_target_point_index--;
                isMoveBack = true;
            }
            else
            {
                current_target_point_index++;
            }
        }
        else
        {
            if (current_target_point_index == 0)
            {
                current_target_point_index++;
                isMoveBack = false;
            }
            else
            {
                current_target_point_index--;
            }
        }
    }
}