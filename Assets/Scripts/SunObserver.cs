using System;
using UnityEngine;

[Serializable]
public class SunPoint
{
    [Range(0f, 1f)]
    public float time;

    public Vector2 position;

    public SunPoint(float time, Vector2 position)
    {
        this.time = time;
        this.position = position;
    }
}

public class SunObserver : DayNightObserver
{
    [SerializeField] private Transform sun;

    [SerializeField] private SunPoint[] points =
    {
        new SunPoint(0f, new Vector2(-8f, -1f)),
        new SunPoint(0.25f, new Vector2(-5f, 2f)),
        new SunPoint(0.5f, new Vector2(0f, 5f)),
        new SunPoint(0.75f, new Vector2(5f, 2f)),
        new SunPoint(1f, new Vector2(8f, -1f))
    };

    public override void OnTimeChanged(float time)
    {
        if (sun == null || points == null || points.Length == 0)
            return;

        if (points.Length == 1)
        {
            sun.position = points[0].position;
            return;
        }

        for (int i = 0; i < points.Length - 1; i++)
        {
            SunPoint a = points[i];
            SunPoint b = points[i + 1];

            if (time <= b.time)
            {
                float duration = b.time - a.time;
                float t = duration > 0f
                    ? Mathf.InverseLerp(a.time, b.time, time)
                    : 1f;

                t = Mathf.SmoothStep(0f, 1f, t);

                Vector2 position = Vector2.Lerp(
                    a.position, b.position, t);

                sun.position = new Vector3(
                    position.x,
                    position.y,
                    sun.position.z
                    );

                return;
            }
        }

        SunPoint last = points[points.Length - 1];
        sun.position = new Vector3(
            last.position.x,
            last.position.y,
            sun.position.z
            );
    }
}
