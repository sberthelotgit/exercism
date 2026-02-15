public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        var other = obj as FacialFeatures;
        return this.EyeColor == other!.EyeColor && this.PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {

        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        var other = obj as Identity;
        return this.Email == other!.Email && this.FacialFeatures.Equals(other.FacialFeatures);
    }

    public override int GetHashCode()
    {

        return HashCode.Combine(Email, FacialFeatures);
    }
}

public class Authenticator
{

    public HashSet<Identity> registeredIndentity = new HashSet<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(new Identity("admin@exerc.ism", new FacialFeatures("green", 0.9m)));
    }

    public bool Register(Identity identity)
    {
        return registeredIndentity.Add(identity);
    }

    public bool IsRegistered(Identity identity)
    {
        return registeredIndentity.Contains(identity);
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return object.ReferenceEquals(identityA, identityB);
    }
}
