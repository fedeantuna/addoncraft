using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AddonCraft.Domain.Enums
{
    /// <summary>
    /// Game version flavor options.
    /// </summary>
    public class GameFlavor
    {
        private const String RetailCode = "WOW_RETAIL";
        private const String ClassicCode = "WOW_CLASSIC";

        private static readonly IReadOnlyDictionary<GameFlavorEnum, GameFlavor> GameFlavorEnumMap;
        private static readonly IReadOnlyDictionary<String, GameFlavor> GameVersionFlavorCodeMap;

        private readonly GameFlavorEnum _gameVersionFlavorEnum;
        private readonly String _name;
        private readonly String _curseforgeCode;

        /// <summary>
        /// Option for the Retail flavor of the game.
        /// </summary>
        public static readonly GameFlavor Retail = new GameFlavor(GameFlavorEnum.Retail, RetailCode);

        /// <summary>
        /// Option for the Classic flavor of the game.
        /// </summary>
        public static readonly GameFlavor Classic = new GameFlavor(GameFlavorEnum.Classic, ClassicCode);

        static GameFlavor()
        {
            var gameVersionFlavorEnumMap = new Dictionary<GameFlavorEnum, GameFlavor>
            {
                { GameFlavorEnum.Retail, Retail },
                { GameFlavorEnum.Classic, Classic }
            };

            var gameVersionFlavorCodeMap = new Dictionary<String, GameFlavor>
            {
                { RetailCode, Retail },
                { ClassicCode, Classic }
            };

            GameFlavorEnumMap = new ReadOnlyDictionary<GameFlavorEnum, GameFlavor>(gameVersionFlavorEnumMap);
            GameVersionFlavorCodeMap = new ReadOnlyDictionary<String, GameFlavor>(gameVersionFlavorCodeMap);
        }

        private GameFlavor(GameFlavorEnum gameVersionFlavorEnum, String curseforgeCode)
        {
            this._gameVersionFlavorEnum = gameVersionFlavorEnum;
            this._name = gameVersionFlavorEnum.ToString();
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
        public String ToCurseforgeCode() => this._curseforgeCode.ToLowerInvariant();

        /// <summary>
        /// Returns the Game Version Flavor associated to the specified enum.
        /// </summary>
        /// <param name="gameVersionFlavorEnum">The specified enum.</param>
        /// <returns></returns>
        public static GameFlavor FromEnum(GameFlavorEnum gameVersionFlavorEnum) => GameFlavorEnumMap[gameVersionFlavorEnum];

        /// <summary>
        /// Returns the Game Version Flavor associated to the specified code.
        /// </summary>
        /// <param name="gameVersionFlavorCode">The specified code.</param>
        /// <returns></returns>
        public static GameFlavor FromCode(String gameVersionFlavorCode) => GameVersionFlavorCodeMap[gameVersionFlavorCode.ToUpperInvariant()];

        /// <summary>
        /// Returns an enum that represents the Game Version Flavor object.
        /// </summary>
        /// <param name="gameVersionFlavor">The Game Version Flavor object</param>
        public static implicit operator GameFlavorEnum(GameFlavor gameVersionFlavor) => gameVersionFlavor._gameVersionFlavorEnum;

        /// <summary>
        /// The enum from which the <see cref="GameFlavor"/> constructs.
        /// </summary>
        public enum GameFlavorEnum
        {
            Retail,
            Classic
        }
    }
}