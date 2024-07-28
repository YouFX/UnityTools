using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShortcutKey : MonoBehaviour
{
    public InputActionReference reference;
    public UnityEvent<InputAction.CallbackContext> performed;

    public static Dictionary<InputActionReference, List<GameObject>> EnableKVs = new Dictionary<InputActionReference, List<GameObject>>();

    private void OnEnable()
    {
        reference.action.performed += OnPerformed;
        reference.action.Enable();

        if (!EnableKVs.ContainsKey(reference))
        {
            EnableKVs.Add(reference, new List<GameObject>() { gameObject });
        }
        else
        {
            EnableKVs[reference].Add(gameObject);
        }
    }
    private void OnDisable()
    {
        reference.action.performed -= OnPerformed;
        // reference.action.Disable();
        EnableKVs[reference].Remove(gameObject);
    }
    private void OnPerformed(InputAction.CallbackContext context)
    {
        if (EnableKVs[reference].Last() != gameObject) return;
        performed?.Invoke(context);
    }
}