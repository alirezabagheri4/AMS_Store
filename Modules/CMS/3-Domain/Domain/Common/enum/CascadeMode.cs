namespace Domain.Common.@enum
{
    /// Specifies how rules should cascade when one fails.
    public enum CascadeMode
    {
        /// When a rule fails, execution continues to the next rule.
        Continue,

        /// When a rule fails, validation is stopped and all other rules in the chain will not be executed.
        [Obsolete("Use CascadeMode.Stop instead. The behaviour of StopOnFirstFailure was ambiguous when used at validator-level. For more details, see https://docs.fluentvalidation.net/en/latest/conditions.html#stop-vs-stoponfirstfailure")]
        StopOnFirstFailure,

        /// When a rule fails, validation is immediately halted.
        Stop,
    }
}
