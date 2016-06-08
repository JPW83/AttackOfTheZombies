using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour {

    public ParticleSystem zombieDeath;
    private PerlinShake perlinshake;
    public UIFunctions UIFunction;
    public int playerScoreValue;
    

    // Use this for initialization
    void Start ()
    {
        
        perlinshake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PerlinShake>();
        UIFunction = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIFunctions>();
        
	}

    // Update is called once per frame
    void Update()
    { }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hazard")
        {
            perlinshake.PlayShake();
            Destroy(Instantiate(zombieDeath, this.transform.position, Quaternion.identity), zombieDeath.startLifetime);
            Destroy(this.gameObject);
            UIFunction.addOne();

        }

        if (other.gameObject.tag == "House")
        {
            Destroy(this.gameObject);
            UIFunction.minusOne();
        }

    }

    
}
