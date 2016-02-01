using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {

    public Light TorchLightLeft, TourchLightRight;
    public ParticleSystem FlameLeft, FlameRight, SmokeLeft, SmokeRight;

    public float initialLightSize = 10;

    private bool LightsFlaring = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        
	}

    public IEnumerator FlareLights(Color lightColor, Color smokeColor, float lightIntensity)
    {
        if (LightsFlaring)
            yield return null;
        LightsFlaring = true;
        Color initialCol = TorchLightLeft.color;
        float initialInt = TorchLightLeft.intensity;

        Color flameInit = FlameLeft.startColor;
        Color smokeInit = SmokeLeft.startColor;

        //while (FlameLeft.startColor != lightColor)
        //{
        //    Color.Lerp(FlameLeft.startColor, lightColor, 1 / Time.deltaTime);
        //    Color.Lerp(FlameRight.startColor, lightColor, 1 / Time.deltaTime);
        //    Color.Lerp(SmokeRight.startColor, smokeColor, 1 / Time.deltaTime);
        //    Color.Lerp(SmokeLeft.startColor, smokeColor, 1 / Time.deltaTime);

        //    Color.Lerp(TourchLightRight.color, lightColor, 1 / Time.deltaTime);
        //    Color.Lerp(TorchLightLeft.color, lightColor, 1 / Time.deltaTime);
        //    Mathf.Lerp(TorchLightLeft.intensity, lightIntensity, 1 / Time.deltaTime);
        //    Mathf.Lerp(TourchLightRight.intensity, lightIntensity, 1 / Time.deltaTime);
        //}

        FlameLeft.startColor = FlameRight.startColor = lightColor;
        SmokeLeft.startColor = SmokeRight.startColor = smokeColor;
        TourchLightRight.color = TorchLightLeft.color = lightColor;
        TourchLightRight.intensity = TorchLightLeft.intensity = lightIntensity;

        yield return new WaitForSeconds(1f);

        //while (FlameLeft.startColor != flameInit)
        //{
        //    Color.Lerp(FlameLeft.startColor, flameInit, 1 / Time.deltaTime);
        //    Color.Lerp(FlameRight.startColor, flameInit, 1 / Time.deltaTime);
        //    Color.Lerp(SmokeRight.startColor, smokeInit, 1 / Time.deltaTime);
        //    Color.Lerp(SmokeLeft.startColor, smokeInit, 1 / Time.deltaTime);

        //    Color.Lerp(TourchLightRight.color, initialCol, 1 / Time.deltaTime);
        //    Color.Lerp(TorchLightLeft.color, initialCol, 1 / Time.deltaTime);
        //    Mathf.Lerp(TorchLightLeft.intensity, initialInt, 1 / Time.deltaTime);
        //    Mathf.Lerp(TourchLightRight.intensity, initialInt, 1 / Time.deltaTime);
        //}

        FlameLeft.startColor = FlameRight.startColor = flameInit;
        SmokeLeft.startColor = SmokeRight.startColor = smokeInit;
        TourchLightRight.color = TorchLightLeft.color = initialCol;
        TourchLightRight.intensity = TorchLightLeft.intensity = initialInt;
        LightsFlaring = false;
    }
}
