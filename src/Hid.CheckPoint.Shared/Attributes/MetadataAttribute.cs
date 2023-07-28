using System.ComponentModel;

namespace Hid.CheckPoint.Shared.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
public class MetadataAttribute : DisplayNameAttribute
{
    /// <summary>
    /// Флаг про то, что свойство является системным
    /// и, хоть и может быть отправлено на фронт, но отображать его смысла нет.
    /// </summary>
    // public bool IsSystem { get; }
    
    private bool _ignorePermissions;
    private bool _isHidden;

    /// <summary>
    /// Свойство будет отображаться всегда, видимость не настраивается.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public bool IgnorePermissions
    {
        get => _ignorePermissions;
        set
        {
            if (_isHidden)
            {
                throw new InvalidOperationException(
                    $"{nameof(IgnorePermissions)} can't be set true, when {nameof(IsHidden)} is true");
            }

            _ignorePermissions = value;
        }
    }

    /// <summary>
    /// Скрытое свойство, нужно для работы системы.
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public bool IsHidden
    {
        get => _isHidden;
        set
        {
            if (_ignorePermissions)
            {
                throw new InvalidOperationException(
                    $"{nameof(IsHidden)} can't be set true, when {nameof(IgnorePermissions)} is true");
            }

            _isHidden = value;
        }
    }

    public MetadataAttribute(bool isHidden = false)
    {
    }

    public MetadataAttribute(string name, bool isHidden = false) : base(name)
    {
    }
}
