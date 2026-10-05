using UnityEngine;
using System.Collections; // For arrays
using System.Collections.Generic; // For lists

public class MyLabFootSteps : MonoBehaviour
{
    public List<AudioClip> StoneSteps = new List<AudioClip>(); 
    public List<AudioClip> FirepitSteps = new List<AudioClip>(); 
    // Lists above were assaignned in the inspector with audio clips for each surface type.

    private enum SurfaceType{Stone, Firepit};
    private SurfaceType Lsurface;
    private List<AudioClip> currentLabSurfaceSteps;
    private AudioSource LaudioSource;
    void Start()
    {
        LaudioSource = GetComponent<AudioSource>();
        Lsurface = SurfaceType.Stone; // Default surface type
        currentLabSurfaceSteps = StoneSteps; // Default audio clips
    }

    public void PlayStep()
    {
        if (currentLabSurfaceSteps == null) return;
        AudioClip clip = currentLabSurfaceSteps[Random.Range(0, currentLabSurfaceSteps.Count)];
        LaudioSource.PlayOneShot(clip);
    }

    private void SelectStepList()
    {
        switch(Lsurface)
        {
             case SurfaceType.Stone:
                 currentLabSurfaceSteps = StoneSteps;
                 break;
             case SurfaceType.Firepit:
                 currentLabSurfaceSteps = FirepitSteps;
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
        if (hit.collider.CompareTag("MarbleFloor"))
         {
             Lsurface = SurfaceType.Stone;
         }
         else if (hit.collider.CompareTag("Firepit"))
         {
             Lsurface = SurfaceType.Firepit;
         }
        // else if (hit.collider.CompareTag("Cave"))
        // {
        //     Lsurface = SurfaceType.Cave;
        // }
        SelectStepList();
    }
}
