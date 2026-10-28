using UnityEngine;

public class StarsObserver : DayNightObserver
{
    [SerializeField] private SpriteRenderer[] stars;

    public override void OnTimeChanged(float time)
    {
        float alpha;

        if (time < 0.25f)
        {
            alpha = Mathf.Lerp(1f, 0.5f, Smooth(time / 0.25f));
        }
        else if (time < 0.5f)
        {
            alpha = Mathf.Lerp(
                0.5f, 0f, Smooth((time - 0.25f) / 0.25f));
        }
        else if (time < 0.75f)
        {
            alpha = 0f;
        }
        else
        {
            alpha = Mathf.Lerp(
                0f, 1f, Smooth((time - 0.75f) / 0.25f));
        }

        foreach (SpriteRenderer star in stars)
        {
            if (star == null)
                continue;

            Color color = star.color;
            color.a = alpha;
            star.color = color;
        }
    }

    private float Smooth(float t)
    {
        return Mathf.SmoothStep(0f, 1f, t);
    }
}
