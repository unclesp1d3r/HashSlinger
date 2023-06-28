namespace HashSlinger.Shared.Models.Enums;

/// <summary>Represents the format of a hashlist.</summary>
public enum HashListFormats
{
    /// <summary>Represents a standard utf8, newline-delimited text file.</summary>
    TextFile,

    /// <summary>Represents a hashcat .hccapx file.</summary>
    HCCAPXFile,

    /// <summary>Represents a hashcat .hccap file.</summary>
    BinaryFile
}
