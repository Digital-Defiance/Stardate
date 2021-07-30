namespace Stardate
{
    public enum JdcFormat
    {
        /// <summary>
        /// the full, canonical Day Count
        /// </summary>
        Full,

        /// <summary>
        /// the full Day Count, without the fractional time part
        /// </summary>
        Fullday,

        /// <summary>
        /// just the fractional time part of the full Day Count
        /// </summary>
        Fulltime,

        /// <summary>
        /// an abbreviated Day Count, 2400000.5 less than the full (starts at
        /// midnight instead of noon)
        /// </summary>
        Modified,

        /// <summary>
        /// the modified Day Count, without the fractional time part
        /// </summary>
        Day,

        /// <summary>
        /// just the fractional time part of the modified Day Count
        /// </summary>
        Time,
    }
}
