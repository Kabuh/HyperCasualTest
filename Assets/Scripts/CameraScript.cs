using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private float startCamSpeed;
    [SerializeField]
    private float camSpeedDelta;

    [SerializeField]
    private float unloadDuration;
    [SerializeField]
    private Unload unloadSwitch;

    [SerializeField]
    private GameObject fuelLiquid;
    [SerializeField]
    private GameObject starLiquid;

    private float liquidMaxSize = 0.9f;

    private float camSpeed;

    // Start is called before the first frame update
    void Start()
    {
        camSpeed = startCamSpeed;
        StartCoroutine(panDown());
    }

    IEnumerator panDown() {
        while (camSpeed > 0) {
            this.transform.position -= Vector3.up * camSpeed;
            camSpeed -= camSpeedDelta;
            yield return null;
        }
        StartCoroutine(UnloadFX());
    }

    IEnumerator UnloadFX() {
        unloadSwitch.StartUnload();
        ScoreKeeper.Instance.FillScore(unloadDuration);
        StartCoroutine(FillLiquids());
        yield return new WaitForSeconds(unloadDuration);
        unloadSwitch.StopUnload();
    }

    IEnumerator FillLiquids() {
        float timePassed = 0;
        float fuelFract = ScoreKeeper.Instance.fuelfCollectedFract();
        float starFract = ScoreKeeper.Instance.starfCollectedFract();
        while (timePassed < unloadDuration) {
            timePassed += Time.deltaTime;
            Fill(fuelLiquid, (Time.deltaTime / unloadDuration)*(fuelFract* liquidMaxSize));
            Fill(starLiquid, (Time.deltaTime / unloadDuration) * (starFract * liquidMaxSize));
            
            yield return null;
        }
    }

    void Fill(GameObject GO, float fract) {
        Vector3 growVect = GO.transform.localScale;
        growVect.y += fract;
        GO.transform.localScale = growVect;

        GO.transform.position += Vector3.up * fract;
    }
}
