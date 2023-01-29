namespace Domain.Common.@enum
{
    /// Specifies where a When/Unless condition should be applied
    public enum ApplyConditionTo
    {
        /// Applies the condition to all validators declared so far in the chain.
        AllValidators,

        /// Applies the condition to the current validator only.
        CurrentValidator
    }
}
