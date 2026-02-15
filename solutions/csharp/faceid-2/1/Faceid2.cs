public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public virtual bool Equals(FacialFeatures? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return this.EyeColor == obj.EyeColor && this.PhiltrumWidth == obj.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        var code = new HashCode();
        code.Add(EyeColor);
        code.Add(PhiltrumWidth);
        return code.ToHashCode();
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

    public virtual bool Equals(Identity? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return this.Email == obj.Email && this.FacialFeatures.Equals(obj.FacialFeatures);
    }

    public override int GetHashCode()
    {
        var code = new HashCode();
        code.Add(Email);
        code.Add(FacialFeatures.EyeColor);
        code.Add(FacialFeatures.PhiltrumWidth);
        return code.ToHashCode();
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
