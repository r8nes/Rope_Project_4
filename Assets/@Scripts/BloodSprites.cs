using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodSprites : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public List<Sprite> Sprites;

    private void Start()
    {
        StartCoroutine(StartSprites());
    }

    private IEnumerator StartSprites()
    {
        for (int i = 0; i < Sprites.Count; i++)
        {
            Sprite.sprite = Sprites[i];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);

        while (Sprite.color.a > 0)
        {
            Color spriteColor = Sprite.color;
            spriteColor.a -= 0.1f;
            Sprite.color = spriteColor;

            yield return new WaitForSeconds(0.03f);
        }

        Destroy(gameObject);
    }
}
