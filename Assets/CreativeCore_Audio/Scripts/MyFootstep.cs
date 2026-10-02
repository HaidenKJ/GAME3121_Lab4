using UnityEngine;
using System.Collections; // For arrays
using System.Collections.Generic; // For lists

public class MyFootstep : MonoBehaviour
{
    public List<AudioClip> GrassSteps = new List<AudioClip>(); 
    public List<AudioClip> WaterSteps = new List<AudioClip>(); 
    public List<AudioClip> CaveSteps = new List<AudioClip>(); 
    // Lists above were assaignned in the inspector with audio clips for each surface type.

    private enum SurfaceType{Grass,Water,Cave};
    private SurfaceType surface;
    private List<AudioClip> currentSurfaceSteps;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        surface = SurfaceType.Grass; // Default surface type
        currentSurfaceSteps = GrassSteps; // Default audio clips
    }

    public void PlayStep()
    {
        if (currentSurfaceSteps == null) return;
        AudioClip clip = currentSurfaceSteps[Random.Range(0, currentSurfaceSteps.Count)];
        audioSource.PlayOneShot(clip);
    }

    private void SelectStepList()
    {
        switch(surface)
        {
            case SurfaceType.Grass:
                currentSurfaceSteps = GrassSteps;
                break;
            case SurfaceType.Water:
                currentSurfaceSteps = WaterSteps;
                break;
            case SurfaceType.Cave:
                currentSurfaceSteps = CaveSteps;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Determine the surface type based on the tag of the object hit
        if (hit.collider.CompareTag("Grass"))
        {
            surface = SurfaceType.Grass;
        }
        else if (hit.collider.CompareTag("Water"))
        {
            surface = SurfaceType.Water;
        }
        else if (hit.collider.CompareTag("Cave"))
        {
            surface = SurfaceType.Cave;
        }
        SelectStepList();
    }
}
