using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.IMGUI.Controls;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class VolumeBox : MonoBehaviour {

	private BoxCollider m_boxCollider;

	public Color color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

	public Color wireColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

	public UnityEvent onTriggerEnter;

	public UnityEvent onTriggerStay;

	public UnityEvent onTriggerExit;

	public BoxCollider GetBoxCollider() {
		if (!m_boxCollider) {
			m_boxCollider = GetComponent<BoxCollider>() ?? gameObject.AddComponent<BoxCollider>();
			m_boxCollider.hideFlags = HideFlags.HideInInspector;
			m_boxCollider.isTrigger = true;
		}
		return m_boxCollider;
	}

	public void OnEnable() {
		GetBoxCollider();
	}

	void OnTriggerEnter() {
		onTriggerEnter.Invoke();
	}

	void OnTriggerStay() {
		onTriggerStay.Invoke();
	}

	void OnTriggerExit() {
		onTriggerEnter.Invoke();
	}

#if UNITY_EDITOR
	private void OnDrawGizmos() {
		GetBoxCollider();
		Gizmos.color = color;
		Gizmos.DrawCube(m_boxCollider.center + transform.position, Vector3.Scale(m_boxCollider.size, transform.lossyScale));
		Gizmos.color = wireColor;
		Gizmos.DrawWireCube(m_boxCollider.center + transform.position, Vector3.Scale(m_boxCollider.size, transform.lossyScale));
	}
#endif
}
