﻿// ***********************************************************
// Written by Heyworks Unity Studio http://unity.heyworks.com/
// ***********************************************************
using UnityEngine;

/// <summary>
/// Gyroscope controller that works with any device orientation.
/// </summary>
public class HeadMovementiOS : MonoBehaviour 
{
	private bool gyroEnabled = true;
	private const float lowPassFilterFactor = 1.0f;

	private readonly Quaternion baseIdentity =  Quaternion.Euler(90, 0, 0);
	private readonly Quaternion landscapeRight =  Quaternion.Euler(0, 0, 90);
	private readonly Quaternion landscapeLeft =  Quaternion.Euler(0, 0, -90);
	private readonly Quaternion upsideDown =  Quaternion.Euler(0, 0, 180);
	
	private Quaternion cameraBase =  Quaternion.identity;
	private Quaternion calibration =  Quaternion.identity;
	private Quaternion baseOrientation =  Quaternion.Euler(90, 0, 0);
	private Quaternion baseOrientationRotationFix =  Quaternion.identity;

	private Quaternion referanceRotation = Quaternion.identity;
	private bool debug = true;

	protected void Start () 
	{
		AttachGyro();
	}

	protected void Update() 
	{
		if (!gyroEnabled)
			return;
		transform.rotation = Quaternion.Slerp(transform.rotation,
			cameraBase * ( ConvertRotation(referanceRotation * Input.gyro.attitude)), lowPassFilterFactor);
	}

	/// <summary>
	/// Attaches gyro controller to the transform.
	/// </summary>
	private void AttachGyro()
	{
		gyroEnabled = true;
		ResetBaseOrientation();
		UpdateCalibration(true);
		UpdateCameraBaseRotation(true);
		RecalculateReferenceRotation();
	}

	/// <summary>
	/// Update the gyro calibration.
	/// </summary>
	private void UpdateCalibration(bool onlyHorizontal)
	{
		if (onlyHorizontal)
		{
			var fw = (Input.gyro.attitude) * (-Vector3.forward);
			fw.z = 0;
			if (fw == Vector3.zero)
			{
				calibration = Quaternion.identity;
			}
			else
			{
				calibration = (Quaternion.FromToRotation(baseOrientationRotationFix * Vector3.up, fw));
			}
		}
		else
		{
			calibration = Input.gyro.attitude;
		}
	}
	
	/// <summary>
	/// Update the camera base rotation.
	/// </summary>
	/// <param name='onlyHorizontal'>
	/// Only y rotation.
	/// </param>
	private void UpdateCameraBaseRotation(bool onlyHorizontal)
	{
		if (onlyHorizontal)
		{
			var fw = transform.forward;
			fw.y = 0;
			if (fw == Vector3.zero)
			{
				cameraBase = Quaternion.identity;
			}
			else
			{
				cameraBase = Quaternion.FromToRotation(Vector3.forward, fw);
			}
		}
		else
		{
			cameraBase = transform.rotation;
		}
	}
	
	/// <summary>
	/// Converts the rotation from right handed to left handed.
	/// </summary>
	/// <returns>
	/// The result rotation.
	/// </returns>
	/// <param name='q'>
	/// The rotation to convert.
	/// </param>
	private static Quaternion ConvertRotation(Quaternion q)
	{

		return new Quaternion(q.x, q.y, -q.z, -q.w);	
	}
		
	/// <summary>
	/// Recalculates reference system.
	/// </summary>
	private void ResetBaseOrientation()
	{
		baseOrientationRotationFix = Quaternion.identity;
		baseOrientation = baseOrientationRotationFix * baseIdentity;
	}

	/// <summary>
	/// Recalculates reference rotation.
	/// </summary>
	private void RecalculateReferenceRotation()
	{
		referanceRotation = Quaternion.Inverse(baseOrientation)*Quaternion.Inverse(calibration);
	}
}