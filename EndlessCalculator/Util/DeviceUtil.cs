using Microsoft.Maui.Devices;

namespace EndlessCalculator.Util
{
    public static class DeviceUtil
    {
        private static IDeviceInfo DeviceInfo => Microsoft.Maui.Devices.DeviceInfo.Current;
        private static DevicePlatform Platform => DeviceInfo.Platform;

        private static bool IsPlatform(DevicePlatform platform) => Platform == platform;

        public static bool IsIOS => IsPlatform(DevicePlatform.iOS);
        public static bool IsAndroid => IsPlatform(DevicePlatform.Android);
    }
}
