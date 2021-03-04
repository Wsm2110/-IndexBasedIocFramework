namespace WSM.Container.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public enum Lifetime
    {
        /// <summary>
        /// Transient lifetime will always create a new object 
        /// </summary>
        Transient = 0,
        /// <summary>
        /// Creates a singleton
        /// </summary>
        Singleton = 1

    }
}
