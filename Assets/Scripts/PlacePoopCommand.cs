using UnityEngine;

public class PlacePoopCommand : ICommand
{
    private readonly PoopPlacer poopPlacer;
    private readonly Transform corgiTransform;

    public PlacePoopCommand(PoopPlacer poopPlacer, Transform corgiTransform)
    {
        this.poopPlacer = poopPlacer;
        this.corgiTransform = corgiTransform;
    }

    public void Execute()
    {
        poopPlacer.Place(corgiTransform.position);
    }
}