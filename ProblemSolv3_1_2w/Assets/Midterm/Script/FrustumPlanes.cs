using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 프러스텀 플레인 클래스
public class FrustumPlanes
{
    private readonly Plane[] planes;

    public FrustumPlanes(Camera camera)
    {
        planes = GeometryUtility.CalculateFrustumPlanes(camera);
    }

    public bool IsInsideFrustum(Vector3 point)
    {
        foreach (var plane in planes)
        {
            if (!plane.GetSide(point))
            {

                return false;
            }
        }
        return true;
    }
}
