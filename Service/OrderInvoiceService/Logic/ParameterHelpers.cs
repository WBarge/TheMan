using Exceptions;
using Utilites;

namespace OrderInvoiceService.Logic;

/// <summary>
/// methods to help with parameters
/// </summary>
public class ParameterHelpers
{
    /// <summary>
    /// Throws the invalid parameter exception if the passed in object is null.
    /// Used to validate that parameters are not null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object.</param>
    /// <exception cref="InvalidParameterException">Parameter is required for the {typeof(T).Name} parameter</exception>
    /// <example>
    /// public async Task SomeMethod([FromBody]ParameterType para)
    /// {
    /// UIHelpers.ThrowInvalidParameterExceptionIfNull(para);
    /// ...
    /// }
    /// </example>
    public static void ThrowInvalidParameterExceptionIfNull<T>(T obj)
    {
        if (obj.IsEmpty())
        {
            throw new InvalidParameterException($"Parameter is required for the {typeof(T).Name} parameter");
        }
    }
}