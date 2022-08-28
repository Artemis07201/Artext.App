namespace Artext.Structures.FileExtension;

public class DotArtIO
{
    public DotArtIO(string FileLocation)
    {
        this.File = new(FileLocation);
    }

    public string FileExtension => "Artext";

    protected File F { get; }
}
