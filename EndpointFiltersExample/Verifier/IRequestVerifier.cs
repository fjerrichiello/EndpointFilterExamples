using FluentValidation.Results;

namespace EndpointFiltersExample.Verifier;

public interface IRequestVerifier<in TUnverified>
{
    ValidationResult
        ValidateInternal(TUnverified parameters);
}