
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class ShortcutKey_Button : MonoBehaviour
{
    public InputActionReference reference;
    public Button button;

    private void Awake()
    {
        if (button == null)
        {
            button = GetComponent<Button>();
            if (button == null)
                button = GetComponentInParent<Button>();
        }
    }

    private void OnEnable()
    {
        reference.action.performed += OnPerformed;
        reference.action.Enable();

        if (!ShortcutKey.EnableKVs.ContainsKey(reference))
        {
            ShortcutKey.EnableKVs.Add(reference, new List<GameObject>() { gameObject });
        }
        else
        {
            ShortcutKey.EnableKVs[reference].Add(gameObject);
        }
    }
    private void OnDisable()
    {
        reference.action.performed -= OnPerformed;
        ShortcutKey.EnableKVs[reference].Remove(gameObject);
    }
    private void OnPerformed(InputAction.CallbackContext context)
    {
        if (ShortcutKey.EnableKVs[reference].Last() != gameObject) return;
        if (button.interactable)
        {
            Debug.Log(gameObject.name + " ShortcutKey_Button OnPerformed Invoke");
            button.onClick?.Invoke();
        }
    }
}