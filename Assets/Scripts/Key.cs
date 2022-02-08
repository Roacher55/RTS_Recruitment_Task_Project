using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Material orginalMaterial;
    [SerializeField] Material selectedMaterial;
    MeshRenderer meshRenderer;
    [SerializeField] GameObject keyModel;
    GameObject toolTipKey;
    GameHelper gameHelper;

    private void Start()
    {
        meshRenderer = keyModel.GetComponent<MeshRenderer>();
        orginalMaterial = meshRenderer.material;
        gameHelper = FindObjectOfType<GameHelper>();
    }

    private void OnMouseEnter()
    {
        meshRenderer.material = selectedMaterial;
    }

    private void OnMouseExit()
    {
        meshRenderer.material = orginalMaterial;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameHelper.toolTipKey.SetActive(true);
        }
    }
}
