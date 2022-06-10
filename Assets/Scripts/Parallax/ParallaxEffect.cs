using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitsSizeY;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture2D = sprite.texture as Texture2D;
        textureUnitSizeX = (texture2D.width / sprite.pixelsPerUnit) * transform.localScale.x;
        textureUnitsSizeY = (texture2D.height / sprite.pixelsPerUnit) * transform.localScale.y;
    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
                                            deltaMovement.y * parallaxEffectMultiplier.y,
                                            deltaMovement.z);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, cameraTransform.position.y);
        }

        if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitsSizeY)
        {
            float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitsSizeY;
            transform.position = new Vector3(cameraTransform.position.x , cameraTransform.position.y + offsetPositionY);
        }
    }
}
