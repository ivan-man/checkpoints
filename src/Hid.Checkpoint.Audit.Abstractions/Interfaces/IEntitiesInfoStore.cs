using System;
using System.Reflection;
using Hid.Checkpoint.Audit.Abstractions.Models;

namespace Hid.Checkpoint.Audit.Abstractions.Interfaces
{
    public interface IEntitiesInfoStore
    {
        public const BindingFlags BFlags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

        /// <summary>
        /// Get List of monitored properties.
        /// </summary>
        /// <param name="entityType">Entity type</param>
        AuditPropertyInfo[] GetPropertyInfos(Type entityType);

        /// <summary>
        /// Check whether we need to track that entity
        /// Logic may be different depending on DB we use
        /// </summary>
        /// <param name="entityEntry">
        /// Object that represents DbContext or other repository trackable instance, can be an entity
        /// itself
        /// </param>
        bool ShouldBeTracked(object entityEntry);

        /// <summary>
        /// Check if object may be tracked, if so will fulfill store with it's properties
        /// </summary>
        /// <param name="entityType">Entity type</param>
        /// <param name="propertyName">Requested property</param>
        /// <returns></returns>
        bool ShouldBeTracked(Type entityType, string propertyName);

        /// <summary>
        /// Check if object may be tracked, if so will fulfill store with it's properties
        /// </summary>
        /// <param name="entityType">Entity type</param>
        bool ShouldBeTracked(Type entityType);
    }
}
