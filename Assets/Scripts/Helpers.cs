using UnityEngine;

namespace Helpers {
    public class Converters {
        public static float MeterToFoot(float meters) {
            return meters / 3.28084f;
        }
        public static float FootToMeter(float foots) {
            return foots * 3.28084f;
        }
    }
}
