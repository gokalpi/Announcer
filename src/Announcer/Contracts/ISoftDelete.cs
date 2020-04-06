namespace Announcer.Contracts
{
    /// <summary>
    /// Entity interface for dependency injection
    /// </summary>
    /// <remarks>@Ibrahim Gokalp - 2020</remarks>
    public interface ISoftDelete
    {
        /// <summary>
        /// Entity is soft deleted?
        /// </summary>
        bool IsDeleted { get; set; }
    }
}