using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	// Returns true if game object is visible by the specified camera,
	// otherwise returns false.
	public static bool isVisible(Renderer renderer, Camera camera) {
		if (renderer == null) {
			return false;
		}
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}

	public static bool isVisible(Bounds b, Camera c) {	
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(c);
		return GeometryUtility.TestPlanesAABB(planes, b);
	}
}
