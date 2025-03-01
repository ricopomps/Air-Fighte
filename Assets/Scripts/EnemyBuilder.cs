using UnityEngine;
using UnityEngine.Splines;
public class EnemyBuilder
{
    GameObject EnemyPrefab;
    SplineContainer Spline;
    GameObject WeaponPrefab;
    float Speed;

    public EnemyBuilder SetBasePrefab(GameObject prefab)
    {
        EnemyPrefab = prefab;
        return this;
    }

    public EnemyBuilder SetSpline(SplineContainer spline)
    {
        Spline = spline;
        return this;
    }

    public EnemyBuilder SetWeaponPrefab(GameObject prefab)
    {
        WeaponPrefab = prefab;
        return this;
    }

    public EnemyBuilder SetSpeed(float speed)
    {
        Speed = speed;
        return this;
    }

    public GameObject Build()
    {
        GameObject instance = GameObject.Instantiate(EnemyPrefab);

        SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
        splineAnimate.Container = Spline;
        splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
        splineAnimate.ObjectUpAxis = SplineComponent.AlignAxis.ZAxis;
        splineAnimate.ObjectForwardAxis = SplineComponent.AlignAxis.YAxis;
        splineAnimate.MaxSpeed = Speed;
        splineAnimate.PlayOnAwake = true;
        splineAnimate.Play();

        instance.transform.position = Spline.EvaluatePosition(0f);

        return instance;
    }
}