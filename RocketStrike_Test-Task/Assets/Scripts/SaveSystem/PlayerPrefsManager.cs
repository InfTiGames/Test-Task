using UnityEngine;

namespace SaveSystem {

    public static class PlayerPrefsManager {

        private const string Key = "GravitationAcceleration";

        /// <summary>
        /// Saves data to local storage in registry
        /// </summary>
        /// <param name="gravitationAccelerationValue"></param>
        public static void SavePlayerGravitationAccelerationValue(float gravitationAccelerationValue) {
            PlayerPrefs.SetFloat(Key, gravitationAccelerationValue);
            PlayerPrefs.Save();
        }

        /// <summary>
        /// Returns saved data from registry by key 
        /// </summary>
        /// <returns></returns>
        public static float GetPlayerGravitationAccelerationValue() {
            return PlayerPrefs.GetFloat(Key);
        }
    }
}