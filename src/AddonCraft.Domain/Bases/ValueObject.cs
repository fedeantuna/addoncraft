using System;
using System.Collections.Generic;
using System.Linq;

namespace AddonCraft.Domain.Bases
{
    /// <summary>
    /// Base for value objects.
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// Determines whether the <paramref name="left"/> object is equal to the <paramref name="right"/> object.
        /// </summary>
        /// <param name="left">The left object to compare with the right object.</param>
        /// <param name="right">The right object to compare with the left object.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> object is equal to the <paramref name="right"/> object; otherwise, <see langword="false"/>.</returns>
        public static Boolean operator ==(ValueObject left, ValueObject right) => !(left is null ^ right is null) && (left is null || left.Equals(right));

        /// <summary>
        /// Determines whether the <paramref name="left"/> object is not equal to the <paramref name="right"/> object.
        /// </summary>
        /// <param name="left">The left object to compare with the right object.</param>
        /// <param name="right">The right object to compare with the left object.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/> object is not equal to the <paramref name="right"/> object; otherwise, <see langword="false"/>.</returns>
        public static Boolean operator !=(ValueObject left, ValueObject right) => !(left == right);

        /// <summary>
        /// Gets the elements that need to be equal in two objects so they can be considered equal.
        /// </summary>
        /// <returns>Each element to compare.</returns>
        protected abstract IEnumerable<Object> GetEqualityComponents();

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
        public override Boolean Equals(Object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override Int32 GetHashCode()
        {
            return this.GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}