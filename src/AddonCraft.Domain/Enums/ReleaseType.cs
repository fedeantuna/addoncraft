using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AddonCraft.Domain.Enums
{
    public class ReleaseType
    {
        private static readonly IReadOnlyDictionary<ReleaseTypeEnum, ReleaseType> ReleaseTypeMap;

        private readonly ReleaseTypeEnum _releaseTypeEnum;
        private readonly String _name;
        private readonly Int32 _curseforgeCode;

        /// <summary>
        /// Option for the Stable release
        /// </summary>
        public static readonly ReleaseType Stable = new ReleaseType(ReleaseTypeEnum.Stable, 1);

        /// <summary>
        /// Option for the Beta release
        /// </summary>
        public static readonly ReleaseType Beta = new ReleaseType(ReleaseTypeEnum.Beta, 2);

        /// <summary>
        /// Option for the Alpha release
        /// </summary>
        public static readonly ReleaseType Alpha = new ReleaseType(ReleaseTypeEnum.Alpha, 3);

        static ReleaseType()
        {
            var releaseTypeMap = new Dictionary<ReleaseTypeEnum, ReleaseType>
            {
                { ReleaseTypeEnum.Stable, Stable },
                { ReleaseTypeEnum.Beta, Beta },
                { ReleaseTypeEnum.Alpha, Alpha }
            };

            ReleaseTypeMap = new ReadOnlyDictionary<ReleaseTypeEnum, ReleaseType>(releaseTypeMap);
        }

        private ReleaseType(ReleaseTypeEnum releaseTypeEnum, Int32 curseforgeCode)
        {
            this._releaseTypeEnum = releaseTypeEnum;
            this._name = releaseTypeEnum.ToString();
            this._curseforgeCode = curseforgeCode;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override String ToString() => this._name;

        /// <summary>
        /// Returns the Cursforge code that represents the current object.
        /// </summary>
        /// <returns>The Cursforge code that represents the current object.</returns>
        public Int32 ToCurseforgeCode() => this._curseforgeCode;

        /// <summary>
        /// Returns the Game Version Flavor associated to the specified enum.
        /// </summary>
        /// <param name="releaseTypeEnum">The specified enum.</param>
        /// <returns></returns>
        public static ReleaseType FromEnum(ReleaseTypeEnum releaseTypeEnum) => ReleaseTypeMap[releaseTypeEnum];

        /// <summary>
        /// Returns an enum that represents the Release Type object.
        /// </summary>
        /// <param name="releaseType">The Release Type object</param>
        public static implicit operator ReleaseTypeEnum(ReleaseType releaseType) => releaseType._releaseTypeEnum;

        /// <summary>
        /// The enum from which the <see cref="ReleaseType"/> constructs.
        /// </summary>
        public enum ReleaseTypeEnum
        {
            Stable,
            Beta,
            Alpha
        }
    }
}