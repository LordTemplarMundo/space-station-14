using System.Threading.Tasks;
using Content.IntegrationTests.Tests.Interaction;
using NUnit.Framework;

namespace Content.IntegrationTests.Tests.Construction.Interaction;

public sealed class WallConstruction : InteractionTest
{
    public const string Girder = "Girder";
    public const string WallSolid = "WallSolid";
    public const string Wall = "Wall";

    [Test]
    public async Task ConstructWall()
    {
        await StartConstruction(Wall);
        await Interact(Steel, 2);
        Assert.IsNull(Hands.ActiveHandEntity);
        AssertPrototype(Girder);
        await Interact(Steel, 2);
        Assert.IsNull(Hands.ActiveHandEntity);
        AssertPrototype(WallSolid);
    }

    [Test]
    public async Task DeconstructWall()
    {
        await StartDeconstruction(WallSolid);
        await Interact(Weld);
        AssertPrototype(Girder);
        await Interact(Wrench, Screw);
        AssertDeleted();
        await AssertEntityLookup((Steel, 4));
    }
}

