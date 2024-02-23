using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToTargetAgent : Agent
{

    [SerializeField] private Transform env;
    [SerializeField] private Transform target;
    [SerializeField] private SpriteRenderer background;

    private int stepsTaken; // Track the steps taken in the current episode



    public override void OnEpisodeBegin()
    {
        stepsTaken = 0; // Reset steps at the beginning of an episode
        transform.localPosition = new Vector3(Random.Range(-3.5f, -1.5f), Random.Range(-3.5f, 3.5f));
        target.localPosition = new Vector3(Random.Range(1.5f, 3.5f), Random.Range(-3.5f, 3.5f));

        env.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.rotation = Quaternion.identity;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation((Vector2)transform.localPosition);
        sensor.AddObservation((Vector2)target.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        stepsTaken++; // Increment steps taken
        float moveX = actions.ContinuousActions[0];
        float moveY = actions.ContinuousActions[1];
        float movementSpeed = 5f;

        transform.localPosition += new Vector3(moveX, moveY) * Time.deltaTime * movementSpeed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> actionSegment = actionsOut.ContinuousActions;

        actionSegment[0] = Input.GetAxisRaw("Horizontal");
        actionSegment[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Target target))
        {
            // Calculate reward based on steps taken
            // Example: Higher reward for fewer steps, adjust the formula as needed
            float reward = Mathf.Max(10, 20f - (stepsTaken * 0.1f));
            AddReward(reward);
            background.color = Color.green;
            EndEpisode();
        }

        else if (collision.TryGetComponent(out Wall wall))
        {
            AddReward(-2f);
            background.color = Color.red;
            EndEpisode();
        }
    }
}
