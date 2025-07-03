using FluentValidation;
using FluentValidation.Results;

namespace EndpointFiltersExample.Verifier;

public abstract class RequestVerifier<TUnverifiedData> :
    AbstractValidator<TUnverifiedData>,
    IRequestVerifier<TUnverifiedData>
{
    protected RequestVerifier()
    {
        RuleSet("Validate", ValidationRules);
    }

    protected abstract void ValidationRules();

    public ValidationResult ValidateInternal(
        TUnverifiedData parameters)
    {
        return this.Validate(parameters, options => options.IncludeRuleSets("Validate"));
    }
}