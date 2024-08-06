using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class StarsBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float scale = GameManager.Instance.gameSettings.WorldScale;

        transform.position = new Vector3 (transform.position.x, transform.position.y * scale, 0);

        transform.localScale = new Vector3(transform.localScale.x * scale, transform.localScale.y, transform.localScale.z);

        ParticleSystem pS = GetComponent<ParticleSystem>();
        var main = pS.main;
        main.startLifetimeMultiplier *= scale;

        pS.Play();
    }
}
